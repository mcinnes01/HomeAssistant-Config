// using System.Reactive.Disposables;
// using NetDaemon.Extensions.MqttEntityManager;

// #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

// namespace NetDaemon.apps.LightApp;

// public class LightControl
// {
//     public string Name { get; set; } = "";
//     public SwitchEntity ManagerEnabled { get; set; }
//     public InputSelectEntity? RoomMode { get; set; }
//     public bool IsBedroom { get; set; }
//     public bool IsLamp { get; set; }

//     private string _entityName;
//     private string _roomModeSelect;
//     private string _enabledSwitch;
//     private IMqttEntityManager _entityManager;
//     private int _guardTimeout;
//     private IHaContext _haContext;
//     private ILogger<Manager> _logger;
//     private string _ndUserId;
//     private bool _overrideActive;
//     private IScheduler _scheduler;
//     private Services _services;
//     private Entities _entities;
//     private InputSelectEntity _locationMode;
//     private InputSelectEntity _lightControlMode;

//     public async Task Init(ILogger<Manager> logger, string ndUserId,
//     IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager, int guardTimeout)
//     {
//         _logger = logger;
//         _ndUserId = ndUserId;
//         _scheduler = scheduler;
//         _haContext = haContext;
//         _entityManager = entityManager;
//         _entityName = Name.ToLower().Replace("_", " ");
//         _roomModeSelect = RoomMode?.EntityId ?? $"input_select.{Name.ToLower()}_mode";
//         _enabledSwitch = $"switch.light_manager_{Name.ToLower()}";
//         _guardTimeout = guardTimeout;
//         _services = new Services(haContext);
//         _entities = new Entities(haContext);
//         _locationMode = _entities.InputSelect.LocationMode;
//         _lightControlMode = _entities.InputSelect.LightControlMode;
//         _logger.LogInformation("Setup {room}", _entityName);
//         await SetupRoomModeSelect();
//         await SetupEnabledSwitch();
//         SubscribePresenceOnEvent();
//         SubscribePresenceOffEvent();
//         SubscribeOverrideEvent();
//         SubscribeManualTurnOnOverrideEvent();
//         SubscribeManualTurnOffOverrideEvent();
//         SubscribeHouseModeEvent();
//         SubscribeGuard();
//     }

//     // Any action through HA i.e. alexa or mqtt switches will show as ND
//     private bool IsNdUserOrHa(StateChange stateChange)
//     {
//         var state = stateChange.New?.Context?.UserId == null || stateChange.New?.Context?.UserId == _ndUserId;
//         _logger.LogDebug("{entity} turned {action} {by} using user {user}",
//             stateChange.Entity.EntityId,
//             stateChange.Entity.State,
//             state ? "manually" : "automatically",
//             stateChange.New?.Context?.UserId);
//         return state;
//     }

//     private bool LightAttributesOverride(StateChange<LightEntity, EntityState<LightAttributes>> e) =>
//         !IsNdUserOrHa(e) &&
//         e.Old.IsOn() && e.New.IsOn()
//         && (!Equals(e.Old?.Attributes?.Brightness, e.New?.Attributes?.Brightness)
//          || !Equals(e.Old?.Attributes?.ColorTemp, e.New?.Attributes?.ColorTemp));

//     private bool LightTurnedOffManually(StateChange<LightEntity, EntityState<LightAttributes>> e) =>
//         !IsNdUserOrHa(e) && e.Old.IsOn() && e.New.IsOff();

//     private bool LightTurnedOnManually(StateChange<LightEntity, EntityState<LightAttributes>> e) =>
//         !IsNdUserOrHa(e) && e.Old.IsOff() && e.New.IsOn();



//     private async Task SetupEnabledSwitch()
//     {
//         _logger.LogDebug("{room} Setup Enabled Switch", _entityName);

//         if (_haContext.Entity(_enabledSwitch).State == null
//         || string.Equals(_haContext.Entity(_enabledSwitch).State, "unavailable", StringComparison.InvariantCultureIgnoreCase))
//         {
//             await _entityManager.CreateAsync(_enabledSwitch, new EntityCreationOptions(Name: $"Light Manager {_entityName}", DeviceClass: "switch", Persist: true));
//         }

//         ManagerEnabled = new SwitchEntity(_haContext, _enabledSwitch);
//         ManagerEnabled.TurnOn();

//         if (_enabledSwitch != "switch.light_manager_testroom")
//         {
//             (await _entityManager.PrepareCommandSubscriptionAsync(_enabledSwitch)).SubscribeAsync(async s =>
//                 {
//                     _logger.LogDebug("{room} Changing Enabled Switch", _entityName);
//                     await _entityManager.SetStateAsync(_enabledSwitch, s);
//                     _logger.LogDebug("{room} Enabled Switch Set to {state}", _entityName, s);
//                 }
//             );
//         }
//     }

//     private async Task SetupRoomModeSelect()
//     {
//         if (RoomMode != null)
//             return;

//         _logger.LogDebug("{room} Setup Room Mode Select", _entityName);

//         if (_haContext.Entity(_roomModeSelect).State == null
//             || string.Equals(_haContext.Entity(_roomModeSelect).State, "unavailable", StringComparison.InvariantCultureIgnoreCase))
//         {
//             // Create the input_select entity
//             await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions(Name: $"{_entityName} Mode", DeviceClass: "input_select", Persist: true));

//             RoomMode = new InputSelectEntity(_haContext, _roomModeSelect);

//             // Set the options for the input_select entity
//             if (IsBedroom)
//                 RoomMode.SetOptions(EnumExtensions.ToOptions<BedroomModeOptions>());
//             else
//                 RoomMode.SetOptions(EnumExtensions.ToOptions<RoomModeOptions>());

//             // Set the default value to "Normal"
//             RoomMode.SelectOption(RoomModeOptions.Normal);
//         }
//         else if (RoomMode == null)
//         {
//             RoomMode = new InputSelectEntity(_haContext, _roomModeSelect);
//         }

//         if (_roomModeSelect != "input_select.testroom_mode")
//         {
//             // This creates a subscription just to output the state of the entity
//             (await _entityManager.PrepareCommandSubscriptionAsync(RoomMode.EntityId)).SubscribeAsync(async s =>
//                 {
//                     _logger.LogDebug("{room} Changing Bedroom Mode", RoomMode.EntityId);
//                     await _entityManager.SetStateAsync(RoomMode.EntityId, s);
//                     _logger.LogDebug("{room} Changed Bedroom Mode {state}", RoomMode.EntityId, s);
//                 }
//             );
//         }
//     }

//     private void SubscribeGuard()
//     {
//         if (!Watchdog)
//         {
//             _logger.LogDebug("{room} Watchdog Disabled", _entityName);
//             return;
//         }

//         _logger.LogDebug("{room} Subscribed to Watchdog Schedule", _entityName);
//         var totalMinutes = (int)TimeSpan.FromSeconds(_guardTimeout).TotalMinutes;

//         _scheduler.ScheduleCron($"*/{totalMinutes} * * * *", () =>
//         {
//             if (RoomState == "on" || _overrideActive || AllLightEntities.All(e => e.IsOff())) return;
//             _logger.LogDebug("{room} Watchdog turning off entities", _entityName);
//             TurnOffEntities($"Watchdog ({_entityName})");
//             WaitAllTasks();
//         });
//     }

//     private void SubscribeHouseModeEvent()
//     {
//         // TODO: this needs to use the master bedroom to control the house state as it does now
//         // however if locationMode is guest and IsBedroom, then we don't change the room state for that room
//         // we can do some presence stuff too possible i.e. guest mode and occupied room.
//         // if it gets to 11am and house mode has changed from sleeping we should set to normal from sleeping too.

//         _lightControlMode.StateChanges().Subscribe(l =>
//         {
//             _logger.LogInformation("Light Control Mode Changed");

//             // This sets other bedrooms mode when the house state changed
//             // If guest mode is set then these remain independant
//             // TODO: We could encorporate presence to identify which bedrooms are in use 
//             // allowing us to set the state in unused bedrooms. May also need some overall
//             // cut off if the state is never set. Also we could use a presence with light off
//             // to signify sleep
//             if (IsBedroom && !IsMasterBedroom && _locationMode.IsOneOrBothHome())
//             {
//                 if (!l.Old.IsSleeping() && l.New.IsSleeping()) RoomMode!.Sleeping();

//                 if (l.Old.IsSleeping() && l.New.IsMotion()) RoomMode!.Normal();
//             }

//             // This sets the master bedroom mode when the house enters sleeping and we are away
//             if (IsMasterBedroom && !_locationMode.IsOneOrBothHome())
//             {
//                 if (!l.Old.IsSleeping() && l.New.IsSleeping()) RoomMode!.Sleeping();

//                 if (l.Old.IsSleeping() && l.New.IsMotion()) RoomMode!.Normal();
//             }
//         });

//         _logger.LogDebug("{room} Subscribed to House Mode Changed Events", _entityName);
//         RoomMode?.StateChanges().Subscribe(room =>
//         {
//             if (AllLightEntitiesAreOff)
//             {
//                 UpdateAttributes();
//                 WaitAllTasks();
//                 return;
//             }

//             _logger.LogDebug("{room} Control Entities On: {entities}", _entityName, AllLightEntities.Select(e => e.EntityId));
//             TurnOffEntities("House Mode Change", true);

//             _scheduler.Schedule(TimeSpan.FromMilliseconds(250), (_, _) =>
//             {
//                 TurnOnEntities("House Mode Change", true);
//                 UpdateAttributes();
//             });

//             WaitAllTasks();
//         });
//     }

//     private void SubscribeManualTurnOffOverrideEvent()
//     {
//         _logger.LogDebug("{room} Subscribed to Manual Turn Off Override Events", _entityName);
//         AllLightEntities
//             .StateAllChanges()
//             .Where(LightTurnedOffManually)
//             .Subscribe(_ =>
//             {
//                 _logger.LogInformation("{room} Manual Turn Off Override by user", _entityName);

//                 if (AllLightEntities.Any(e => e.IsOn()))
//                 {
//                     _logger.LogInformation("{room} Override active as some control entities are on", _entityName);
//                     return;
//                 }

//                 _logger.LogInformation("{room} Override reset as all control entities are off", _entityName);
//                 _overrideActive = false;
//                 _overrideSchedule.Dispose();
//                 UpdateAttributes();
//                 WaitAllTasks();
//             });
//     }

//     private void SubscribeManualTurnOnOverrideEvent()
//     {
//         _logger.LogDebug("{room} Subscribed to Manual Turn On Override Events", _entityName);
//         AllLightEntities
//             .StateAllChanges()
//             .Where(LightTurnedOnManually)
//             .Subscribe(e =>
//             {
//                 _logger.LogInformation("{room} Manual Turn On Override for {light} by user", _entityName, e.New?.EntityId);
//                 LogInLogbook(e.New?.EntityId ?? "UNKNOWN", "Override Triggered");
//                 ResetOverride();
//                 UpdateAttributes(true);
//                 WaitAllTasks();
//             });
//     }

//     private void SubscribeOverrideEvent()
//     {
//         _logger.LogDebug("{room} Subscribed to Attribute Override Events", _entityName);
//         AllLightEntities
//             .StateAllChanges()
//             .Where(LightAttributesOverride)
//             .Subscribe(e =>
//             {
//                 _logger.LogInformation("{room} Attribute Override by user", _entityName);
//                 LogInLogbook(e.New?.EntityId ?? "UNKNOWN", "Override Triggered");
//                 ResetOverride();
//                 UpdateAttributes();
//                 WaitAllTasks();
//             });
//     }

//     private void SubscribePresenceOffEvent()
//     {
//         _logger.LogDebug("{room} Subscribed to Presence Off Events", _entityName);
//         var entities = PresenceEntities.Union(KeepAliveEntities);

//         entities
//             .StateChanges()
//             .Throttle(_ => Observable.Timer(DynamicTimeout, _scheduler))
//             .Where(e => e.New.IsOff() && entities.All(e => e.IsOff()))
//             .Subscribe(e =>
//             {
//                 _logger.LogInformation("{room} No Motion Timeout '{entity}' states: {@Entities}",
//                     _entityName, e.New?.EntityId, entities.Select(e => new {e.EntityId, e.State}));

//                 if (_overrideActive)
//                 {
//                     _logger.LogInformation("{room} Not turning off - Override active ", _entityName);
//                     return;
//                 }

//                 TurnOffEntities(e.New?.EntityId);
//                 UpdateAttributes(true);
//                 WaitAllTasks();
//             });

//         entities
//             .StateChanges()
//             .Where(e => e.New.IsOff())
//             .Subscribe(e =>
//             {
//                 _logger.LogInformation("{room} No Motion '{entity}'", _entityName, e.New?.EntityId);
//                 UpdateAttributes(true);
//                 WaitAllTasks();
//             });
//     }

//     private void SubscribePresenceOnEvent()
//     {
//         _logger.LogDebug("{room} Subscribed to Presence On Events", _entityName);
//         PresenceEntities.StateAllChanges()
//             .Where(e => e.New.IsOn())
//             .Subscribe(e =>
//             {
//                 _logger.LogInformation("{room} Motion '{entity}'", _entityName, e.New?.EntityId);

//                 if (_overrideActive)
//                 {
//                     _logger.LogInformation("{room} Not turning on - resetting Override timeout", _entityName);
//                     ResetOverride();
//                     WaitAllTasks();
//                     return;
//                 }

//                 TurnOnEntities(e.New?.EntityId);
//                 UpdateAttributes();
//                 WaitAllTasks();
//             });
//     }

//     private void TurnOffEntities(string? trigger, bool ignoreConditions = false)
//     {
//         if (ManagerEnabled.IsOff())
//         {
//             _logger.LogInformation("{room} Manager Disabled", _entityName);
//             return;
//         }

//         if (!ignoreConditions && IsOccupied)
//         {
//             _logger.LogInformation("{room} Cant turn off - Occupied", _entityName);
//             return;
//         }

//         if (!ignoreConditions && ConditionEntityStateNotMet)
//         {
//             _logger.LogInformation("{room} Cant turn off - Condition not met {conditionEntity}!={state}", _entityName, ConditionEntity?.EntityId, ConditionEntityState);
//             return;
//         }

//         var triggerMsg = $"Turned off by {trigger ?? "UNKNOWN"}";
//         _logger.LogInformation("{room} Turn Off by {trigger}", _entityName, triggerMsg);
//         foreach (var e in AllLightEntities.ToList())
//         {
//             _logger.LogDebug("{room} Turning Off {light} ", _entityName, e.EntityId);
//             e.TurnOff();

//             LogInLogbook(e, triggerMsg);
//         }

//         RoomState = "off";
//     }

//     private void TurnOnEntities(string? trigger, bool ignoreConditions = false)
//     {
//         List<LightEntity> lightEntities;

//         if (ManagerEnabled.IsOff())
//         {
//             _logger.LogInformation("{room} Manager Disabled", _entityName);
//             return;
//         }

//         if (!ignoreConditions && ConditionEntityStateNotMet)
//         {
//             _logger.LogInformation("{room} Condition not met {conditionEntity}!={state}", _entityName, ConditionEntity?.EntityId, ConditionEntityState);
//             return;
//         }

//         if (!ignoreConditions && IsTooBright)
//         {
//             _logger.LogInformation("{room} Too Bright", _entityName);
//             return;
//         }

//         if (SupressionEntities.Any(s => s.BoolState()))
//         {
//             _logger.LogInformation("Light is being supressed by another entity");
//             return;
//         }

//         if (IsNightMode)
//         {
//             _logger.LogDebug("{room} Turn On Night Control Entities", _entityName);
//             lightEntities = NightLightEntities.ToList();
//         }
//         else
//         {
//             _logger.LogDebug("{room} Turn On Control Entities", _entityName);
//             lightEntities = LightEntities.ToList();
//         }

//         foreach (var e in lightEntities.Where(l => l.IsOff()))
//         {
//             _logger.LogInformation("{room} Turning On {light}", _entityName, e.EntityId);
//             e.TurnOn();
//             LogInLogbook(e, $"Turned on by {trigger ?? "UNKNOWN"}");
//         }

//         RoomState = "on";
//     }

//     private void UpdateAttributes(bool showTurningOff = false)
//     {
//         var attributes = new
//         {
//             OverrideActive = _overrideActive,
//             TurningOff = showTurningOff ? (_scheduler.Now + DynamicTimeout).ToString() : "Unknown",
//             DynamicTimeout,
//             IsOccupied,
//             IsTooBright,
//             ConditionEntityStateMet = ConditionEntity?.EntityId == null ? "N/A" : ConditionEntityStateNotMet.ToString(),
//             ConditionEntity = ConditionEntity?.EntityId ?? "N/A",
//             ConditionEntityState = ConditionEntityState ?? "N/A",
//             LastUpdated = DateTime.Now.ToString("G")
//         };
//         Tasks.Add(_entityManager.SetAttributesAsync(_enabledSwitch, attributes));
//         _logger.LogTrace("{room} Attributes updated to {attr}", _entityName, attributes);
//     }

//     private void LogInLogbook(Entity entity, string triggerMsg)
//     {
//         Tasks.Add(Task.Run(() =>
//             _services.Logbook.Log(
//                 entityId: entity.EntityId,
//                 message: triggerMsg,
//                 name: entity.EntityId,
//                 domain: "light")
//         ));
//     }

//     private void LogInLogbook(string entityId, string triggerMsg)
//     {
//         Tasks.Add(Task.Run(() =>
//             _services.Logbook.Log(
//                 entityId: entityId,
//                 message: triggerMsg,
//                 name: entityId,
//                 domain: "light")
//         ));
//     }

//     private void WaitAllTasks()
//     {
//         Task.WaitAll(Tasks.ToArray());
//     }
// }