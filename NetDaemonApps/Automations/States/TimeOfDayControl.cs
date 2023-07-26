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
        if(DateTime.TryParse(_entities.Sensor.SunNextDawn.State, out DateTime nextDawn)
        && DateTime.TryParse(_entities.Sensor.SunNextNoon.State, out DateTime nextNoon)
        && DateTime.TryParse(_entities.Sensor.SunNextDusk.State, out DateTime nextDusk))
        {
            // Set sun times
            _sunTimes = _sunTimes.Set(nextDawn, nextNoon, nextDusk);

            _scheduler.RunAt(_sunTimes.Morning, () => RunTimeUpdate());
            _scheduler.RunAt(_sunTimes.Day, () => RunTimeUpdate());
            _scheduler.RunAt(_sunTimes.Afternoon, () => RunTimeUpdate());
            _scheduler.RunAt(_sunTimes.Evening, () => RunTimeUpdate());
            _scheduler.RunAt(_sunTimes.Night, () => RunTimeUpdate());
            _logger.LogInformation($"Todays sun times Morning: {_sunTimes.Morning} Day: {_sunTimes.Day} Noon: {_sunTimes.Afternoon} Evening: {_sunTimes.Evening} Night: {_sunTimes.Night}");
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
        if (_sunTimes.Now >= _sunTimes.Morning && _sunTimes.Now < _sunTimes.Afternoon)
        {
            if(_sunTimes.NowTime >= Constants.DAYTIME)
            {
                _currentTimeOfDay = TimeOfDayOptions.Day;
                _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {_sunTimes.Now} >= {Constants.DAYTIME} >= (dawn):{_sunTimes.Morning} < (noon):{_sunTimes.Afternoon}");
            }
            else
            {
                _currentTimeOfDay = TimeOfDayOptions.Morning;
                _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {_sunTimes.Now} < {Constants.DAYTIME} >= (dawn):{_sunTimes.Morning} < (noon):{_sunTimes.Afternoon}");
            }
        }
        else if (_sunTimes.Now >= _sunTimes.Afternoon && ((_sunTimes.Now < _sunTimes.Night && _sunTimes.NightTime < Constants.EVENING_END) || _sunTimes.NowTime < Constants.EVENINGTIME))
        {
            _currentTimeOfDay = TimeOfDayOptions.Afternoon;
            _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {_sunTimes.Now} >= (noon):{_sunTimes.Afternoon} < (dusk):{_sunTimes.Night}");
        }
        else if ((_sunTimes.Now >= _sunTimes.Night || _sunTimes.NowTime >= Constants.EVENINGTIME)
            && _sunTimes.NowTime < Constants.NIGHTTIME_WEEKDAYS)
        {
            _currentTimeOfDay = TimeOfDayOptions.Evening;
            _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {_sunTimes.Now} >= (dusk):{_sunTimes.Night} < (dawn):{_sunTimes.Morning.AddDays(1)}");
        }
        else if ((_sunTimes.Now > _sunTimes.Night && _sunTimes.NowDate == _sunTimes.NightDate && _sunTimes.NowTime > Constants.NIGHTTIME_WEEKDAYS)
              || (_sunTimes.Now < _sunTimes.Morning && _sunTimes.NowDate == _sunTimes.MorningDate))
        {
            _currentTimeOfDay = TimeOfDayOptions.Night;
            _logger.LogInformation($"Setting current TimeOfDay: {_currentTimeOfDay} - Now: {_sunTimes.Now} < (dawn):{_sunTimes.Morning.AddDays(1)}");
        }
        else
        {
            _logger.LogInformation($"Well how did we end up here: CurrentTime: {_sunTimes.Now} Dawn {_sunTimes.Morning} Noon {_sunTimes.Afternoon} Dusk {_sunTimes.Night}");
        }

        if (_currentTimeOfDay != _timeOfDay.AsOption<TimeOfDayOptions>())
        {
            _logger.LogInformation($"Scheduled sun time update transitioning to {_currentTimeOfDay} from {_timeOfDay.State}.");
            _timeOfDay.SelectOption(_currentTimeOfDay);
        }
    }
}