namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class TimeOfDayController
{
    ILogger<TimeOfDayController> logger;
    IEntities entities;
    InputSelectEntity? timeOfDay;
    InputSelectEntity? brightness;
    InputBooleanEntity? IsEnabled;
    SunEntity? sun;
    bool isRightTime;

    public TimeOfDayController(IHaContext context, ILogger<TimeOfDayController> logger)
    {
        this.logger = logger;
        this.entities = new Entities(context);
        timeOfDay = entities.InputSelect.TimeOfDay;
        sun = entities.Sun.Sun;
        IsEnabled = entities.InputBoolean.TimeOfDayEnabled;

        // Trigger if sun state changes
        sun?.StateChanges()
            .Where(s => s.New?.State != s.Old?.State)
            .Subscribe(s =>
            {
                isRightTime = s.New.IsBelowHorizon() &&
                    (timeOfDay.IsOption(TimeOfDayOptions.Evening) || 
                    timeOfDay.IsOption(TimeOfDayOptions.Night));
                Handle();
            });

        timeOfDay?.StateChanges()
            .Where(s => s.New?.State != s.Old?.State)
            .Subscribe(s =>
            {
                Handle();
            });

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                Init();
            });
        
        Init();
    }

    void Init()
    {
        isRightTime = 
            (timeOfDay!.IsOption(TimeOfDayOptions.Evening) && sun.IsAboveHorizon() &&
            TimeOnly.FromDateTime(DateTime.Now) > new TimeOnly(17, 30) &&
            TimeOnly.FromDateTime(DateTime.Now) < new TimeOnly(20, 30)) ||
            (timeOfDay!.IsOption(TimeOfDayOptions.Night) && sun.IsBelowHorizon() &&
            TimeOnly.FromDateTime(DateTime.Now) < new TimeOnly(20, 30));
        Handle();
    }

    void Handle()
    {
        logger.LogDebug($"Time Of Day, enabled: {IsEnabled}, right: {isRightTime}, value: {timeOfDay?.State}");

        if (IsEnabled.IsOn())
        {
            if (!isRightTime)
            {
                if (timeOfDay!.IsNotOption(TimeOfDayOptions.Morning)
                    && sun.IsAboveHorizon()
                    && sun?.Attributes?.Rising == true)
                {
                    logger.LogDebug("Morning - Sun is above horizon and rising.");
                    timeOfDay!.SelectOption(TimeOfDayOptions.Morning);
                }
                else if (timeOfDay!.IsNotOption(TimeOfDayOptions.Day) && 
                    sun.IsAboveHorizon() &&
                    TimeOnly.FromDateTime(DateTime.Now) < new TimeOnly(17, 30))
                {
                    logger.LogDebug("Day - Sun is above horizon and time is before 17:30.");
                    timeOfDay!.SelectOption(TimeOfDayOptions.Day);
                }
                else if (timeOfDay!.IsNotOption(TimeOfDayOptions.Evening) && 
                    (sun.IsAboveHorizon() &&
                    TimeOnly.FromDateTime(DateTime.Now) > new TimeOnly(17, 30) &&
                    TimeOnly.FromDateTime(DateTime.Now) < new TimeOnly(20, 30)) ||
                    (sun.IsBelowHorizon() &&
                    TimeOnly.FromDateTime(DateTime.Now) < new TimeOnly(20, 30)))
                {
                    logger.LogDebug("Evening - Based on sun and time.");
                    timeOfDay!.SelectOption(TimeOfDayOptions.Evening);
                }
                else
                {
                    logger.LogDebug("Night - Based on sun and time.");
                    timeOfDay!.SelectOption(TimeOfDayOptions.Night);
                }
            }
        }
    }
}