namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class TimeOfDayController
{
    LogbookServices Logbook;
    ILogger<TimeOfDayController> logger;
    IEntities entities;
    INetDaemonScheduler Scheduler;
    InputBooleanEntity? InBed;
    InputSelectEntity? TimeOfDay;
    InputSelectEntity? Brightness;
    InputBooleanEntity? IsEnabled;
    SunEntity? Sun;

    public TimeOfDayController(IHaContext context, IServices services,
    INetDaemonScheduler scheduler, ILogger<TimeOfDayController> logger)
    {
        Logbook = services.Logbook;
        this.logger = logger;
        entities = new Entities(context);
        Scheduler = scheduler;
        InBed = entities.InputBoolean.InBed;
        TimeOfDay = entities.InputSelect.TimeOfDay;
        Brightness = entities.InputSelect.Brightness;
        Sun = entities.Sun.Sun;
        IsEnabled = entities.InputBoolean.TimeOfDayEnabled;

        // Schedules for general time of day control

        // Weekday Morning
        scheduler.RunWeekDays(Constants.MORNINGTIME_WEEKDAYS, () => Handle(Trigger.Morning));

        // Weekend Morning
        scheduler.RunWeekends(Constants.MORNINGTIME_WEEKENDS, () => Handle(Trigger.Morning));

        // Set Day time
        scheduler.RunDaily(Constants.DAYTIME, () => Handle(Trigger.Day));

        // Set Afternoon base on noon and our afternoon value
        scheduler.RunIn(Sun.NextNoon(), () => Handle(Trigger.Afternoon));

        // Set Evening base on our evening range and next dusk
        scheduler.RunIn(Sun.NextEvening(), () => Handle(Trigger.Evening));

        // Set Night Weekdays
        scheduler.RunIn(Sun.NextNight(), () => Handle(Trigger.Night));

        // Overrides for where the sun or brightness could affect when a time of day starts for seasonal differences

        // Trigger when someone get's up in the morning
        InBed?.StateChanges()
        .Where(b => b.New.IsOff()
            && TimeOfDay.IsOption(TimeOfDayOptions.Night)
            && TimeOnly.FromDateTime(DateTime.Now) > Constants.MORNING_START
            && TimeOnly.FromDateTime(DateTime.Now) < Constants.MORNING_END)
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.OutOfBed));

        // Trigger when someone goes to bed
        InBed?.StateChanges()
        .Where(b => b.New.IsOn()
            && TimeOfDay.IsOption(TimeOfDayOptions.Evening)
            && TimeOnly.FromDateTime(DateTime.Now) > Constants.NIGHT_START
            && TimeOnly.FromDateTime(DateTime.Now) < Constants.NIGHT_END)
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.InBed));

        // It's afternoon but has gone dark early i.e. winter
        Brightness?.StateChanges()
            .Where(b => b.New.IsOption(BrightnessOptions.Dark) 
                     && TimeOfDay.IsOption(TimeOfDayOptions.Afternoon)
                     && Sun.IsSetting())
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => Handle(Trigger.BrightnessEvening));

        // It's morning but has gone bright early i.e. summer
        Brightness?.StateChanges()
            .Where(b => b.New.IsOption(BrightnessOptions.Bright) 
                     && TimeOfDay.IsOption(TimeOfDayOptions.Night)
                     && Sun.IsRising())
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => Handle(Trigger.BrightnessMorning));

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                Handle();
            });
        
        Handle();
    }

    void Handle(Trigger? trigger = null)
    {
        // TODO this needs doing, this is old logic, move to new constants and schedules
        // Use sunset to sunrise to move morning/day/evening/night within their range
        if (IsEnabled.IsOn())
        {
            switch (trigger)
            {
                // TODO: Getting up in the morning range should prompt an alexa question are you up
                // and then set time of day to morning and out of bed etc
                case Trigger.Morning:                
                case Trigger.OutOfBed:
                case Trigger.BrightnessMorning:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Morning);
                    break;
                case Trigger.Day:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Day);
                    break;
                case Trigger.Afternoon:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Afternoon);
                    // Schedule the next run
                    Scheduler.RunIn(Sun.NextNoon(), () => Handle(Trigger.Afternoon));
                    break;
                case Trigger.Evening:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Evening);
                    // Schedule the next run
                    Scheduler.RunIn(Sun.NextEvening(), () => Handle(Trigger.Evening));
                    break;
                case Trigger.BrightnessEvening:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Evening);
                    break;
                case Trigger.Night:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Night);
                    // Schedule the next run
                    Scheduler.RunIn(Sun.NextNight(), () => Handle(Trigger.Night));
                    break;
                case Trigger.InBed:
                    TimeOfDay!.SelectOption(TimeOfDayOptions.Night);
                    break;
                default:
                    var now = TimeOnly.FromDateTime(DateTime.Now);
                    if (TimeOfDay!.IsNotOption(TimeOfDayOptions.Morning)
                        && now.ToTimeSpan() > Sun?.NextMorning()
                        && now < Constants.MORNING_END)
                    {
                        TimeOfDay.Log("Morning - Sun is above horizon and rising.");
                        logger.LogDebug("Morning - Sun is above horizon and rising.");
                        TimeOfDay!.SelectOption(TimeOfDayOptions.Morning);
                    }
                    else if (TimeOfDay!.IsNotOption(TimeOfDayOptions.Day) 
                        && now > Constants.MORNING_END
                        && now.ToTimeSpan() < Sun?.NextNoon())
                    {                        
                        TimeOfDay.Log($"Day - Sun is above horizon and time is before {Sun?.NextNoon()}");
                        logger.LogDebug($"Day - Sun is above horizon and time is before {Sun?.NextNoon()}");
                        TimeOfDay!.SelectOption(TimeOfDayOptions.Day);
                    }
                    else if (TimeOfDay!.IsNotOption(TimeOfDayOptions.Afternoon) 
                        && now < Constants.EVENING_START
                        && now.ToTimeSpan() < Sun?.NextEvening())
                    {
                        TimeOfDay.Log($"Day - Sun is above horizon and time is before {Sun?.NextEvening()}.");
                        logger.LogDebug($"Day - Sun is above horizon and time is before {Sun?.NextEvening()}.");
                        TimeOfDay!.SelectOption(TimeOfDayOptions.Afternoon);
                    }
                    else if (TimeOfDay!.IsNotOption(TimeOfDayOptions.Evening) 
                        && now < Constants.NIGHT_START
                        && now.ToTimeSpan() < Sun?.NextNight())
                    {
                        TimeOfDay.Log($"Day - Sun is above horizon and time is before {Constants.NIGHT_START}.");
                        logger.LogDebug($"Day - Sun is above horizon and time is before {Constants.NIGHT_START}.");
                        TimeOfDay!.SelectOption(TimeOfDayOptions.Afternoon);
                    }
                    else
                    {
                        TimeOfDay.Log("Night - Based on sun and time.");
                        logger.LogDebug("Night - Based on sun and time.");
                        TimeOfDay!.SelectOption(TimeOfDayOptions.Night);
                    }
                    break;
            }
        }
        
        TimeOfDay.Log($"State to {TimeOfDay?.State}, triggered by {trigger.ToString()}.");
    }

    enum Trigger
    {
        Afternoon,
        Day,
        Evening,
        Morning,
        Night,
        BrightnessEvening,
        BrightnessMorning,
        OutOfBed,
        InBed
    }
}