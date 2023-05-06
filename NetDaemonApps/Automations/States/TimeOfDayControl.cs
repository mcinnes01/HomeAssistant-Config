[NetDaemonApp]
public class TimeOfDayControlApp
{
    private readonly Entities _entities;
    private readonly IHaContext _haContext;
    private readonly ILogger<TimeOfDayControlApp> _logger;

    private readonly InputSelectEntity _timeOfDay;
    private readonly InputBooleanEntity _inBed;
    private readonly SunEntity _sun;
    private readonly InputBooleanEntity _enabled;
    private TimeOfDayOptions _currentTimeOfDay;
    private StateMachine<TimeOfDayOptions, Trigger> _stateMachine;

    public TimeOfDayControlApp(IHaContext haContext, ILogger<TimeOfDayControlApp> logger)
    {
        _haContext = haContext;
        _entities = new Entities(haContext);
        _logger = logger;

        _timeOfDay = _entities.InputSelect.TimeOfDay;
        _inBed = _entities.InputBoolean.InBed;
        _sun = _entities.Sun.Sun;
        _enabled = _entities.InputBoolean.TimeOfDayEnabled;
        SetTimeOfDay();
        InitializeStateMachine();
        SubscribeToSunEvents();
        SubscribeToEnabledEvents();
        SubscribeToInBedEvents();
    }

    private void InitializeStateMachine()
    {
        _timeOfDay.SelectOption(_currentTimeOfDay);
        _stateMachine = new StateMachine<TimeOfDayOptions, Trigger>(_currentTimeOfDay);
        _stateMachine.Configure(TimeOfDayOptions.Morning)
            .Permit(Trigger.TimeOfDay, TimeOfDayOptions.Day)
            .Permit(Trigger.OutOfBed, TimeOfDayOptions.Day);
        _stateMachine.Configure(TimeOfDayOptions.Day)
            .Permit(Trigger.TimeOfDay, TimeOfDayOptions.Afternoon);
        _stateMachine.Configure(TimeOfDayOptions.Afternoon)
            .Permit(Trigger.TimeOfDay, TimeOfDayOptions.Evening);
        _stateMachine.Configure(TimeOfDayOptions.Evening)
            .Permit(Trigger.TimeOfDay, TimeOfDayOptions.Night)
            .Permit(Trigger.InBed, TimeOfDayOptions.Night);
        _stateMachine.Configure(TimeOfDayOptions.Night)
            .Permit(Trigger.TimeOfDay, TimeOfDayOptions.Morning);
        _stateMachine.OnTransitionCompleted(t =>
        {
            _logger.LogDebug("{Trigger} transitioning to {From} from {To}.",
                new { Trigger = t.Trigger.ToString(), From = _timeOfDay.State,
                      To = t.Destination.ToString(), Entity = _timeOfDay });
            _timeOfDay.SelectOption(t.Destination);
        });
        _stateMachine.OnUnhandledTrigger((state, trigger) =>
        {
            _logger.LogWarning("Unhandled transition for {Trigger}, from: {From} to {To}.",
                new { Trigger = trigger.ToString(), From = _timeOfDay.State,
                      To = state.ToString(), Entity = _timeOfDay });
        });
    }

    private void SubscribeToSunEvents()
    {
        _sun.StateAllChanges()
        .Where(e => (e.Entity.Attributes?.NextDawn != null
            || e.Entity.Attributes?.NextDusk != null
            || e.Entity.Attributes?.NextNoon != null)
            && _enabled.IsOn())
        .Throttle(TimeSpan.FromMinutes(5))
        .Subscribe(_ =>
        {
            _logger.LogDebug("Sun Event current time: {Time}",
                new { Time = _currentTimeOfDay, Entity = _timeOfDay });
            if (SetTimeOfDay())
                _stateMachine.Fire(Trigger.TimeOfDay);
        });
    }

    private void SubscribeToEnabledEvents()
    {
        _enabled.StateChanges()
        .Where(e => e.New.IsOn())
        .Subscribe(_ =>
        {
            _logger.LogDebug("Initialized Event current time: {Time}",
                new { Time = _currentTimeOfDay, Entity = _timeOfDay });
            if (SetTimeOfDay())
                _stateMachine.Fire(Trigger.TimeOfDay);
        });
    }

    private void SubscribeToInBedEvents()
    {
        _inBed.StateChanges()
        .Where(_ => _enabled.IsOn())
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(inBed =>
        {
            // Check if InBed has changed to false in the morning and set time of day to Day
            if (_timeOfDay.IsOption(TimeOfDayOptions.Morning) && inBed.New.IsOff())
            {
                _currentTimeOfDay = TimeOfDayOptions.Day;
                _logger.LogDebug("OutOfBed Event current time: {Time}",
                    new { Time = _currentTimeOfDay, Entity = _timeOfDay });
                _stateMachine.Fire(Trigger.OutOfBed);
            }
            // Check if InBed has changed to true after 8pm and set time of day to Night
            else if (_timeOfDay.IsOption(TimeOfDayOptions.Evening) && inBed.New.IsOn()
                && TimeOnly.FromDateTime(DateTime.Now) > Constants.NIGHT_START)
            {
                _currentTimeOfDay = TimeOfDayOptions.Night;
                _logger.LogDebug("InBed Event current time: {Time}",
                    new { Time = _currentTimeOfDay, Entity = _timeOfDay });
                _stateMachine.Fire(Trigger.InBed);
            }
        });
    }

    private bool SetTimeOfDay()
    {
        var currentTime = DateTime.Now;
        var nextDawn = new DateTime();
        var nextNoon = new DateTime();
        var nextDusk = new DateTime();
        if(!DateTime.TryParse(_sun.Attributes?.NextDawn, out nextDawn)
        || !DateTime.TryParse(_sun.Attributes?.NextNoon, out nextNoon)
        || !DateTime.TryParse(_sun.Attributes?.NextDusk, out nextDusk))
        {
            _currentTimeOfDay = _timeOfDay.AsOption<TimeOfDayOptions>();
            _logger.LogError(@"One or more sun attributes aren't set.
                next_dawn: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.
                TimeOfDay: {Current}",
                new { Dawn =  nextDawn, Noon = nextNoon, Dusk = nextDusk,
                      Current = _currentTimeOfDay, Entity = _timeOfDay });
            return false;
        }

        if (currentTime >= nextDawn && currentTime < nextNoon)
        {
            _currentTimeOfDay = TimeOfDayOptions.Morning;
        }
        else if (currentTime >= nextDawn && currentTime < nextNoon
            && TimeOnly.FromDateTime(currentTime) >= Constants.DAYTIME)
        {
            _currentTimeOfDay = TimeOfDayOptions.Day;
        }
        else if (currentTime >= nextNoon && currentTime < nextDusk)
        {
            _currentTimeOfDay = TimeOfDayOptions.Afternoon;
        }
        else if (currentTime >= nextDusk && currentTime < nextDawn.AddDays(1)
            && TimeOnly.FromDateTime(currentTime) < Constants.NIGHTTIME_WEEKDAYS)
        {
            _currentTimeOfDay = TimeOfDayOptions.Evening;
        }
        else if (currentTime < nextDawn.AddDays(1)
            && TimeOnly.FromDateTime(currentTime) >= Constants.NIGHTTIME_WEEKDAYS)
        {
            _currentTimeOfDay = TimeOfDayOptions.Night;
        }
        _logger.LogDebug(@"TimeOfDay: {ToD} - Now: {Current}
            next_dawn: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.",
            new { ToD = _currentTimeOfDay, Current = currentTime, Dawn = nextDawn,
                  Noon = nextNoon, Dusk = nextDusk, Entity = _timeOfDay });

        return _currentTimeOfDay != _timeOfDay.AsOption<TimeOfDayOptions>();
    }

    private enum Trigger
    {
        TimeOfDay,
        OutOfBed,
        InBed
    }
}