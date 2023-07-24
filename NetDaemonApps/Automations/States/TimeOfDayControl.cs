[NetDaemonApp]
public class TimeOfDayControlApp
{
    private readonly Entities _entities;
    private readonly IHaContext _haContext;
    private readonly INetDaemonScheduler _scheduler;
    private readonly ILogger<TimeOfDayControlApp> _logger;
    private readonly InputSelectEntity _timeOfDay;
    private readonly InputBooleanEntity _inBed;
    private readonly SunEntity _sun;
    private readonly InputBooleanEntity _enabled;
    private TimeOfDayOptions _currentTimeOfDay;
    private SunTimes _sunTimes = new SunTimes();
    private LogbookServices _logbook;

    public TimeOfDayControlApp(IHaContext haContext, IServices services,
        INetDaemonScheduler scheduler, ILogger<TimeOfDayControlApp> logger)
    {
        _haContext = haContext;
        _scheduler = scheduler;
        _entities = new Entities(haContext);
        _logger = logger;
        _timeOfDay = _entities.InputSelect.TimeOfDay;
        _inBed = _entities.InputBoolean.InBed;
        _sun = _entities.Sun.Sun;
        _enabled = _entities.InputBoolean.TimeOfDayEnabled;
        _logbook = services.Logbook;

        RefreshSunTimes();
        SetTimeOfDay();
        SubscribeToEnabledEvents();
        SubscribeToInBedEvents();
    }

    private void RefreshSunTimes()
    {
        _scheduler.RunEvery(TimeSpan.FromDays(1), DateTimeOffset.Parse("02:00"), () => ScheduleSunTimes());
        if (!_sunTimes.IsSet)
            ScheduleSunTimes();
    }

    private void ScheduleSunTimes()
    {
        //_logbook.Log("ScheduleSunTimes", $"Setting todays sun times at {DateTime.Now}", _timeOfDay.EntityId, "input_select");
        _logger.LogInformation($"Setting todays sun times at {DateTime.Now}");
        if(DateTime.TryParse(_entities.Sensor.SunNextDawn.State, out DateTime nextDawn)
        && DateTime.TryParse(_entities.Sensor.SunNextNoon.State, out DateTime nextNoon)
        && DateTime.TryParse(_entities.Sensor.SunNextDusk.State, out DateTime nextDusk))
        {
            //_logbook.Log("ScheduleSunTimes", $"Todays sun times Dawn: {nextDawn} Noon: {nextNoon} Dusk: {nextDusk}", _timeOfDay.EntityId, "input_select");
            _logger.LogInformation($"Todays sun times Dawn: {nextDawn} Noon: {nextNoon} Dusk: {nextDusk}");
            _sunTimes = _sunTimes.Set(nextDawn, nextNoon, nextDusk);

            var nextDay = DateTime.Today.Add(Constants.DAYTIME.ToTimeSpan());
            var nextEvening = DateTime.Today.Add(Constants.EVENINGTIME.ToTimeSpan());
            if (DateOnly.FromDateTime(nextNoon) > DateOnly.FromDateTime(nextEvening)
                && TimeOnly.FromDateTime(DateTime.Now) > Constants.NIGHT_START)
                nextEvening.AddDays(1);

            _scheduler.RunAt(nextDawn, () => RunTimeUpdate());
            _scheduler.RunAt(nextDay, () => RunTimeUpdate());
            _scheduler.RunAt(nextNoon, () => RunTimeUpdate());
            _scheduler.RunAt(nextEvening, () => RunTimeUpdate());
            _scheduler.RunAt(nextDusk, () => RunTimeUpdate());
            _logger.LogInformation($"Todays sun times Morning: {nextDawn} Day: {nextDay} Noon: {nextNoon} Evening: {nextEvening} Night: {nextDusk}");
        }
    }

    private void RunTimeUpdate()
    {
        _logger.LogInformation($"Scheduled sun time Event current time: {_currentTimeOfDay}");
        SetTimeOfDay();
    }

    private void SubscribeToEnabledEvents()
    {
        _enabled.StateChanges()
        .Where(e => e.New.IsOn() && e.Old.IsOff())
        .Subscribe(_ =>
        {
            _logger.LogInformation($"Initialized Event current time: {_currentTimeOfDay}");
            RunTimeUpdate();
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
                _logger.LogDebug($"OutOfBed Event current time: {_currentTimeOfDay}");
                _timeOfDay.SelectOption(_currentTimeOfDay);
            }
            // Check if InBed has changed to true after 8pm and set time of day to Night
            else if (_timeOfDay.IsOption(TimeOfDayOptions.Evening) && inBed.New.IsOn()
                && TimeOnly.FromDateTime(DateTime.Now) > Constants.NIGHT_START)
            {
                _currentTimeOfDay = TimeOfDayOptions.Night;
                _logger.LogDebug($"InBed Event current time: {_currentTimeOfDay}");
                _timeOfDay.SelectOption(_currentTimeOfDay);
            }
        });
    }

    private void SetTimeOfDay()
    {
        var now = TimeOnly.FromDateTime(DateTime.Now);
        var today = DateOnly.FromDateTime(DateTime.Now);
        var dawn = TimeOnly.FromDateTime(_sunTimes.Dawn);
        var noon = TimeOnly.FromDateTime(_sunTimes.Noon);
        var dusk = TimeOnly.FromDateTime(_sunTimes.Dusk);
        if (now >= dawn && now < noon)
        {
            if(now >= Constants.DAYTIME)
            {
                _currentTimeOfDay = TimeOfDayOptions.Day;
                _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {now} >= {Constants.DAYTIME} >= (dawn):{_sunTimes.Dawn} < (noon):{_sunTimes.Noon}");
            }
            else
            {
                _currentTimeOfDay = TimeOfDayOptions.Morning;
                _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {now} < {Constants.DAYTIME} >= (dawn):{_sunTimes.Dawn} < (noon):{_sunTimes.Noon}");
            }
        }
        else if (now >= noon && ((now < dusk && dusk < Constants.EVENING_END) || now < Constants.EVENINGTIME))
        {
            _currentTimeOfDay = TimeOfDayOptions.Afternoon;
            _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {now} >= (noon):{_sunTimes.Noon} < (dusk):{_sunTimes.Dusk}");
        }
        else if ((now >= dusk || now >= Constants.EVENINGTIME)
            && now < Constants.NIGHTTIME_WEEKDAYS)
        {
            _currentTimeOfDay = TimeOfDayOptions.Evening;
            _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {now} >= (dusk):{_sunTimes.Dusk} < (dawn):{_sunTimes.Dawn.AddDays(1)}");
        }
        else if ((now > dusk && today == DateOnly.FromDateTime(_sunTimes.Dusk) && now > Constants.NIGHTTIME_WEEKDAYS)
              || (now < dawn && today == DateOnly.FromDateTime(_sunTimes.Dawn)))
        {
            _currentTimeOfDay = TimeOfDayOptions.Night;
            _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {now} < (dawn):{_sunTimes.Dawn.AddDays(1)}");
        }
        else
        {
            _logger.LogInformation($"Well how did we end up here: CurrentTime: {now} Dawn {_sunTimes.Dawn} Noon {_sunTimes.Noon} Dusk {_sunTimes.Dusk}");
        }

        if (_currentTimeOfDay != _timeOfDay.AsOption<TimeOfDayOptions>())
        {
            _logger.LogInformation($"Scheduled sun time update transitioning to {_currentTimeOfDay} from {_timeOfDay.State}.");
            _timeOfDay.SelectOption(_currentTimeOfDay);
        }
    }
}