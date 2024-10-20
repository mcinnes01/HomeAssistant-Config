// using NetDaemon.Extensions.MqttEntityManager;

// namespace NetDaemon.apps.LightApp;
// #pragma warning disable CS8618 
// public class Roomer
// {
//     public required Area Room { get; set; }
//     public required IEnumerable<BinarySensorEntity> PresenceSensors { get; set; }
//     public required IEnumerable<BinarySensorEntity> TriggerSensors { get; set; }
//     // public required IEnumerable<LightEntity> OtherLights { get; set; }
//     public required IEnumerable<Entity> BlockEntities { get; set; }
//     public required int Timeout { get; set; } = 120;
//     public bool RecreateEnabledSwitch { get; set; } = false;
//     private IMqttEntityManager _entityManager;
//     private IScheduler _scheduler;
//     private IHaContext _context;
//     private Services _services;
//     private ILogger<Lighting> _logger;
//     private readonly List<string> _onStates = new List<string> { "on", "playing" };
//     private string _enabledSwitch = "";
//     private SwitchEntity? ManagerEnabled = null;
//     private List<Task> Tasks { get; } = new List<Task>();
//     private IDisposable? _turnOffDisposable;
//     private DateTime? TurnOnTime { get; set; }
//     private DateTime? TurnOffTime { get; set; }

//     public async Task Register(IMqttEntityManager entityManager, IScheduler scheduler, IHaContext haContext, ILogger<Lighting> logger)
//     {
//         _entityManager = entityManager;
//         _scheduler = scheduler;
//         _context = haContext;
//         _services = new Services(haContext);
//         _logger = logger;
//         await SetupEnabledSwitch();
//         await SetupRoomModeSelect();
//         EnsureInitialState();
//         SubscribePresenceOnEvent();
//         SubscribePresenceOffEvent();
//         SubscribeBlockers();
//     }

//     private void EnsureInitialState()
//     {
//         // TODO we need to bring in the location, room mode, light mode, etc. to determine the initial state
//         // Also things like if the light and tv are left on, should we not turn them off if there is no presence?
//         // The tv could be controlled by it's own thing, maybe even a room manager that then feeds in to this
//         var presenceStates = PresenceSensors.Union(TriggerSensors).Select(s => new { s.EntityId, IsOn = s.IsOn() });
//         if (BlockEntities.All(b => !b.IsOn()))
//         {
//             if (presenceStates.Any(s => s.IsOn))
//             {
//                 if (Light.IsOn())
//                 {
//                     _logger.LogInformation("Initial state prescense detected {states} and {light} is already on", presenceStates, Light.EntityId);
//                     return;
//                 }
//                 _logger.LogInformation("Initial state {light} is off but there is presence detected {states}, Turning On", Light.EntityId, presenceStates);
//                 TurnOnEntities("Initial State");
//                 return;
//             }
//             else if (Light.IsOn())
//             {
//                 _logger.LogInformation("Initial state {light} is on but there is no presence detected {states}, Turning Off", Light.EntityId, presenceStates);
//                 TurnOffEntities("Initial State");
//             }
//         }
//         else
//         {
//             var mutipleLightsOn = BlockEntities.Where(b => b.Domain() == "light").Any(b => b.IsOn()) && Light.IsOn();
//             if (mutipleLightsOn && presenceStates.Any(s => !s.IsOn))
//             {
//                 var lightDetail = mutipleLightsOn  ? $"{Light.EntityId} and other light(s) on" : $"{Light.EntityId} is on";
//                 _logger.LogInformation("Initial state {light} is on but there is presence, Turning Off", lightDetail);
//                  TurnOffEntities("Initial State", mutipleLightsOn);
//                 return;
//             }
//             _logger.LogInformation("Initial state {light} {state}, can't change as {light} is blocked by {blockers}",
//                 Light.EntityId, Light.State, Light.EntityId, BlockEntities.Where(b => b.IsOn()).Select(b => b.EntityId));
//         }
//     }

//     private void SubscribeBlockers()
//     {
//         BlockEntities.StateAllChanges()
//         .Subscribe(e =>
//         {
//             if (e.New.IsOn())
//             {
//                 if (Light.IsOn())
//                 {
//                     _logger.LogInformation("{light} is blocked by {blocker}", Light.EntityId, e.New.EntityId);
//                     TurnOffEntities(e.New?.EntityId);
//                 }
//             }
//             else if (e.Old.IsOn() && !e.New.IsOn())
//             {
//                 if (Light.IsOff() && PresenceSensors.Union(TriggerSensors).Any(s => s.IsOn()))
//                 {
//                     _logger.LogInformation("{light} is unblocked by {blocker} and presence detected", Light.EntityId, e.New.EntityId);
//                     TurnOnEntities(e.New?.EntityId);
//                 }
//                 else if (Light.IsOn() && PresenceSensors.Union(TriggerSensors).All(s => s.IsOff()))
//                 {
//                     _logger.LogInformation("{light} is unblocked by {blocker} and no presence detected", Light.EntityId, e.New.EntityId);
//                     TurnOffEntities(e.New?.EntityId);
//                 }
//             }
//         });
//     }

//     private async Task SetupEnabledSwitch()
//     {
//         _enabledSwitch = $"switch.light_manager_{Light.Name()}".ToLower().ReplaceLineEndings("").Replace(" ", "");
//         _logger.LogDebug("{light} Setup Enabled Switch", Light.EntityId);

//         if (_context.Entity(_enabledSwitch).State != null && RecreateEnabledSwitch)
//         {
//             _logger.LogDebug("{switch} Remove enable switch", _enabledSwitch);
//             await _entityManager.RemoveAsync(_enabledSwitch);
//         }

//         if (_context.Entity(_enabledSwitch).State == null)
//         {
//             await _entityManager.CreateAsync(_enabledSwitch, new EntityCreationOptions(Name: $"Light Manager {Light.EntityId}", DeviceClass: "switch", Persist: true));
//             ManagerEnabled = new SwitchEntity(_context, _enabledSwitch);
//             ManagerEnabled.TurnOn();
//             _logger.LogDebug("{switch} Created Enabled Switch", _enabledSwitch);
//         }

//         if (_enabledSwitch != "switch.light_manager_testroom")
//         {
//             (await _entityManager.PrepareCommandSubscriptionAsync(_enabledSwitch)).SubscribeAsync(async s =>
//                 {
//                     await _entityManager.SetStateAsync(_enabledSwitch, s);
//                     var logMessage = $"{Light.EntityId} Manager Enabled Switch Set to {s}";
//                     _logger.LogDebug(logMessage);
//                     UpdateAttributes(logMessage);
//                 }
//             );
//         }
//     }

//     private async Task SetupRoomModeSelect()
//     {
//         _logger.LogDebug("{room} Setup Room Mode Select", Light.Area);

//         if (_haContext.Entity(_roomModeSelect).State != null)
//         {
//             _logger.LogDebug("{room} Removing Room Mode Select", _roomModeSelect);
//             await _entityManager.RemoveAsync(_roomModeSelect);
//         }

//         // Create the input_select entity
//         await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions(Name: $"{_entityName} Mode", DeviceClass: "input_select", Persist: true));
//         RoomMode = new InputSelectEntity(_haContext, _roomModeSelect);

//         // Set the options for the input_select entity
//         if (IsBedroom)
//             RoomMode.SetOptions(EnumExtensions.ToOptions<BedroomModeOptions>());
//         else if (_entityName.Equals("lounge"))
//             RoomMode.SetOptions(EnumExtensions.ToOptions<LoungeModeOptions>());
//         else if (_entityName.Equals("snug"))
//             RoomMode.SetOptions(EnumExtensions.ToOptions<SnugModeOptions>());
//         else
//             RoomMode.SetOptions(EnumExtensions.ToOptions<RoomModeOptions>());

//         // Set the default value to "Normal"
//         RoomMode.SelectOption(RoomModeOptions.Normal);

//         if (_roomModeSelect != "input_select.testroom_mode")
//         {
//             // This creates a subscription just to output the state of the entity
//             (await _entityManager.PrepareCommandSubscriptionAsync(RoomMode.EntityId)).SubscribeAsync(async s =>
//                 {
//                     _logger.LogDebug("{room} Changing Room Mode", RoomMode.EntityId);
//                     await _entityManager.SetStateAsync(RoomMode.EntityId, s);
//                     _logger.LogDebug("{room} Changed Room Mode {state}", RoomMode.EntityId, s);
//                 }
//             );
//         }

//         _logger.LogDebug("{room} Subscribed to Room Mode Changed Events", _entityName);
//         RoomMode?.StateChanges().Subscribe(room =>
//         {
//             if (AllLightEntitiesAreOff)
//             {
//                 UpdateAttributes();
//                 WaitAllTasks();
//                 return;
//             }

//             _logger.LogDebug("{room} Control Entities On: {entities}", _entityName, AllLightEntities.Select(e => e.EntityId));
//             TurnOffEntities("Room Mode Change", true);

//             _scheduler.Schedule(TimeSpan.FromMilliseconds(250), (_, _) =>
//             {
//                 TurnOnEntities("Room Mode Change", true);
//                 UpdateAttributes();
//             });

//             WaitAllTasks();
//         });
//     }

//     private void SubscribePresenceOnEvent()
//     {
//         _logger.LogDebug("{light} Subscribed to Presence On Events", Light.EntityId);
//         PresenceSensors.StateAllChanges()
//         .Merge(TriggerSensors.StateAllChanges())
//         .Where(e => e.New.IsOn())
//         .Subscribe(e =>
//         {
//             _logger.LogTrace("{light} Presence On Event {entity}", Light.EntityId, e.New?.EntityId);
//             TurnOnEntities(e.New?.EntityId);
//         });
//     }
    
//     private void SubscribePresenceOffEvent()
//     {
//         _logger.LogDebug("{light} Subscribed to Presence Off Events", Light.EntityId);

//         PresenceSensors.StateAllChanges()
//         .Merge(TriggerSensors.StateAllChanges())
//         .Where(_ => PresenceSensors.Union(TriggerSensors).All(s => !s.IsOff()))
//         .Subscribe(e =>
//         {
//             var states = PresenceSensors.Union(TriggerSensors).Select(s => new { s.EntityId, s.State });
//             _logger.LogTrace("{light} Presence Off Event {entity} {states}", Light.EntityId, e.New?.EntityId, states);
//             TurnOffEntities(e.New?.EntityId);
//         });
//     }

//     private void TurnOffEntities(string? trigger = null, bool force = false)
//     {
//         if (_turnOffDisposable != null)
//         {
//             _turnOffDisposable.Dispose();
//             _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
//         }
//         if (ManagerEnabled.IsOff())
//         {
//             _logger.LogTrace("Can't Turn Off {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
//             return;
//         }
//         if (!force && BlockEntities.Any(b => b.State != null && _onStates.Contains(b.State)))
//         {
//             _logger.LogTrace("Can't Turn Off {light} with {trigger}, because block entity is on", Light.EntityId,
//                 BlockEntities.Where(b => b.State != null && _onStates.Contains(b.State)).Select(b => b.EntityId));
//             return;
//         }
//         if (Light.IsOff())
//         {
//             _logger.LogTrace("{light} is already off", Light.EntityId);
//             return;
//         }

//         TurnOffTime = DateTime.Now.AddSeconds(Timeout);
//         var triggerMsg = force ? $"forced Off by {trigger ?? "UNKNOWN"}" : $"triggered by {trigger ?? "UNKNOWN"}";
//         var logMessage = $"{Light.EntityId} Turning Off at {TurnOffTime:G} {triggerMsg}";
//         _logger.LogInformation(logMessage);
//         UpdateAttributes(logMessage);

//         _turnOffDisposable = _scheduler.Schedule(TimeSpan.FromSeconds(Timeout), () =>
//         {
//             Light.TurnOff();
//             logMessage = $"{Light.EntityId} Turned Off at {TurnOffTime:G} {triggerMsg}";
//             _logger.LogInformation(logMessage);
//             LogInLogbook(Light, logMessage);
//             UpdateAttributes(logMessage);
//             WaitAllTasks();
//         });
//     }

//     private void TurnOnEntities(string? trigger)
//     {
//         if (_turnOffDisposable != null)
//         {
//             _turnOffDisposable.Dispose();
//             _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
//         }
//         if (ManagerEnabled.IsOff())
//         {
//             _logger.LogTrace("Can't Turn On {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
//             return;
//         }
//         if (BlockEntities.Any(b => b.State != null && _onStates.Contains(b.State)))
//         {
//             _logger.LogTrace("Can't Turn On {light} with {trigger}, because block entity is on", Light.EntityId,
//                 BlockEntities.Where(b => b.State != null && _onStates.Contains(b.State)).Select(b => b.EntityId));
//             return;
//         }
//         if (Light.IsOn())
//         {
//             _logger.LogTrace("{light} is already on", Light.EntityId);
//             return;
//         }

//         TurnOnTime = DateTime.Now;
//         var triggerMsg = $"triggered by {trigger ?? "UNKNOWN"}";
//         var logMessage = $"{Light.EntityId} Turned On at {TurnOnTime:G} at {triggerMsg}";
//         _logger.LogInformation(logMessage);
//         Light.TurnOn();
//         LogInLogbook(Light, logMessage);
//         UpdateAttributes(logMessage);
//         WaitAllTasks();
//     }

//     private void UpdateAttributes(string? logMessage = null)
//     {
//         var attributes = new
//         {
//             TurnOnTime,
//             TurnOffTime,
//             IsTurningOff = TurnOffTime > DateTime.Now,
//             Light.State,
//             Details = logMessage,
//             LastUpdated = DateTime.Now.ToString("G")
//         };
//         Tasks.Add(_entityManager.SetAttributesAsync(_enabledSwitch, attributes));
//         _logger.LogTrace("{light} Attributes updated to {attr}", Light.EntityId, attributes);
//     }

//     private void LogInLogbook(Entity entity, string logMessage)
//     {
//         Tasks.Add(Task.Run(() =>
//             _services.Logbook.Log(
//                 entityId: entity.EntityId,
//                 message: logMessage,
//                 name: entity.EntityId,
//                 domain: "light")
//         ));
//     }

//     private void WaitAllTasks()
//     {
//         Task.WaitAll(Tasks.ToArray());
//     }
// }