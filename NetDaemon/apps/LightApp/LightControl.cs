using System.Reactive;
using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;
#pragma warning disable CS8618 
public class LightControl
{
    public required LightEntity Light { get; set; }
    public IEnumerable<BinarySensorEntity> PresenceSensors { get; set; } = new List<BinarySensorEntity>();
    public IEnumerable<BinarySensorEntity> TriggerSensors { get; set; }  = new List<BinarySensorEntity>();
    public IEnumerable<Entity> BlockEntities { get; set; } = new List<Entity>();
    public IEnumerable<Entity> KeepAliveEntities { get; set; } = new List<Entity>();
    public IEnumerable<Condition> Conditions { get; set; } = new List<Condition>();
    public required int Timeout { get; set; } = 120;
    public bool RecreateEnabledSwitch { get; set; } = false;
    public bool Primary { get; set; } = true;
    public bool TriggerWithoutPresence { get; set; } = false;
    private RoomControl _room { get; set; }
    private IMqttEntityManager _entityManager;
    private IScheduler _scheduler;
    private IHaContext _context;
    private Services _services;
    private ILogger<LightingManager> _logger;
    private readonly List<string> _onStates = new List<string> { "on", "playing" };
    private string _enabledSwitch = "";
    private SwitchEntity? ManagerEnabled = null;
    private List<Task> Tasks { get; } = new List<Task>();
    private IDisposable? _turnOffDisposable;
    private DateTime? TurnOnTime { get; set; }
    private DateTime? TurnOffTime { get; set; }

    public async Task Register(RoomControl room, IMqttEntityManager entityManager,
        IScheduler scheduler, IHaContext haContext, ILogger<LightingManager> logger)
    {
        _room = room;
        _entityManager = entityManager;
        _scheduler = scheduler;
        _context = haContext;
        _services = new Services(haContext);
        _logger = logger;
        await SetupEnabledSwitch();
        EnsureInitialState();
        SubscribeToIlluminanceSensor();
        SubscribePresenceOnEvent();
        SubscribePresenceOffEvent();
        SubscribeConditionStateChange();
        SubscribeBlockers();
    }

    // TODO Add lux sensor that defaults to the weather sataion lux sensor or it can be set
    // Also add a darkThreshold number sensor with a default of sensor.dark_threshold or it can be set
    // Subscribe to the lux sensor and if it goes below the darkThreshold, and turn the light on

    private void Watchdog()
    {
        // TODO: Add a watchdog for where something has gone wonkey, it shouldn't happen really so ensure we log as much as possible
        // The watchdog will have a subscription that runs every 5 minutes and checks the state of the light and the presence sensors
        // If the light is on and there has been no presence for 5 minutes, call the Ensure Initial State method
    }

    private void SubscribeRoomMode()
    {
        // TODO: Subscribe to the room mode select entity, this will not only control what happens with motion and presence
        // but will also potentially turn a light on or off and set blocks
    }

    private void EnsureInitialState()
    {
        // TODO we need to bring in the location, room mode, light mode, etc. to determine the initial state
        // Also things like if the light and tv are left on, should we not turn them off if there is no presence?
        // The tv could be controlled by it's own thing, maybe even a room manager that then feeds in to this
        // We perhaps need to do something with the keepalive sensor too
        var presenceStates = TriggerSensors.Union(PresenceSensors).Select(s => new { s.EntityId, IsOn = s.IsOn() });
        if (BlockEntities.All(b => !b.IsOn()))
        {
            if (presenceStates.Any(s => s.IsOn))
            {
                if (Light.IsOn())
                {
                    _logger.LogInformation("Initial state prescense detected {@states} and {light} is already on", presenceStates, Light.EntityId);
                    return;
                }
                _logger.LogInformation("Initial state {light} is off but there is presence detected {@states}, Turning On", Light.EntityId, presenceStates);
                TurnOnEntities("Initial State");
                return;
            }
            else if (Light.IsOn())
            {
                _logger.LogInformation("Initial state {light} is on but there is no presence detected {@states}, Turning Off", Light.EntityId, presenceStates);
                TurnOffEntities("Initial State");
            }
        }
        else
        {
            var mutipleLightsOn = BlockEntities.Where(b => b.Domain() == "light").Any(b => b.IsOn()) && Light.IsOn();
            if (mutipleLightsOn && presenceStates.Any(s => !s.IsOn))
            {
                var lightDetail = mutipleLightsOn  ? $"{Light.EntityId} and other light(s) on" : $"{Light.EntityId} is on";
                _logger.LogInformation("Initial state {light} is on but there is presence, Turning Off", lightDetail);
                 TurnOffEntities("Initial State", mutipleLightsOn);
                return;
            }
            _logger.LogInformation("Initial state {light} {state}, can't change as {light} is blocked by {blockers}",
                Light.EntityId, Light.State, Light.EntityId, BlockEntities.Where(b => b.IsOn()).Select(b => b.EntityId));
        }
    }

    private void SubscribeToIlluminanceSensor()
    {
        _room.IlluminanceSensor!.StateAllChanges()
        .Subscribe(e =>
        {
            // State has changed and is above the threshold
            if (e.Old?.State < _room.IlluminanceHighThreshold && e.New?.State >= _room.IlluminanceHighThreshold)
            {
                _logger.LogInformation("Illuminance Sensor {sensor} {state} is above threshold {threshold}, turning off {light}", e.New.EntityId, e.New.State, _room.IlluminanceLowThreshold, Light.EntityId);
                TurnOffEntities("Too Bright");
            }
            else if (e.Old?.State >= _room.IlluminanceLowThreshold && e.New?.State < _room.IlluminanceLowThreshold)
            {
                _logger.LogInformation("Illuminance Sensor {sensor} {state} is below threshold {threshold}, turning on {light}", e.New.EntityId, e.New.State, _room.IlluminanceLowThreshold, Light.EntityId);
                TurnOnEntities("Too Dark");
            }
        });
    }

    private void SubscribeConditionStateChange()
    {
        _logger.LogDebug("Subscribing {light} to Condition State Changes", Light.EntityId);
        foreach (var condition in Conditions)
        {
            _logger.LogDebug("{Light} Subscribed to {Entity} where state matches condition {State}", 
                Light.EntityId, condition.Entity.EntityId, condition.State);
            condition.Entity.StateAllChanges()
            .Subscribe(e =>
            {
                if (Light.IsOff() && !e.Old.ConditionPassed(condition) && e.New.ConditionPassed(condition))
                {
                    _logger.LogInformation("Condition has been met {Condition} {ConditionState}", condition.Entity.EntityId, condition.State);
                    TurnOnEntities(e.New?.EntityId);
                }
                else if (Light.IsOn() && e.Old.ConditionPassed(condition) && !e.New.ConditionPassed(condition))
                {
                    _logger.LogInformation("Condition has been removed {Condition} {ConditionState}", condition.Entity.EntityId, condition.State);
                    TurnOffEntities(e.New?.EntityId);
                }
            });
        }
    }

    private void SubscribeBlockers()
    {
        BlockEntities.StateAllChanges()
        .Subscribe(e =>
        {
            if (!e.Old.IsOn() && e.New.IsOn() && Light.IsOn())
            {
                _logger.LogInformation("{light} is blocked by {blocker}", Light.EntityId, e.New.EntityId);
                TurnOffEntities(e.New?.EntityId);
            }
            else if (e.Old.IsOn() && !e.New.IsOn())
            {
                if (Light.IsOff() && TriggerSensors.Union(PresenceSensors).Any(s => s.IsOn()))
                {
                    _logger.LogInformation("{light} is unblocked by {blocker} and presence detected", Light.EntityId, e?.New?.EntityId);
                    TurnOnEntities(e?.New?.EntityId);
                }
                else if (Light.IsOn() && TriggerSensors.Union(PresenceSensors).All(s => s.IsOff()))
                {
                    _logger.LogInformation("{light} is unblocked by {blocker} and no presence detected", Light.EntityId, e?.New?.EntityId);
                    TurnOffEntities(e?.New?.EntityId);
                }
            }
        });
    }

    private async Task SetupEnabledSwitch()
    {
        _enabledSwitch = $"switch.light_manager_{Light.Name()}".ToLower().ReplaceLineEndings("").Replace(" ", "");
        _logger.LogDebug("{light} Setup Enabled Switch", Light.EntityId);

        if (_context.Entity(_enabledSwitch).State != null && RecreateEnabledSwitch)
        {
            _logger.LogDebug("{switch} Remove enable switch", _enabledSwitch);
            await _entityManager.RemoveAsync(_enabledSwitch);
        }

        if (_context.Entity(_enabledSwitch).State == null)
        {
            await _entityManager.CreateAsync(_enabledSwitch, new EntityCreationOptions(Name: $"Light Manager {Light.EntityId}", DeviceClass: "switch", Persist: true));
            ManagerEnabled = new SwitchEntity(_context, _enabledSwitch);
            ManagerEnabled.TurnOn();
            _logger.LogDebug("{switch} Created Enabled Switch", _enabledSwitch);
        }

        if (_enabledSwitch != "switch.light_manager_testroom")
        {
            (await _entityManager.PrepareCommandSubscriptionAsync(_enabledSwitch)).SubscribeAsync(async s =>
                {
                    await _entityManager.SetStateAsync(_enabledSwitch, s);
                    var logMessage = $"{Light.EntityId} Manager Enabled Switch Set to {s}";
                    _logger.LogDebug(logMessage);
                    UpdateAttributes(logMessage);
                }
            );
        }
    }

    private void SubscribePresenceOnEvent()
    {
        _logger.LogDebug("{light} Subscribed to Presence On Events", Light.EntityId);
        PresenceSensors.StateAllChanges()
        .Merge(TriggerSensors.StateAllChanges())
        .Where(e => e.New.IsOn())
        .Subscribe(e =>
        {
            _logger.LogTrace("{light} Presence On Event {entity}", Light.EntityId, e.New?.EntityId);
            TurnOnEntities(e.New?.EntityId);
        });
    }
    
    private void SubscribePresenceOffEvent()
    {
        _logger.LogDebug("{light} Subscribed to Presence Off Events", Light.EntityId);

        PresenceSensors.StateAllChanges()
        .Merge(TriggerSensors.StateAllChanges())
        .Where(_ => TriggerSensors.Union(PresenceSensors).All(s => !s.IsOn()))
        .Subscribe(e =>
        {
            var states = TriggerSensors.Union(PresenceSensors).Select(s => new { s.EntityId, s.State });
            _logger.LogTrace("{light} Presence Off Event {entity} {states}", Light.EntityId, e.New?.EntityId, states);
            TurnOffEntities(e.New?.EntityId);
        });
    }

    private void TurnOffEntities(string? trigger = null, bool force = false)
    {
        if (_turnOffDisposable != null)
        {
            _turnOffDisposable.Dispose();
            _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
        }
        if (Light.IsOff())
        {
            _logger.LogTrace("{light} is already off", Light.EntityId);
            return;
        }
        if (ManagerEnabled.IsOff())
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
            return;
        }
        if(Conditions.Any() && Conditions.All(c => c.Entity.State == c.State))
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because condition(s) {Conditions} are keeping it on", Light.EntityId, trigger, Conditions.AsString());
            return;
        }
        if (!force && KeepAliveEntities.Any(b => b.State != null && _onStates.Contains(b.State)))
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because keep alive entity is on", Light.EntityId,
                KeepAliveEntities.Where(b => b.State != null && _onStates.Contains(b.State)).Select(b => b.EntityId));
            return;
        }
        if (TriggerSensors.Union(PresenceSensors).Any(s => s.IsOn()))
        {
            _logger.LogTrace("{light} is on but there is presence detected, not turning off", Light.EntityId);
            return;
        }

        TurnOffTime = DateTime.Now.AddSeconds(Timeout);
        var triggerMsg = force ? $"forced Off by {trigger ?? "UNKNOWN"}" : $"triggered by {trigger ?? "UNKNOWN"}";
        var logMessage = $"{Light.EntityId} Turning Off at {TurnOffTime:G} {triggerMsg}";
        _logger.LogInformation(logMessage);
        UpdateAttributes(logMessage);

        _turnOffDisposable = _scheduler.Schedule(TimeSpan.FromSeconds(Timeout), () =>
        {
            Light.TurnOff();
            logMessage = $"{Light.EntityId} Turned Off at {TurnOffTime:G} {triggerMsg}";
            _logger.LogInformation(logMessage);
            LogInLogbook(Light, logMessage);
            UpdateAttributes(logMessage);
            WaitAllTasks();
        });
    }

    private void TurnOnEntities(string? trigger)
    {
        if (_turnOffDisposable != null)
        {
            _turnOffDisposable.Dispose();
            _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
        }
        if (Light.IsOn())
        {
            _logger.LogTrace("{light} is already on", Light.EntityId);
            return;
        }
        if (ManagerEnabled.IsOff())
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
            return;
        }
        if(Conditions.Any() && Conditions.Any(c => c.State != c.Entity?.State))
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because one or more condition is not met {Conditions}", Light.EntityId, trigger, Conditions.AsString());
            return;
        }
        if (BlockEntities.Any(b => b.State != null && _onStates.Contains(b.State)))
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because block entity is on", Light.EntityId,
                BlockEntities.Where(b => b.State != null && _onStates.Contains(b.State)).Select(b => b.EntityId));
            return;
        }  
        if (!TriggerWithoutPresence && TriggerSensors.Union(PresenceSensors).Any(s => !s.IsOn()))
        {
            _logger.LogTrace("Can't turn {light} on as there is no presence detected", Light.EntityId);
            return;
        }
        if (Primary)
        {
            Light.TurnOn();
            TurnOnTime = DateTime.Now;
            var triggerMsg = $"triggered by {trigger ?? "UNKNOWN"}";
            var logMessage = $"{Light.EntityId} Turned On at {TurnOnTime:G} at {triggerMsg}";
            _logger.LogInformation(logMessage);
            LogInLogbook(Light, logMessage);
            UpdateAttributes(logMessage);
            WaitAllTasks();
        }
    }

    private void UpdateAttributes(string? logMessage = null)
    {
        var attributes = new
        {
            TurnOnTime,
            TurnOffTime,
            IsTurningOff = TurnOffTime > DateTime.Now,
            Light.State,
            Details = logMessage,
            BlockEntities = BlockEntities.Any() ? string.Join(",", BlockEntities.Select(c => c.EntityId)) : "N/A",
            KeepAliveEntities = KeepAliveEntities.Any() ? string.Join(",", KeepAliveEntities.Select(c => c.EntityId)) : "N/A",
            Condition = Conditions.Any() ? string.Join(",", Conditions.Select(c => $"{c.Entity.EntityId} {c.Entity.State} {c.Operator} {c.State}")) : "N/A",
            LastUpdated = DateTime.Now.ToString("G")
        };
        Tasks.Add(_entityManager.SetAttributesAsync(_enabledSwitch, attributes));
        _logger.LogTrace("{light} Attributes updated to {attr}", Light.EntityId, attributes);
    }

    private void LogInLogbook(Entity entity, string logMessage)
    {
        Tasks.Add(Task.Run(() =>
            _services.Logbook.Log(
                entityId: entity.EntityId,
                message: logMessage,
                name: entity.EntityId,
                domain: "light")
        ));
    }

    private void WaitAllTasks()
    {
        Task.WaitAll(Tasks.ToArray());
    }
}