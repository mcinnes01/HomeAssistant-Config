namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class LightControlModeController
{
    ILogger<LightControlModeController> logger;
    IEntities entities;
    InputSelectEntity? BedroomMode;
    InputSelectEntity? TimeOfDay;
    InputSelectEntity? LightControlMode;
    InputSelectEntity? LocationMode;
    InputSelectEntity? Brightness;

    // Controls the Lighting Control Mode Input Select which is used to manage global lighting controls
    // This can be manually overriden, but will mostly respond to being home/away, in/out bed, guests, time, brightness
    // Manual overrides should have a general time limit or reset at a certain state.

    public LightControlModeController(IHaContext context, ILogger<LightControlModeController> logger)
    {
        this.logger = logger;
        this.entities = new Entities(context);

        LightControlMode = entities.InputSelect.LightControlMode;
        LocationMode = entities.InputSelect.LocationMode;   
        TimeOfDay = entities.InputSelect.TimeOfDay;
        Brightness = entities.InputSelect.Brightness;
        BedroomMode = entities.InputSelect.BedroomMode;

        // Manual change or scene or schedule
        LightControlMode?.StateAllChangesWithCurrent()
        .Where(l => l?.New?.State != l?.Old?.State)
        .Throttle(TimeSpan.FromSeconds(30)) // Debounce for loops
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
        .Where(l => l.New.IsOption(BedroomModeOptions.Sleeping))
        .Subscribe(_ => Handle(Trigger.InBed));

        // Bedroom mode sleeping
        BedroomMode?.StateAllChangesWithCurrent()
        .Where(l => l.New.IsNotOption(BedroomModeOptions.Sleeping)
         && l.Old.IsOption(BedroomModeOptions.Sleeping))
        .Subscribe(_ => Handle(Trigger.OutOfBed));

        // 
        TimeOfDay?.StateAllChangesWithCurrent()
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.TimeOfDay));

        // Goes dark or dim
        Brightness?.StateAllChangesWithCurrent()
        .Where(b => b.New.IsNotOption(BrightnessOptions.Bright)
         && Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>())
         && (LightControlMode?.IsNotOption(LightControlModeOptions.Sleeping) ?? true))
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.Dark));
    }

    void Handle(Trigger trigger)
    {
        switch(trigger)
        {
            case Trigger.Unoccupied:
                logger.LogDebug("House unoccupied, set Light Control Mode to Manual.");
                LightControlMode.Log($"Set state to Manual, triggered by house {trigger.ToString()}.");
                LightControlMode?.SelectOption(LightControlModeOptions.Manual);
                break;
            case Trigger.Occupied:
                logger.LogDebug("House occupied, set Light Control Mode to Motion.");
                LightControlMode.Log($"Set state to Motion, triggered by house {trigger.ToString()}.");
                LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                break;
            case Trigger.Dark:
                logger.LogDebug("House occupied and it's dark outside, set Light Control Mode to Motion.");
                LightControlMode.Log($"Set state to Motion, triggered by Brightness {trigger.ToString()}.");
                LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                break;
            case Trigger.InBed:
                logger.LogDebug("In Bed, set Light Control Mode to Sleeping.");
                LightControlMode.Log($"Set state to Sleeping, triggered by {trigger.ToString()}.");
                LightControlMode?.SelectOption(LightControlModeOptions.Sleeping);
                break;
            case Trigger.OutOfBed:
                logger.LogDebug("Out Of Bed, set Light Control Mode to Motion.");
                LightControlMode.Log($"Set state to Motion, triggered by {trigger.ToString()}.");
                LightControlMode?.SelectOption(LightControlModeOptions.Motion);
                break;
            case Trigger.Manual:
                logger.LogDebug($"Manual change to Light Control Mode {LightControlMode?.State}.");
                LightControlMode.Log($"Manually set state to {LightControlMode?.State}, triggered by {trigger.ToString()}.");
                break;
                //TODO: more needs doing here and alexa questions would benefit light changing events

        }
    }

    enum Trigger
    {
        InBed,
        Manual,
        Unoccupied,
        Occupied,
        TimeOfDay,
        Dark,
        OutOfBed
    }
}