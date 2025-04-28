using System.Reactive;
using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;
#pragma warning disable CS8618
public class LightControl
{
    // The subject light that this manager controls
    public required LightEntity Light { get; set; }
    // A trigger sensor will turn the light on
    public IEnumerable<BinarySensorEntity> TriggerSensors { get; set; }  = new List<BinarySensorEntity>();
    // A presence sensor will keep the light on
    public IEnumerable<BinarySensorEntity> PresenceSensors { get; set; } = new List<BinarySensorEntity>();
    // A block sensor will stop the light turning on
    public IEnumerable<Entity> BlockEntities { get; set; } = new List<Entity>();
    // A keep alive sensor will stop the light turning off
    public IEnumerable<Entity> KeepAliveEntities { get; set; } = new List<Entity>();
    // A trigger condition will turn the light on if met and off if not  
    public IEnumerable<Condition> TriggerConditions { get; set; } = new List<Condition>();
    // A condition will allow a trigger to turn the light on if met
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
    private Entities _entities;
    private ILogger<LightingManager> _logger;
    private InputSelectEntity _locationMode;
    private readonly List<string> _occupiedStates = new() { "Home", "OneAway", "Guest" };
    private string _enabledSwitch = "";
    private SwitchEntity? ManagerEnabled = null;
    private List<Task> Tasks { get; } = new List<Task>();
    private IDisposable? _turnOffDisposable;
    private DateTime? TurnOnTime { get; set; }
    private DateTime? TurnOffTime { get; set; }
    private bool IsMoodLight => !Primary && _room.HasMultipleLights;

    public async Task Register(RoomControl room, IMqttEntityManager entityManager,
        IScheduler scheduler, IHaContext haContext, ILogger<LightingManager> logger)
    {
        _room = room;
        _entityManager = entityManager;
        _scheduler = scheduler;
        _context = haContext;
        _services = new Services(haContext);
        _entities = new Entities(haContext);
        _logger = logger;
        _locationMode = _entities.InputSelect.LocationMode;
        await SetupEnabledSwitch();
        EnsureInitialState();
        SubscribeLocation();
        SubscribeRoomMode();
        SubscribeToIlluminanceSensor();
        SubscribePresenceOnEvent();
        SubscribePresenceOffEvent();
        SubscribeConditionTriggers();
        SubscribeBlockers();
    }

    // Still to do:
    // Might be nice to add a learning sequence to illuminance thresholds where it can set the values automatically,
    // by turning off the light taking the reading and then turning it on and taking the reading to give a high and low value
    // The room mode entities still aren't creating properly and we need to ensure we trigger set them. If there is presence in a room bar master bedroom
    // then we can do something like set mode to sleeping in all other rooms, if that room then becomes unoccupied and master bedroom is sleeping the we
    // set that to sleeping too. If we have guest mode enabled and there is general movement around the house we only set master bedroom to sleeping

    private async Task SetupEnabledSwitch()
    {
        _enabledSwitch = $"switch.light_manager_{Light.Name()}".ToLower().ReplaceLineEndings("").Replace(" ", "");
        _logger.LogDebug("{light} Setup Enabled Switch", Light.EntityId);

        if (_context.Entity(_enabledSwitch).State != null && RecreateEnabledSwitch)
        {
            _logger.LogDebug("{light} {switch} Remove enable switch", Light.EntityId, _enabledSwitch);
            await _entityManager.RemoveAsync(_enabledSwitch);
        }

        if (_context.Entity(_enabledSwitch).State == null)
        {
            await _entityManager.CreateAsync(_enabledSwitch, new EntityCreationOptions(
                Name: $"Light Manager {Light.Name().Replace("_", " ")}",
                UniqueId: _enabledSwitch,
                DeviceClass: "switch",
                Persist: true)).ConfigureAwait(false);
            ManagerEnabled = new SwitchEntity(_context, _enabledSwitch);
            ManagerEnabled.TurnOn();
            _logger.LogDebug("{light} {switch} Created Enabled Switch", Light.EntityId, _enabledSwitch);
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

    private void Watchdog()
    {
        // TODO: Add a watchdog for where something has gone wonkey, it shouldn't happen really so ensure we log as much as possible
        // The watchdog will have a subscription that runs every 5 minutes and checks the state of the light and the presence sensors
        // If the light is on and there has been no presence for 5 minutes, call the Ensure Initial State method
    }

    private void SubscribeLocation()
    {
        _locationMode.StateAllChanges()
        .Where(e => e.New?.State != null)
        .Subscribe(e =>
        {
            // Turn off the light if the location is not occupied and the light is on
            #pragma warning disable CS8604 // Possible null reference argument.
            if (!_occupiedStates.Contains(e.New!.State) && Light.IsOn())
            {
                _logger.LogInformation("Location is {location}, turning off {light}", e.New.State, Light.EntityId);
                TurnOffEntities("Location");
                return;
            }
            #pragma warning restore CS8604 // Possible null reference argument.

            // Turn off the light if the location is leaving and it's an entrance and the light is on
            if (e.New.IsOption(LocationModeOptions.Leaving) && !_room.IsEntrance && Light.IsOn())
            {
                _logger.LogInformation("Location is {location}, turning off {light} as its not an entrance lights", e.New.State, Light.EntityId);
                TurnOffEntities("Location");
                return;
            }
        });
    }

    private void SubscribeRoomMode()
    {
        // TODO: Subscribe to the room mode select entity, this will not only control what happens with motion and presence
        // but will also potentially turn a light on or off and set blocks
        _room.RoomMode?.StateAllChanges()
        .Subscribe(e =>
        {
            if (e.New.IsSleeping())
            {
                _logger.LogInformation("Room Mode is {mode}, turning off {light}", e.New.State, Light.EntityId);
                TurnOffEntities("Sleeping");
                return;
            }
            if (e.New.IsRelaxing())
            {
                if (IsMoodLight)
                {
                    _logger.LogInformation("Room Mode is {mode} and is a mood light, turning on {light}", e.New.State, Light.EntityId);
                    TurnOnEntities("Relaxing");
                    return;
                }
                if (_room.HasMultipleLights)
                {
                    _logger.LogInformation("Room Mode is {mode}, turning off primary {light}", e.New.State, Light.EntityId);
                    TurnOffEntities("Relaxing");
                    return;
                }
                _logger.LogInformation("Room Mode is {mode}, but there is only one light so leaving it as is {light}", e.New.State, Light.EntityId);
                return;
            }
            if (e.New.IsBright())
            {
                if (Primary)
                {
                    _logger.LogInformation("Room Mode is {mode}, turning on {light}", e.New.State, Light.EntityId);
                    TurnOnEntities("Bright");
                    return;
                }
                _logger.LogInformation("Room Mode is {mode}, turning off mood light {light}", e.New.State, Light.EntityId);
                TurnOffEntities("Bright");
                return;
            }
        });
    }

    private void EnsureInitialState()
    {
        // TODO we need to bring in the location, room mode, light mode, etc. to determine the initial state
        // Also things like if the light and tv are left on, should we not turn them off if there is no presence?
        // The tv could be controlled by it's own thing, maybe even a room manager that then feeds in to this
        // We perhaps need to do something with the keepalive sensor too
        _logger.LogDebug("Ensuring Initial State for {light}", Light.EntityId);

        // Need to add conditions in to initial state
        var presenceStates = TriggerSensors.Union(PresenceSensors).Select(s => new { s.EntityId, IsOn = s.IsOn() });
        var triggerConditions = TriggerConditions.Select(c => new
        {
            c.Entity.EntityId,
            ActualState = c.Entity.EntityState,
            TargetState = c.State,
            c.Operator,
            ConditionPassed = c.ConditionPassed()
        });

        // if Light is On
        // if keep alive keep on
        // else
        // if (Presence || Condition) && Illuminance < Bright && Location in (Home, OneHome, Guest) && Room Mode in () keep on / else turn off

        // if Light is Off
        // if block keep off
        // else
        // if (Presence || Condition) &&  Illuminance < Bright turn on / else turn off

        if (Light.IsOn())
        {
            if (KeepAliveEntities.Any(b => b.IsOn()))
            {
                _logger.LogInformation("Initial state {light} is on and there is at least one keep alive entity on {@alive}, Keeping On",
                    Light.EntityId, KeepAliveEntities.Select(b => b.EntityId));
                return;
            }
            else
            {
                if ((presenceStates.Any(s => s.IsOn) || triggerConditions.Any(c => c.ConditionPassed)) && (!_room.IsBright || _room.RoomMode.IsBright()))
                {
                    _logger.LogInformation("Initial state {light} is on and presence {@presence} or condition {@condition} are met and illuminance is not bright, Keeping On",
                        Light.EntityId, presenceStates, triggerConditions);
                    return;
                }
                _logger.LogInformation("Initial state {light} is on but there is no presence detected or condition met or it's too bright {illuminance} {threshold}, Turning Off",
                    Light.EntityId, _room.IlluminanceSensor?.State, _room.IlluminanceHighThreshold);
                TurnOffEntities("Initial State");
            }
        }
        else
        {
            if (BlockEntities.Any(b => b.IsOn()))
            {
                _logger.LogInformation("Initial state {light} is off and there is a block entity on {@block}, Keeping Off",
                    Light.EntityId, BlockEntities.Select(b => b.EntityId));
                return;
            }
            else
            {
                if ((presenceStates.Any(s => s.IsOn) || triggerConditions.Any(c => c.ConditionPassed))
                 && (_room.IgnoreIlluminance || _room.IlluminanceSensor?.State < _room.IlluminanceHighThreshold))
                {
                    _logger.LogInformation("Initial state {light} is off presence {@presence} or condition {condition} are met a illuminance {sensor} is not bright enough {illuminance} {threshold}, Turning On",
                        Light.EntityId, presenceStates, TriggerConditions.AsString(), _room.IlluminanceSensor?.EntityId, _room.IlluminanceSensor?.State, _room.IlluminanceHighThreshold);
                    TurnOnEntities("Initial State");
                    return;
                }
                _logger.LogInformation("Initial state {light} is off and there is no presence or condition met and illuminance {sensor} is not dark enough {illuminance} {threshold}, Keeping Off",
                    Light.EntityId, _room.IlluminanceSensor?.EntityId, _room.IlluminanceSensor?.State, _room.IlluminanceHighThreshold);
            }
        }
    }

    private void SubscribeToIlluminanceSensor()
    {
        if (!_room.IgnoreIlluminance)
        {
            _room.IlluminanceSensor!.StateAllChanges()
            .Throttle(TimeSpan.FromSeconds(60))
            .Subscribe(e =>
            {
                if (Light.IsOn() && e.New?.State >= _room.IlluminanceHighThreshold)
                {
                    _logger.LogInformation("Illuminance Sensor {sensor} {state} is above threshold {threshold}, turning off {light}",
                                            e.New.EntityId, e.New.State, _room.IlluminanceLowThreshold, Light.EntityId);
                    TurnOffEntities("Bright", true);
                }
                else if (Light.IsOff() && e.New?.State < _room.IlluminanceLowThreshold 
                     && (TriggerWithoutPresence || TriggerSensors.Union(PresenceSensors).Any(s => s.IsOn())))
                {
                    _logger.LogInformation("Illuminance Sensor {sensor} {state} is below threshold {threshold}, turning on {light}",
                                            e.New.EntityId, e.New.State, _room.IlluminanceLowThreshold, Light.EntityId);
                    TurnOnEntities("Dark");
                }
            });
        }
    }

    private void SubscribeConditionTriggers()
    {
        if (TriggerConditions.Any())
        {
            _logger.LogDebug("Subscribing {light} to Condition State Changes", Light.EntityId);
            foreach (var trigger in TriggerConditions)
            {
                _logger.LogDebug("{Light} Subscribed to {Entity} state for trigger condition {Operator} {State}",
                    Light.EntityId, trigger.Entity.EntityId, trigger.Operator, trigger.State);
                trigger.Entity.StateAllChanges()
                .Subscribe(e =>
                {
                    if (e.New!.ConditionPassed(trigger))
                    {
                        _logger.LogInformation("{light} Condition has been Triggered {Condition} {ConditionState}", Light.EntityId, trigger.Entity.EntityId, trigger.State);
                        TurnOnEntities(e.New?.EntityId);
                    }
                    else
                    {
                        _logger.LogInformation("{light} Condition Trigger removed {Condition} {ConditionState}", Light.EntityId, trigger.Entity.EntityId, trigger.State);
                        TurnOffEntities(e.New?.EntityId);
                    }
                });
            }
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

    // private void SubScribeTurnOffTriggers()
    // {
    //     _logger.LogDebug("{light} Subscribed to Turn Off Trigger Events", Light.EntityId);
    //     TurnOffTriggerEntities.StateAllChanges()
    //     .Where(e => e.New.IsOn())
    //     .WhenStateIsFor(e => e.IsOn(), TimeSpan.FromSeconds(TurnOffTriggerTime), _scheduler)
    //     .Subscribe(e =>
    //     {
    //         _logger.LogTrace("{light} Turn Off Trigger Entity {entity}", Light.EntityId, e.New?.EntityId);
    //         TurnOffEntities(e.New?.EntityId);
    //     });
    // }

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
        // Validate that RoomMode is initialized
        if (_room.RoomMode == null)
        {
            _logger.LogError("RoomMode is not initialized for {light}", Light.EntityId);
            return;
        }

        // If the light is already off, no action is needed.
        if (Light.IsOff())
        {
            _logger.LogTrace("{light} is already off", Light.EntityId);
            return;
        }

        // If the manager is disabled, prevent turning off the light.
        if (ManagerEnabled.IsOff())
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
            return;
        }

        // If the room mode is manual, prevent turning off the light.
        if (_room.RoomMode.IsManual())
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because room mode is {state}", Light.EntityId, trigger, _room.RoomMode?.State);
            return;
        }

        // Skip checks if `force` is true.
        if (!force)
        {
            // Prevent turning off the light if the room mode is in a keep-alive state.
            if (_room.KeepAliveModes.Contains(_room.RoomMode?.State))
            {
                _logger.LogTrace("Can't Turn Off {light} with {trigger}, because room mode is {state}", Light.EntityId, trigger, _room.RoomMode?.State);
                return;
            }

            // Prevent turning off the light if any condition is keeping it on.
            if (Conditions.Any() && Conditions.All(c => c.ConditionPassed()))
            {
                _logger.LogTrace("Can't Turn Off {light} with {trigger}, because condition(s) {Conditions} are keeping it on", Light.EntityId, trigger, Conditions.AsString());
                return;
            }

            // Prevent turning off the light if any keep-alive entity is on.
            if (KeepAliveEntities.Any(b => b.State != null && Extensions.EntityExtensions.OnStates.Contains(b.State)))
            {
                _logger.LogTrace("Can't Turn Off {light} with {trigger}, because keep alive entity is on", Light.EntityId,
                    KeepAliveEntities.Where(b => b.State != null && Extensions.EntityExtensions.OnStates.Contains(b.State)).Select(b => b.EntityId));
                return;
            }

            // Prevent turning off the light if any trigger condition is keeping it on.
            if (TriggerConditions.Any() && TriggerConditions.All(c => c.ConditionPassed()))
            {
                _logger.LogTrace("Can't Turn Off {light} with {trigger}, because trigger condition(s) {Conditions} are keeping it on", Light.EntityId, trigger, TriggerConditions.AsString());
                return;
            }

            // Prevent turning off the light if any presence sensor is on.
            if (PresenceSensors.Any(s => s.IsOn()))
            {
                _logger.LogTrace("{light} is on but there is presence detected, not turning off", Light.EntityId);
                return;
            }
        }

        // Dispose of any existing turn-off action to avoid conflicts.
        if (_turnOffDisposable != null)
        {
            _turnOffDisposable.Dispose();
            _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
        }

        // Calculate the timeout for turning off the light.
        var timeout = force ? 60 : Timeout; // Keep timeout at 60 seconds for forced turn-offs.;
        TurnOffTime = DateTime.Now.AddSeconds(timeout);

        // Log the turn-off action.
        var triggerMsg = force ? $"forced Off by {trigger ?? "UNKNOWN"}" : $"triggered by {trigger ?? "UNKNOWN"}";
        var logMessage = $"{Light.EntityId} Turning Off at {TurnOffTime:G} {triggerMsg}";
        _logger.LogInformation(logMessage);
        UpdateAttributes(logMessage);

        // Schedule the turn-off action.
        _turnOffDisposable = _scheduler.Schedule(TimeSpan.FromSeconds(timeout), () =>
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
        // Validate that RoomMode is initialized
        if (_room.RoomMode == null)
        {
            _logger.LogError("RoomMode is not initialized for {light}", Light.EntityId);
            return;
        }

        // If the light is already on, no action is needed.
        if (Light.IsOn())
        {
            _logger.LogTrace("{light} is already on", Light.EntityId);
            return;
        }

        // If the manager is disabled, prevent turning on the light.
        if (ManagerEnabled.IsOff())
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
            return;
        }

        // If the room mode is in a blocking state, prevent turning on the light.
        if (_room.BlockModes.Contains(_room.RoomMode?.State))
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because room mode is {state}", Light.EntityId, trigger, _room.RoomMode?.State);
            return;
        }

        // Prevent turning on the light if any condition is not met.
        if (Conditions.Any() && Conditions.Any(c => !c.ConditionPassed()))
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because one or more condition is not met {Conditions}",
                Light.EntityId, trigger, Conditions.AsString());
            return;
        }

        // Prevent turning on the light if any blocking entity is on.
        if (BlockEntities.Any(b => b.State != null && Extensions.EntityExtensions.OnStates.Contains(b.State)))
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because block entity {block} is on", Light.EntityId, trigger,
                BlockEntities.Where(b => b.State != null && Extensions.EntityExtensions.OnStates.Contains(b.State)).Select(b => b.EntityId));
            return;
        }

        // Prevent turning on the light if there is no presence detected and triggering without presence is disabled.
        if (!TriggerWithoutPresence && TriggerSensors.Union(PresenceSensors).All(s => !s.IsOn()))
        {
            _logger.LogTrace("Can't turn {light} on as there is no presence detected", Light.EntityId);
            return;
        }

        // Prevent turning on the light if the room is bright and the room mode is not bright.
        if (_room.IsBright && !_room.RoomMode.IsBright())
        {
            _logger.LogTrace("Can't turn {light} on as the room is bright enough", Light.EntityId);
            return;
        }

        // Turn on the light if the conditions are met.
        if (Primary || TriggerWithoutPresence)
        {
            // Dispose of any existing turn-off action to avoid conflicts.
            if (_turnOffDisposable != null)
            {
                _turnOffDisposable.Dispose();
                _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
            }

            Light.TurnOn();
            TurnOnTime = DateTime.Now;

            var triggerMsg = $"triggered by {trigger ?? "UNKNOWN"}";
            var logMessage = $"{Light.EntityId} Turned On at {TurnOnTime:G} at {triggerMsg}";
            _logger.LogInformation(logMessage);
            LogInLogbook(Light, logMessage);
            UpdateAttributes(logMessage);
            WaitAllTasks();
        }
        else
        {            
            var triggerMsg = $"triggered by {trigger ?? "UNKNOWN"}";
            var logMessage = $"{Light.EntityId} We didn't turn on as the light wasn't Primary or TriggerWithoutPresence at {TurnOnTime:G} at {triggerMsg}";
            _logger.LogInformation(logMessage);
            LogInLogbook(Light, logMessage);
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
            RoomMode = _room.RoomMode?.State ?? "N/A",
            BlockModes = _room.BlockModes.Any() ? string.Join(",", _room.BlockModes) : "N/A",
            KeepAliveModes = _room.KeepAliveModes.Any() ? string.Join(",", _room.KeepAliveModes) : "N/A",
            Illuminance = _room.IlluminanceSensor?.State,
            LowLightThreshold = _room.IlluminanceLowThreshold,
            HighLightThreshold = _room.IlluminanceHighThreshold,
            IgnoreIlluminance =_room.IgnoreIlluminance,
            BlockEntities = BlockEntities.Any() ? string.Join(",", BlockEntities.Select(c => c.EntityId)) : "N/A",
            KeepAliveEntities = KeepAliveEntities.Any() ? string.Join(",", KeepAliveEntities.Select(c => c.EntityId)) : "N/A",
            Condition = Conditions.Any() ? Conditions.AsString() : "N/A",
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