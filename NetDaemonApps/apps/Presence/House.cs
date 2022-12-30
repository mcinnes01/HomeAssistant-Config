/// <summary>
///     Manage state of morning, house, day, evening, night and cleaning
/// </summary>
//[NetDaemonApp]
public class HouseStateManager
{
    private readonly IHaContext _haContext;
    private readonly INetDaemonScheduler _scheduler;
    private readonly ILogger<HouseStateManager> _log;
    private readonly Entities _entities;

    public HouseStateManager(IHaContext ha, INetDaemonScheduler scheduler, ILogger<HouseStateManager> logger)
    {
        _haContext = ha;
        _scheduler = scheduler;
        _log = logger;
        _entities = new Entities(ha);

        SetDayTime();
        //SetCleaning();
        SetEveningWhenLowLightLevel();
        SetNightTime();
        SetMorningWhenBrightLightLevel();

        InitHouseStateSceneManagement();
    }
    
    /// <summary>
    ///     Sets the house state on the corresponding scene
    /// </summary>
    private void InitHouseStateSceneManagement()
    {
        _entities.Scene.LightingDay.WhenTurnsOn(s => SetTimeOfDay(TimeOfDayOptions.Day));
        _entities.Scene.LightingEvening.WhenTurnsOn(s => SetTimeOfDay(TimeOfDayOptions.Evening));
        _entities.Scene.LightingNight.WhenTurnsOn(s => SetTimeOfDay(TimeOfDayOptions.Night));
        _entities.Scene.GetUp.WhenTurnsOn(s => SetTimeOfDay(TimeOfDayOptions.Morning));
        _entities.Scene.Cleaning.WhenTurnsOn(s => SetLightControlMode(LightControlModeOptions.Cleaning));
        _entities.Scene.LightingAmbient.WhenTurnsOn(s => SetLightControlMode(LightControlModeOptions.Relaxing));
    }

    private void SetDayTime() =>
        _scheduler.RunDaily(Constants.DAYTIME, () => SetTimeOfDay(TimeOfDayOptions.Day));

    private void SetCleaning()
    {
        _scheduler.RunDaily(Constants.CLEANING_STARTTIME, () =>
        {
            if (DateTime.Now.DayOfWeek == Constants.CLEANING_DAY &&
                SetLightControlMode(LightControlModeOptions.Cleaning))
                _log.LogInformation($"Cleaning starts at: {Constants.CLEANING_STARTTIME} on {Constants.CLEANING_DAY}");
        });

        _scheduler.RunDaily(Constants.CLEANING_ENDTIME, () =>
        {
            if (DateTime.Now.DayOfWeek == Constants.CLEANING_DAY &&
                SetLightControlMode(LightControlModeOptions.Cleaning))
                _log.LogInformation($"Cleaning ends at: {Constants.CLEANING_ENDTIME} on {Constants.CLEANING_DAY}");
        });
    }

    /// <summary>
    ///     Set night time schedule on different time different weekdays
    /// </summary>
    private void SetNightTime()
    {
        _scheduler.RunDaily(Constants.NIGHTTIME_WEEKDAYS, () =>
        {
            if (Constants.WeekdayNightDays.Contains(DateTime.Now.DayOfWeek) &&
                SetTimeOfDay(TimeOfDayOptions.Night))
                _log.LogInformation($"Setting weekday night time to: {Constants.NIGHTTIME_WEEKDAYS}");
        });

        _scheduler.RunDaily(Constants.NIGHTTIME_WEEKENDS, () =>
        {
            if (Constants.WeekendNightDays.Contains(DateTime.Now.DayOfWeek) &&
                SetTimeOfDay(TimeOfDayOptions.Night))
                _log.LogInformation($"Setting weekend night time to: {Constants.NIGHTTIME_WEEKENDS}");
        });
    }

    /// <summary>
    ///     Set to evening when the light level is low and it is daytime
    /// </summary>
    private void SetEveningWhenLowLightLevel()
    {
        _entities.Sensor.WeatherStationAmbientLight
        .StateAllChangesWithCurrent()
        .Where(e => e.New?.State <= Constants.DARK_THRESHOLD
            && TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.EVENING_START, Constants.EVENING_END))
        .Subscribe(s => 
        {
            if (SetTimeOfDay(TimeOfDayOptions.Evening))
                _log.LogInformation($"Setting Time Of Day to Evening - Light level below dark threshold and time within evening range.");
        });
    }

    /// <summary>
    ///     When the light levels are bright enough it is considered morning time
    /// </summary>
    private void SetMorningWhenBrightLightLevel()
    {
        _entities.Sensor.WeatherStationAmbientLight
        .StateAllChangesWithCurrent()
        .Where(e => e.New?.State > Constants.DARK_THRESHOLD &&
                    TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.MORNING_START, Constants.MORNING_END)
                    && _entities.Sun.Sun?.Attributes?.Rising == true)
        .Subscribe(s => 
        {
            if (SetTimeOfDay(TimeOfDayOptions.Morning))
                _log.LogInformation($"Setting Time Of Day to Morning - Light level above dark threshold and time within morning range.");
        });
    }
    
    /// <summary>
    ///     Sets the house state to specified state and updates Home Assistant InputSelect
    /// </summary>
    /// <param name="state">State to set</param>
    private bool SetTimeOfDay(TimeOfDayOptions state)
    {
        if (_entities.InputSelect.TimeOfDay.IsNotOption(state))
        {
            _log.LogInformation($"Setting time of day to {state}", state);
            _entities.InputSelect.TimeOfDay.SelectOption(state);
            return true;
        }
        return false;
    }
    
    /// <summary>
    ///     Sets the house state to specified state and updates Home Assistant InputSelect
    /// </summary>
    /// <param name="state">State to set</param>
    private bool SetLightControlMode(LightControlModeOptions state)
    {
        if (_entities.InputSelect.LightControlMode.IsNotOption(state))
        {
            _log.LogInformation($"Setting current house state to {state}", state);
            _entities.InputSelect.LightControlMode.SelectOption(state);
            return true;
        }
        return false;
    }
}