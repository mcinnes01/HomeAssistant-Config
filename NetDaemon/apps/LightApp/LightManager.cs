using System.Reactive.Disposables;
using NetDaemon.Extensions.MqttEntityManager;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace NetDaemon.apps.LightApp;

public class LightManager : Room
{
    #region Properties
    private readonly List<string> _onStates = ["on", "playing"];
    private string _entityName;
    private string _enabledSwitch;
    private IMqttEntityManager _entityManager;
    private ILogger<Manager> _logger;
    private string _ndUserId;
    private bool _overrideActive;
    private IScheduler _scheduler;
    private Services _services;
    private Entities _entities;
    private InputSelectEntity _lightControlMode;
    private IDisposable _overrideSchedule = Disposable.Empty;
    private IEnumerable<LightEntity> AllLightEntities => LightEntities.Union(LampEntities).Union(NightLightEntities).Union(MonitorEntities).ToList();
    private bool IsTooBright { get; set; }
    private bool IsOccupied => PresenceEntities.Union(KeepAliveEntities).Any(entity => entity.IsOn() || _onStates.Contains(entity.State!));
    private bool IsNightMode => IsBedroom ? RoomMode!.IsSleeping() : _lightControlMode.IsSleeping();
    
    // This is a different timeout for night lights which is shorter than normal by default
    private int NightTimeoutParsed => NightTimeout == 0 ? 90 : NightTimeout;

    // This is the default timeout for when presence is detected
    private int TimeoutParsed => IsNightMode ? NightTimeoutParsed : Timeout;

    // This is a longer timeout for when something has been overridden i.e. a manual event
    private int OverrideTimeoutParsed => OverrideTimeout == 0 ? 1800 : OverrideTimeout;

    // This is the actual timeout which is either the normal timeout or the override timeout
    private TimeSpan DynamicTimeout => TimeSpan.FromSeconds(_overrideActive ? OverrideTimeoutParsed : TimeoutParsed);
    private List<LightEntity> MonitorEntities { get; } = [];
    private bool ConditionEntityStateNotMet => ConditionEntity != null && ConditionEntityState != null && ConditionEntity?.State != ConditionEntityState;
    private List<Task> Tasks { get; } = [];
    #endregion

    public async Task Init(ILogger<Manager> logger, string ndUserId,
    IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager)
    {
        _logger = logger;
        _ndUserId = ndUserId;
        _scheduler = scheduler;
        _entityManager = entityManager;
        _entityName = Name.ToLower().Replace("_", " ");
        _enabledSwitch = $"switch.light_manager_{Name.ToLower()}";
        _services = new Services(haContext);
        _entities = new Entities(haContext);

        // If no sensor is provided then we use the weather station and a default limit
        LuxLimitEntity = LuxLimitEntity ?? _entities.InputNumber.DimLux;
        LuxEntity = LuxEntity ?? _entities.Sensor.WeatherStationAmbientLight;

        _lightControlMode = _entities.InputSelect.LightControlMode;
        _logger.LogInformation("Setup {room}", _entityName);
        SubscribePresenceOnEvent();
        SubscribePresenceOffEvent();
        SubscribeManualTurnOnOverrideEvent();
        SubscribeManualTurnOffOverrideEvent();
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

    private bool LightTurnedOffManually(StateChange<LightEntity, EntityState<LightAttributes>> e) =>
        !IsNdUserOrHa(e) && e.Old.IsOn() && e.New.IsOff();

    private bool LightTurnedOnManually(StateChange<LightEntity, EntityState<LightAttributes>> e) =>
        !IsNdUserOrHa(e) && e.Old.IsOff() && e.New.IsOn();

    private void SubscribeManualTurnOffOverrideEvent()
    {
        _logger.LogDebug("{room} Subscribed to Manual Turn Off Override Events", _entityName);
        AllLightEntities
            .StateAllChanges()
            .Where(LightTurnedOffManually)
            .Subscribe(_ =>
            {
                _logger.LogInformation("{room} Manual Turn Off Override by user", _entityName);

                if (AllLightEntities.Any(e => e.IsOn()))
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
        AllLightEntities
            .StateAllChanges()
            .Where(LightTurnedOnManually)
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} Manual Turn On Override for {light} by user", _entityName, e.New?.EntityId);
                LogInLogbook(e.New?.EntityId ?? "UNKNOWN", "Override Triggered");
                UpdateAttributes(true);
                WaitAllTasks();
            });
    }

    private void SubscribePresenceOffEvent()
    {
        _logger.LogDebug("{room} Subscribed to Presence Off Events", _entityName);
        var entities = PresenceEntities.Union(KeepAliveEntities);

        entities
            .StateChanges()
            .Throttle(_ => Observable.Timer(DynamicTimeout, _scheduler))
            .Where(_ => !IsOccupied)
            .Subscribe(e =>
            {
                _logger.LogInformation("{room} No Motion Timeout '{entity}' states: {@Entities}",
                    _entityName, e.New?.EntityId, entities.Select(e => new {e.EntityId, e.State}));

                if (_overrideActive)
                {
                    _logger.LogInformation("{room} Not turning off - Override active ", _entityName);
                    return;
                }

                TurnOffEntities(e.New?.EntityId);
                UpdateAttributes(true);
                WaitAllTasks();
            });

        entities
            .StateChanges()
            .Where(_ => !IsOccupied)
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
        foreach (var e in AllLightEntities.ToList())
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

        if (!ignoreConditions && !IsOccupied)
        {
            _logger.LogInformation("{room} Cant turn on - not occupied", _entityName);
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
            lightEntities = NightLightEntities.ToList();
        }
        else
        {
            _logger.LogDebug("{room} Turn On Control Entities", _entityName);
            lightEntities = LightEntities.ToList();
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
            TurningOff = showTurningOff ? (_scheduler.Now + DynamicTimeout).ToString() : "Unknown",
            DynamicTimeout,
            IsOccupied,
            IsTooBright,
            IgnoreLux,
            LuxEntity = LuxEntity!.EntityId,
            LuxLimitEntity = LuxLimitEntity!.EntityId,
            LuxLimit = LuxLimitEntity!.State,
            Lux = LuxEntity!.State,
            ConditionEntityStateMet = ConditionEntity?.EntityId == null ? "N/A" : (!ConditionEntityStateNotMet).ToString(),
            ConditionEntity = ConditionEntity?.EntityId ?? "N/A",
            ConditionEntityState = ConditionEntity?.State ?? "N/A",
            ConditionState = ConditionEntityState ?? "N/A",
            LastUpdated = DateTime.Now.ToString("G")
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