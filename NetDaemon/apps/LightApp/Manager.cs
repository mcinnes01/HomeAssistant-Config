using System.Reactive.Disposables;
using Extensions;
using NetDaemon.Extensions.MqttEntityManager;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace LightManagerV2;

public class 
Manager
{
    private readonly List<string>           _onStates = ["on", "playing"];
    private          string                 _entityName;
    private          string                 _roomModeSelect;
    private          string                 _enabledSwitch;
    private          IMqttEntityManager     _entityManager;
    private          int                    _guardTimeout;
    private          IHaContext             _haContext;
    private          ILogger<LightsManager> _logger;
    private          string                 _ndUserId;
    private          bool                   _overrideActive;
    private          IRandomManager         _randomManager;
    private          IScheduler             _scheduler;
    private          Services               _services;
    private          InputSelectEntity      _locationMode;
    private          InputSelectEntity      _lightControlMode;
    private          IDisposable            _overrideSchedule = Disposable.Empty;

    public bool Debug { get; }
    public bool IsBedroom { get; set; }
    public bool IsMasterBedroom => _entityName?.Equals("bedroom") ?? false;
    public bool IsAnyControlEntityOn => AllControlEntities.Any(e => e.IsOn());
    private bool AllControlEntitiesAreOff => AllControlEntities.All(e => e.IsOff());
    public bool IsNightLight { get; set; }
    private bool IsNightMode => IsBedroom ? RoomMode!.IsSleeping() : _lightControlMode.IsSleeping();
    private bool IsOccupied => PresenceEntities.Union(KeepAliveEntities).Any(entity => entity.IsOn() || _onStates.Contains(entity.State!));
    private bool IsTooBright => LuxEntity != null && ( LuxLimitEntity != null ? LuxEntity.State >= LuxLimitEntity.State : LuxEntity.State >= LuxLimit );
    public bool Watchdog { get; set; } = true;
    public Entity? ConditionEntity { get; set; }
    public InputSelectEntity? RoomMode { get; set; }
    public int NightTimeout { get; init; }
    public int OverrideTimeout { get; init; }
    public int Timeout { get; init; }
    public int? LuxLimit { get; set; }
    public List<Entity> SupressionEntities { get; init; } = [];
    public List<BinarySensorEntity> KeepAliveEntities { get; init; } = [];
    public List<BinarySensorEntity> PresenceEntities { get; init; } = [];
    private IEnumerable<LightEntity> AllControlEntities => ControlEntities.Union(NightControlEntities).Union(MonitorEntities).ToList();
    public List<LightEntity> ControlEntities { get; init; } = [];
    private List<LightEntity> MonitorEntities { get; } = [];
    public List<LightEntity> NightControlEntities { get; init; } = [];
    private List<string> RandomStates { get; } = [];
    public NumericSensorEntity? LuxEntity { get; set; }
    public NumericSensorEntity? LuxLimitEntity { get; set; }
    public string Name { get; init; } = null!;
    public string RoomState { get; set; }
    public string? ConditionEntityState { get; set; }
    public SwitchEntity ManagerEnabled { get; set; }
    private TimeSpan DynamicTimeout => TimeSpan.FromSeconds(_overrideActive ? OverrideTimeoutParsed : TimeoutParsed);
    private bool ConditionEntityStateNotMet => ConditionEntity != null && ConditionEntityState != null && ConditionEntity.State != ConditionEntityState;
    private int NightTimeoutParsed => NightTimeout == 0 ? 90 : NightTimeout;
    private int OverrideTimeoutParsed => OverrideTimeout == 0 ? 1800 : OverrideTimeout;
    private int TimeoutParsed => IsNightMode ? NightTimeoutParsed : Timeout;

    private List<Task> Tasks { get; } = [];

    public async Task Init(ILogger<LightsManager> logger, string ndUserId, IRandomManager randomManager,
    IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager, int guardTimeout,
    InputSelectEntity locationMode, InputSelectEntity lightControlMode)
    {
        _logger        = logger;
        _ndUserId      = ndUserId;
        _randomManager = randomManager;
        _scheduler     = scheduler;
        _haContext     = haContext;
        _entityManager = entityManager;
        _entityName    = Name.ToLower().Replace("_", " ");
        _roomModeSelect = RoomMode?.EntityId ?? $"input_select.{Name.ToLower()}_mode";
        _enabledSwitch = $"switch.light_manager_{Name.ToLower()}";
        _guardTimeout  = guardTimeout;
        _services      = new Services(haContext);
        _locationMode  = locationMode;
        _lightControlMode = lightControlMode;
        _logger.LogInformation("Setup {room}", _entityName);
        await SetupRoomModeSelect();
        await SetupEnabledSwitch();
        SubscribePresenceOnEvent();
        SubscribePresenceOffEvent();
        SubscribeOverrideEvent();
        SubscribeManualTurnOnOverrideEvent();
        SubscribeManualTurnOffOverrideEvent();
        SubscribeHouseModeEvent();
        SubscribeGuard();

        if (RandomStates.Any())
            _randomManager.Init(ControlEntities, RandomStates);
    }

    // Any action through HA i.e. alexa or mqtt switches will show as ND
    private bool IsNdUserOrHa(StateChange stateChange)
    {
        var state = stateChange.New?.Context?.UserId == null || stateChange.New?.Context?.UserId == _ndUserId;
        _logger.LogDebug("{entity} turned {action} {by} using user {user}", 
            stateChange.Entity.EntityId, 
            stateChange.Entity.State,
            state ? "manually" : "automatically", 
            stateChange.New?.Context?.UserId);
        return state;
    }

    private bool LightAttributesOverride(StateChange<LightEntity, EntityState<LightAttributes>> e) =>
        !IsNdUserOrHa(e) &&
        e.Old.IsOn() && e.New.IsOn()
        && (!Equals(e.Old?.Attributes?.Brightness, e.New?.Attributes?.Brightness)
         || !Equals(e.Old?.Attributes?.ColorTemp, e.New?.Attributes?.ColorTemp));

    private bool LightTurnedOffManually(StateChange<LightEntity, EntityState<LightAttributes>> e)
    {
        var state = !IsNdUserOrHa(e) && e.Old.IsOn() && e.New.IsOff();
        return state;
    }

    private bool LightTurnedOnManually(StateChange<LightEntity, EntityState<LightAttributes>> e)
    {
        var state = !IsNdUserOrHa(e) && e.Old.IsOff() && e.New.IsOn();
        return state;
    }

    private void ResetOverride()
    {
        _logger.LogDebug("{room} Reset Override", _entityName);
        _overrideSchedule.Dispose();
        _overrideActive = true;
        _overrideSchedule = _scheduler.Schedule(DynamicTimeout, _ =>
        {
            _logger.LogDebug("{room} Override Timeout", _entityName);
            _overrideActive = false;
            TurnOffEntities($"Override ({_entityName})");
            WaitAllTasks();
        });
        UpdateAttributes(true);
    }

    private async Task SetupEnabledSwitch()
    {
        _logger.LogDebug("{room} Setup Enabled Switch", _entityName);

        if (_haContext.Entity(_enabledSwitch).State == null 
        || string.Equals(_haContext.Entity(_enabledSwitch).State, "unavailable", StringComparison.InvariantCultureIgnoreCase))
        {
            await _entityManager.CreateAsync(_enabledSwitch, new EntityCreationOptions(Name: $"Light Manager {_entityName}", DeviceClass: "switch", Persist: true));
        }

        ManagerEnabled = new SwitchEntity(_haContext, _enabledSwitch);
        ManagerEnabled.TurnOn();

        if (_enabledSwitch != "switch.light_manager_testroom")
        {
            (await _entityManager.PrepareCommandSubscriptionAsync(_enabledSwitch) ).SubscribeAsync(async s =>
                {
                    _logger.LogDebug("{room} Changing Enabled Switch", _entityName);
                    await _entityManager.SetStateAsync(_enabledSwitch, s);
                    _logger.LogDebug("{room} Enabled Switch Set to {state}", _entityName, s);
                }
            );
        }
    }

    private async Task SetupRoomModeSelect()
    {
        if (RoomMode != null)
            return;

        _logger.LogDebug("{room} Setup Room Mode Select", _entityName);

        if (_haContext.Entity(_roomModeSelect).State == null 
            || string.Equals(_haContext.Entity(_roomModeSelect).State, "unavailable", StringComparison.InvariantCultureIgnoreCase))
        {
            // Create the input_select entity
            await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions(Name: $"{_entityName} Mode", DeviceClass: "input_select", Persist: true));

            RoomMode = new InputSelectEntity(_haContext, _roomModeSelect);

            // Set the options for the input_select entity
            if(IsBedroom)
                RoomMode.SetOptions(EnumExtensions.ToList<BedroomModeOptions>());
            else
                RoomMode.SetOptions(EnumExtensions.ToList<RoomModeOptions>());

            // Set the default value to "Normal"
            RoomMode.SelectOption(RoomModeOptions.Normal);
        }
        else if (RoomMode == null)
        {
            RoomMode = new InputSelectEntity(_haContext, _roomModeSelect);
        }

        if (_roomModeSelect != "input_select.testroom_mode")
        {
            // This creates a subscription just to output the state of the entity
            (await _entityManager.PrepareCommandSubscriptionAsync(RoomMode.EntityId) ).SubscribeAsync(async s =>
                {
                    _logger.LogDebug("{room} Changing Bedroom Mode", RoomMode.EntityId);
                    await _entityManager.SetStateAsync(RoomMode.EntityId, s);
                    _logger.LogDebug("{room} Changed Bedroom Mode {state}", RoomMode.EntityId, s);
                }
            );
        }
    }

    private void SubscribeGuard()
    {
        if (!Watchdog)
        {
            _logger.LogDebug("{room} Watchdog Disabled", _entityName);
            return;
        }

        _logger.LogDebug("{room} Subscribed to Watchdog Schedule", _entityName);
        var totalMinutes = (int)TimeSpan.FromSeconds(_guardTimeout).TotalMinutes;

        _scheduler.ScheduleCron($"*/{totalMinutes} * * * *", () =>
        {
            if (RoomState == "on" || _overrideActive || AllControlEntities.All(e => e.IsOff())) return;
            _logger.LogDebug("{room} Watchdog turning off entities", _entityName);
            TurnOffEntities($"Watchdog ({_entityName})");
            WaitAllTasks();
        });
    }

    private void SubscribeHouseModeEvent()
    {
        // TODO: this needs to use the master bedroom to control the house state as it does now
        // however if locationMode is guest and IsBedroom, then we don't change the room state for that room
        // we can do some presence stuff too possible i.e. guest mode and occupied room.
        // if it gets to 11am and house mode has changed from sleeping we should set to normal from sleeping too.

        _lightControlMode.StateChanges().Subscribe(l =>
        {
            _logger.LogInformation("Light Control Mode Changed");

            // This sets other bedrooms mode when the house state changed
            // If guest mode is set then these remain independant
            // TODO: We could encorporate presence to identify which bedrooms are in use 
            // allowing us to set the state in unused bedrooms. May also need some overall
            // cut off if the state is never set. Also we could use a presence with light off
            // to signify sleep
            if (IsBedroom && !IsMasterBedroom && _locationMode.IsOneOrBothHome())
            {
                if (!l.Old.IsSleeping() && l.New.IsSleeping()) RoomMode!.Sleeping();

                if (l.Old.IsSleeping() && l.New.IsMotion()) RoomMode!.Normal();
            }

            // This sets the master bedroom mode when the house enters sleeping and we are away
            if (IsMasterBedroom && !_locationMode.IsOneOrBothHome())
            {
                if (!l.Old.IsSleeping() && l.New.IsSleeping()) RoomMode!.Sleeping();

                if (l.Old.IsSleeping() && l.New.IsMotion()) RoomMode!.Normal();
            }
        });

        _logger.LogDebug("{room} Subscribed to House Mode Changed Events", _entityName);
        RoomMode?.StateChanges().Subscribe(room =>
        {
            if (AllControlEntitiesAreOff)
            {
                UpdateAttributes();
                WaitAllTasks();
                return;
            }

            _logger.LogDebug("{room} Control Entities On: {entities}", _entityName, AllControlEntities.Select(e => e.EntityId));
            TurnOffEntities("House Mode Change", true);

            _scheduler.Schedule(TimeSpan.FromMilliseconds(250), (_, _) =>
            {
                TurnOnEntities("House Mode Change", true);
                UpdateAttributes();
            });

            WaitAllTasks();
        });
    }

    private void SubscribeManualTurnOffOverrideEvent()
    {
        _logger.LogDebug("{room} Subscribed to Manual Turn Off Override Events", _entityName);
        AllControlEntities
            .StateAllChanges()
            .Where(LightTurnedOffManually)
            .Subscribe(_ =>
            {
                _logger.LogInformation("{room} Manual Turn Off Override by user", _entityName);

                if (AllControlEntities.Any(e => e.IsOn()))
                {
                    _logger.LogInformation("{room} Override active as some control entities are on", _entityName);
                    return;
                }

                _logger.LogInformation("{room} Override reset as all control entities are off", _entityName);
                _overrideActive = false;
                _overrideSchedule.Dispose();
                UpdateAttributes();
                WaitAllTasks();
            });
    }

    private void SubscribeManualTurnOnOverrideEvent()
    {
        _logger.LogDebug("{room} Subscribed to Manual Turn On Override Events", _entityName);
        AllControlEntities
            .StateAllChanges()
            .Where(LightTurnedOnManually)
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} Manual Turn On Override for {light} by user", _entityName, e.New?.EntityId);
                LogInLogbook(e.New?.EntityId ?? "UNKNOWN", "Override Triggered");
                ResetOverride();
                UpdateAttributes(true);
                WaitAllTasks();
            });
    }

    private void SubscribeOverrideEvent()
    {
        _logger.LogDebug("{room} Subscribed to Attribute Override Events", _entityName);
        AllControlEntities
            .StateAllChanges()
            .Where(LightAttributesOverride)
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} Attribute Override by user", _entityName);
                LogInLogbook(e.New?.EntityId ?? "UNKNOWN", "Override Triggered");
                ResetOverride();
                UpdateAttributes();
                WaitAllTasks();
            });
    }

    private void SubscribePresenceOffEvent()
    {
        _logger.LogDebug("{room} Subscribed to Presence Off Events", _entityName);
        PresenceEntities
            .Union(KeepAliveEntities)
            .StateChanges()
            .Throttle(_ => Observable.Timer(DynamicTimeout, _scheduler))
            .Where(e => e.New.IsOff())
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} No Motion Timeout '{entity}'", _entityName, e.New?.EntityId);

                if (_overrideActive)
                {
                    _logger.LogInformation("{room} Not turning off - Override active ", _entityName);
                    return;
                }

                TurnOffEntities(e.New?.EntityId);
                UpdateAttributes(true);
                WaitAllTasks();
            });

        PresenceEntities
            .Union(KeepAliveEntities)
            .StateChanges()
            .Where(e => e.New.IsOff())
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} No Motion '{entity}'", _entityName, e.New?.EntityId);
                UpdateAttributes(true);
                WaitAllTasks();
            });
    }

    private void SubscribePresenceOnEvent()
    {
        _logger.LogDebug("{room} Subscribed to Presence On Events", _entityName);
        PresenceEntities.StateAllChanges()
            .Where(e => e.New.IsOn())
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} Motion '{entity}'", _entityName, e.New?.EntityId);

                if (_overrideActive)
                {
                    _logger.LogInformation("{room} Not turning on - resetting Override timeout", _entityName);
                    ResetOverride();
                    WaitAllTasks();
                    return;
                }

                TurnOnEntities(e.New?.EntityId);
                UpdateAttributes();
                WaitAllTasks();
            });
    }

    private void TurnOffEntities(string? trigger, bool ignoreConditions = false)
    {
        if (ManagerEnabled.IsOff())
        {
            _logger.LogInformation("{room} Manager Disabled", _entityName);
            return;
        }

        if (!ignoreConditions && IsOccupied)
        {
            _logger.LogInformation("{room} Cant turn off - Occupied", _entityName);
            return;
        }

        if (!ignoreConditions && ConditionEntityStateNotMet)
        {
            _logger.LogInformation("{room} Cant turn off - Condition not met {conditionEntity}!={state}", _entityName, ConditionEntity?.EntityId, ConditionEntityState);
            return;
        }

        var triggerMsg = $"Turned off by {trigger ?? "UNKNOWN"}";
        _logger.LogInformation("{room} Turn Off by {trigger}", _entityName, triggerMsg);
        foreach (var e in AllControlEntities.ToList())
        {
            _logger.LogDebug("{room} Turning Off {light} ", _entityName, e.EntityId);
            e.TurnOff();

            LogInLogbook(e, triggerMsg);
        }

        RoomState = "off";
    }

    private void TurnOnEntities(string? trigger, bool ignoreConditions = false)
    {
        List<LightEntity> lightEntities;

        if (ManagerEnabled.IsOff())
        {
            _logger.LogInformation("{room} Manager Disabled", _entityName);
            return;
        }

        if (!ignoreConditions && ConditionEntityStateNotMet)
        {
            _logger.LogInformation("{room} Condition not met {conditionEntity}!={state}", _entityName, ConditionEntity?.EntityId, ConditionEntityState);
            return;
        }

        if (!ignoreConditions && IsTooBright)
        {
            _logger.LogInformation("{room} Too Bright", _entityName);
            return;
        }

        if (SupressionEntities.Any(s => s.BoolState()))
        {
            _logger.LogInformation("Light is being supressed by another entity");
            return;
        }

        if (IsNightMode)
        {
            _logger.LogDebug("{room} Turn On Night Control Entities", _entityName);
            lightEntities = NightControlEntities.ToList();
        }
        else
        {
            _logger.LogDebug("{room} Turn On Control Entities", _entityName);
            lightEntities = ControlEntities.ToList();
        }

        foreach (var e in lightEntities.Where(l => l.IsOff()))
        {
            _logger.LogInformation("{room} Turning On {light}", _entityName, e.EntityId);
            e.TurnOn();
            LogInLogbook(e, $"Turned on by {trigger ?? "UNKNOWN"}");
        }

        RoomState = "on";
    }

    private void UpdateAttributes(bool showTurningOff = false)
    {
        var attributes = new
        {
            OverrideActive = _overrideActive,
            TurningOff     = showTurningOff ? ( _scheduler.Now + DynamicTimeout ).ToString() : "Unknown",
            DynamicTimeout,
            IsOccupied,
            IsTooBright,
            ConditionEntityStateMet = ConditionEntity?.EntityId == null ? "N/A" : ConditionEntityStateNotMet.ToString(),
            ConditionEntity         = ConditionEntity?.EntityId ?? "N/A",
            ConditionEntityState    = ConditionEntityState ?? "N/A",
            LastUpdated             = DateTime.Now.ToString("G")
        };
        Tasks.Add(_entityManager.SetAttributesAsync(_enabledSwitch, attributes));
        _logger.LogTrace("{room} Attributes updated to {attr}", _entityName, attributes);
    }

    private void LogInLogbook(Entity entity, string triggerMsg)
    {
        Tasks.Add(Task.Run(() =>
            _services.Logbook.Log(
                entityId: entity.EntityId,
                message: triggerMsg,
                name: entity.EntityId,
                domain: "light")
        ));
    }

    private void LogInLogbook(string entityId, string triggerMsg)
    {
        Tasks.Add(Task.Run(() =>
            _services.Logbook.Log(
                entityId: entityId,
                message: triggerMsg,
                name: entityId,
                domain: "light")
        ));
    }

    private void WaitAllTasks()
    {
        Task.WaitAll(Tasks.ToArray());
    }
}