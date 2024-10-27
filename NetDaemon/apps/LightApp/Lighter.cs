using System.Reactive;
using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;
#pragma warning disable CS8618 
public class Lighter
{
    public required LightEntity Light { get; set; }
    public IEnumerable<BinarySensorEntity> PresenceSensors { get; set; } = new List<BinarySensorEntity>();
    public IEnumerable<BinarySensorEntity> TriggerSensors { get; set; }  = new List<BinarySensorEntity>();
    public IEnumerable<Entity> BlockEntities { get; set; } = new List<Entity>();
    public required int Timeout { get; set; } = 120;
    public bool RecreateEnabledSwitch { get; set; } = false;
    public required int Priority { get; set; } = 0;
    private LightCoordinator _lightCoordinator;
    private IMqttEntityManager _entityManager;
    private IScheduler _scheduler;
    private IHaContext _context;
    private Services _services;
    private ILogger<Lighting> _logger;
    private readonly List<string> _onStates = new List<string> { "on", "playing" };
    private string _enabledSwitch = "";
    private SwitchEntity? ManagerEnabled = null;
    private List<Task> Tasks { get; } = new List<Task>();
    private IDisposable? _turnOffDisposable;
    private DateTime? TurnOnTime { get; set; }
    private DateTime? TurnOffTime { get; set; }

    public async Task Register(LightCoordinator lightCoordinator, IMqttEntityManager entityManager,
        IScheduler scheduler, IHaContext haContext, ILogger<Lighting> logger)
    {
        _lightCoordinator = lightCoordinator;
        _entityManager = entityManager;
        _scheduler = scheduler;
        _context = haContext;
        _services = new Services(haContext);
        _logger = logger;
        await SetupEnabledSwitch();
        await EnsureInitialState();
        SubscribePresenceOnEvent();
        SubscribePresenceOffEvent();
        SubscribeBlockers();
    }

    public void SetPriority(int priority)
    {
        Priority = priority;
    }

    private async Task EnsureInitialState()
    {
        // TODO we need to bring in the location, room mode, light mode, etc. to determine the initial state
        // Also things like if the light and tv are left on, should we not turn them off if there is no presence?
        // The tv could be controlled by it's own thing, maybe even a room manager that then feeds in to this
        var presenceStates = TriggerSensors.Union(PresenceSensors).Select(s => new { s.EntityId, IsOn = s.IsOn() });
        if (BlockEntities.All(b => !b.IsOn()))
        {
            if (presenceStates.Any(s => s.IsOn))
            {
                if (Light.IsOn())
                {
                    _logger.LogInformation("Initial state prescense detected {states} and {light} is already on", presenceStates, Light.EntityId);
                    return;
                }
                _logger.LogInformation("Initial state {light} is off but there is presence detected {states}, Turning On", Light.EntityId, presenceStates);
                await TurnOnEntities("Initial State");
                return;
            }
            else if (Light.IsOn())
            {
                _logger.LogInformation("Initial state {light} is on but there is no presence detected {states}, Turning Off", Light.EntityId, presenceStates);
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

    private void SubscribeBlockers()
    {
        BlockEntities.StateAllChanges()
        .SelectMany(async e =>
        {
            if (e.New.IsOn())
            {
                if (Light.IsOn())
                {
                    _logger.LogInformation("{light} is blocked by {blocker}", Light.EntityId, e.New.EntityId);
                    TurnOffEntities(e.New?.EntityId);
                }
            }
            else if (e.Old.IsOn() && !e.New.IsOn())
            {
                if (Light.IsOff() && TriggerSensors.Union(PresenceSensors).Any(s => s.IsOn()))
                {
                    _logger.LogInformation("{light} is unblocked by {blocker} and presence detected", Light.EntityId, e.New.EntityId);
                    await TurnOnEntities(e.New?.EntityId);
                }
                else if (Light.IsOn() && TriggerSensors.Union(PresenceSensors).All(s => s.IsOff()))
                {
                    _logger.LogInformation("{light} is unblocked by {blocker} and no presence detected", Light.EntityId, e.New.EntityId);
                    TurnOffEntities(e.New?.EntityId);
                }
            }
            return Unit.Default;
        })
        .Subscribe();
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
        .SelectMany(async e =>
        {
            _logger.LogTrace("{light} Presence On Event {entity}", Light.EntityId, e.New?.EntityId);
            await TurnOnEntities(e.New?.EntityId);
            return Unit.Default;
        })
        .Subscribe();
    }
    
    private void SubscribePresenceOffEvent()
    {
        _logger.LogDebug("{light} Subscribed to Presence Off Events", Light.EntityId);

        PresenceSensors.StateAllChanges()
        .Merge(TriggerSensors.StateAllChanges())
        .Where(_ => TriggerSensors.Union(PresenceSensors).All(s => !s.IsOff()))
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
        if (ManagerEnabled.IsOff())
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
            return;
        }
        if (!force && BlockEntities.Any(b => b.State != null && _onStates.Contains(b.State)))
        {
            _logger.LogTrace("Can't Turn Off {light} with {trigger}, because block entity is on", Light.EntityId,
                BlockEntities.Where(b => b.State != null && _onStates.Contains(b.State)).Select(b => b.EntityId));
            return;
        }
        if (Light.IsOff())
        {
            _logger.LogTrace("{light} is already off", Light.EntityId);
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

    private async Task TurnOnEntities(string? trigger)
    {
        // Delay the turn on based on the priority this just ensures only the light(s) we want come on.
        var priorityDelay = Priority * 0.5; // seconds
        if (priorityDelay > 0)
        {
            await Task.Delay(TimeSpan.FromSeconds(priorityDelay));
        }
        if (_turnOffDisposable != null)
        {
            _turnOffDisposable.Dispose();
            _logger.LogTrace("Dispose Turn Off Event for {light}", Light.EntityId);
        }
        if (ManagerEnabled.IsOff())
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because manager is disabled", Light.EntityId, trigger);
            return;
        }
        if (BlockEntities.Any(b => b.State != null && _onStates.Contains(b.State)))
        {
            _logger.LogTrace("Can't Turn On {light} with {trigger}, because block entity is on", Light.EntityId,
                BlockEntities.Where(b => b.State != null && _onStates.Contains(b.State)).Select(b => b.EntityId));
            return;
        }
        if (Light.IsOn())
        {
            _logger.LogTrace("{light} is already on", Light.EntityId);
            return;
        }

        TurnOnTime = DateTime.Now;
        var triggerMsg = $"triggered by {trigger ?? "UNKNOWN"}";
        var logMessage = $"{Light.EntityId} Turned On at {TurnOnTime:G} at {triggerMsg}";
        _logger.LogInformation(logMessage);
        Light.TurnOn();
        LogInLogbook(Light, logMessage);
        UpdateAttributes(logMessage);
        WaitAllTasks();
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