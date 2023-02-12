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
            _timeOfDay.Log($"{t.Trigger.ToString()} transitioning to {t.Destination.ToString()} from {_timeOfDay.State}.");
            _logger.LogDebug("{Trigger} transitioning to {From} from {To}.", t.Trigger.ToString(), _timeOfDay.State, t.Destination.ToString());
            _timeOfDay.SelectOption(t.Destination);
        });
        _stateMachine.OnUnhandledTrigger((state, trigger) =>
        {
            _timeOfDay.Log($"Unhandled transition for {trigger.ToString()}, from: {_timeOfDay.State} to: {state.ToString()}");
            _logger.LogDebug("Unhandled transition for {Trigger}, from: {From} to {To}.", trigger.ToString(), _timeOfDay.State, state.ToString());
        });
    }

    private void SubscribeToSunEvents()
    {
        _sun.StateChanges()
        .Where(e => (e.Entity.Attributes?.NextDawn != null 
            || e.Entity.Attributes?.NextDusk != null 
            || e.Entity.Attributes?.NextNoon != null)
            && _enabled.IsOn())
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ =>
        {
            SetTimeOfDay();
            _logger.LogDebug("Sun Event current time: {Time}", _currentTimeOfDay);
            _stateMachine.Fire(Trigger.TimeOfDay);
        });
    }

    private void SubscribeToEnabledEvents()
    {
        _enabled.StateChanges()
        .Where(e => e.New.IsOn())
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ =>
        {
            SetTimeOfDay();
            _logger.LogDebug("Initialized Event current time: {Time}", _currentTimeOfDay);
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
                _logger.LogDebug("OutOfBed Event current time: {Time}", _currentTimeOfDay);
                _stateMachine.Fire(Trigger.OutOfBed);
            }
            // Check if InBed has changed to true after 8pm and set time of day to Night
            else if (_timeOfDay.IsOption(TimeOfDayOptions.Evening) && inBed.New.IsOn()
                && TimeOnly.FromDateTime(DateTime.Now) > Constants.NIGHT_START)
            {
                _currentTimeOfDay = TimeOfDayOptions.Night;
                _logger.LogDebug("InBed Event current time: {Time}", _currentTimeOfDay);
                _stateMachine.Fire(Trigger.InBed);
            }
        });
    }

    private void SetTimeOfDay()
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
                next_dawm: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.
                TimeOfDay: {Current}",
                nextDawn, nextNoon, nextDusk, _currentTimeOfDay);
        }
        else if (currentTime >= nextDawn && currentTime < nextNoon)
        {
            _currentTimeOfDay = TimeOfDayOptions.Morning;
            _logger.LogDebug(@"TimeOfDay: {ToD} - Now: {Current}
                next_dawm: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.",
                _currentTimeOfDay, currentTime, nextDawn, nextNoon, nextDusk);
        }
        else if (currentTime >= nextDawn && currentTime < nextNoon
            && TimeOnly.FromDateTime(currentTime) >= Constants.DAYTIME)
        {
            _currentTimeOfDay = TimeOfDayOptions.Day;
            _logger.LogDebug(@"TimeOfDay: {ToD} - Now: {Current}
                next_dawm: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.",
                _currentTimeOfDay, currentTime, nextDawn, nextNoon, nextDusk);
        }
        else if (currentTime >= nextNoon && currentTime < nextDusk)
        {
            _currentTimeOfDay = TimeOfDayOptions.Afternoon;
            _logger.LogDebug(@"TimeOfDay: {ToD} - Now: {Current}
                next_dawm: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.",
                _currentTimeOfDay, currentTime, nextDawn, nextNoon, nextDusk);
        }
        else if (currentTime >= nextDusk && currentTime < nextDawn.AddDays(1) 
            && TimeOnly.FromDateTime(currentTime) < Constants.NIGHTTIME_WEEKDAYS)
        {
            _currentTimeOfDay = TimeOfDayOptions.Evening;
            _logger.LogDebug(@"TimeOfDay: {ToD} - Now: {Current}
                next_dawm: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.",
                _currentTimeOfDay, currentTime, nextDawn, nextNoon, nextDusk);
        }
        else if (currentTime < nextDawn.AddDays(1)
            && TimeOnly.FromDateTime(currentTime) >= Constants.NIGHTTIME_WEEKDAYS)
        {
            _currentTimeOfDay = TimeOfDayOptions.Night;
            _logger.LogDebug(@"TimeOfDay: {ToD} - Now: {Current}
                next_dawm: {Dawn}, next_noon: {Noon}, next_dusk: {Dusk}.",
                _currentTimeOfDay, currentTime, nextDawn, nextNoon, nextDusk);
        }
    }

    private enum Trigger
    {
        TimeOfDay,
        OutOfBed,
        InBed
    }
}