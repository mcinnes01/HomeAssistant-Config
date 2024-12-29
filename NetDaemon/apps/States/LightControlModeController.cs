namespace NetDaemon.apps.States;

[NetDaemonApp]
public class LightControlModeController
{
    ILogger<LightControlModeController> _logger;
    IEntities _entities;
    InputSelectEntity? BedroomMode;
    InputSelectEntity? TimeOfDay;
    InputSelectEntity? LightControlMode;
    InputSelectEntity? LocationMode;
    InputSelectEntity? Brightness;
    InputBooleanEntity? IsEnabled;

    // Controls the Lighting Control Mode Input Select which is used to manage global lighting controls
    // This can be manually overriden, but will mostly respond to being home/away, in/out bed, guests, time, brightness
    // Manual overrides should have a general time limit or reset at a certain state.

    public LightControlModeController(IHaContext context, ILogger<LightControlModeController> logger)
    {
        _logger = logger;
        _entities = new Entities(context);

        LightControlMode = _entities.InputSelect.LightControlMode;
        LocationMode = _entities.InputSelect.LocationMode;
        TimeOfDay = _entities.InputSelect.TimeOfDay;
        Brightness = _entities.InputSelect.Brightness;
        BedroomMode = _entities.InputSelect.BedroomMode;
        IsEnabled = _entities.InputBoolean.LightControlModeEnabled;

        // Manual change or scene or schedule
        LightControlMode?.StateAllChangesWithCurrent()
        .Where(l => l?.New?.State != l?.Old?.State)
        .Throttle(TimeSpan.FromSeconds(5)) // Debounce for loops
        .Subscribe(_ => Handle(Trigger.Manual));

        // No one home don't use motion lighting
        LocationMode?.StateAllChangesWithCurrent()
        .Where(l => l.New.IsOption(LocationModeOptions.Away))
        .Throttle(TimeSpan.FromMinutes(10))
        .Subscribe(_ => Handle(Trigger.Unoccupied));

        // Returned Home use motion lighting
        LocationMode?.StateAllChangesWithCurrent()
        .Where(l => l.New.IsNotOption(LocationModeOptions.Away)
         && l.New.IsNotOption(LocationModeOptions.Leaving)
         && (LightControlMode?.IsNotOption(LightControlModeOptions.Sleeping) ?? true))
        .Subscribe(_ => Handle(Trigger.Occupied));

        // Bedroom mode sleeping
        BedroomMode?.StateAllChangesWithCurrent()
        .Where(l => l.New.IsOption(BedroomModeOptions.Sleeping) && (LocationMode?.IsNotOption(LocationModeOptions.Guest) ?? true))
        .Subscribe(_ => Handle(Trigger.InBed));

        // Bedroom mode sleeping
        BedroomMode?.StateAllChangesWithCurrent()
        .Where(l => l.New.IsNotOption(BedroomModeOptions.Sleeping)
         && l.Old.IsOption(BedroomModeOptions.Sleeping))
        .Subscribe(_ => Handle(Trigger.OutOfBed));

        // Set to motion control when its day time and we are home
        TimeOfDay?.StateAllChangesWithCurrent()
        .Where(t => t.New.IsOption(TimeOfDayOptions.Day)
         && Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>()))
        .Subscribe(_ => Handle(Trigger.Day));

        // Set to motion control when its day time and we are home
        TimeOfDay?.StateAllChangesWithCurrent()
        .Where(t => t.New.IsOption(TimeOfDayOptions.Night)
         && !Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>()))
        .Subscribe(_ => Handle(Trigger.Night));

        // Goes dark or dim
        Brightness?.StateAllChangesWithCurrent()
        .Where(b => b.New.IsNotOption(BrightnessOptions.Bright)
         && Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>())
         && (LightControlMode?.IsNotOption(LightControlModeOptions.Sleeping) ?? true))
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.Dark));

        // Enabled
        IsEnabled?.StateChanges()
        .Where(s => s.New.IsOn())
        .Subscribe(_ =>
        {
            _logger.LogDebug("Light control mode control has been enabled.", new { Entity = LightControlMode });
            Handle();
        });

        Handle();
    }

    void Handle(Trigger? trigger = null)
    {
        if (IsEnabled.IsOn())
        {
            switch (trigger)
            {
                case Trigger.Unoccupied:
                    _logger.LogDebug("House unoccupied, set Light Control Mode to Manual.", new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Manual);
                    break;
                case Trigger.Occupied:
                    _logger.LogDebug("House occupied, set Light Control Mode to Motion.", new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                    break;
                case Trigger.Dark:
                    _logger.LogDebug("House occupied and it's Dark outside, set Light Control Mode to Motion.", new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                    break;
                case Trigger.InBed:
                    _logger.LogDebug("In Bed, set Light Control Mode to Sleeping.", new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Sleeping);
                    break;
                case Trigger.Night:
                    _logger.LogDebug("Night and we're away, set Light Control Mode to Sleeping.", new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Sleeping);
                    break;
                case Trigger.OutOfBed:
                case Trigger.Day:
                    _logger.LogDebug("Set state to Motion, triggered by {Trigger}.", trigger.ToString(), new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                    break;
                case Trigger.Manual:
                    _logger.LogDebug("Manually set state to {State}, triggered by {Trigger}.",
                        LightControlMode?.State, trigger.ToString(), new { Entity = LightControlMode });
                    break;
                default:
                    _logger.LogDebug("Default Light Control Mode motion.", new { Entity = LightControlMode });
                    LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                    break;
                    //TODO: more needs doing here and alexa questions would benefit light changing events
            }
        }
    }

    enum Trigger
    {
        InBed,
        Manual,
        Unoccupied,
        Occupied,
        Dark,
        OutOfBed,
        Day,
        Night
    }
}