namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class BedroomModeController
{
    ILogger<BedroomModeController> _logger;
    IEntities _entities;
    InputSelectEntity? BedroomMode;
    InputSelectEntity? LocationMode;
    InputBooleanEntity? InBed;
    InputSelectEntity? TimeOfDay;
    InputBooleanEntity? IsEnabled;

    // Controls the Lighting Control Mode Input Select which is used to manage global lighting controls
    // This can be manually overriden, but will mostly respond to being home/away, in/out bed, guests, time, brightness
    // Manual overrides should have a general time limit or reset at a certain state.

    public BedroomModeController(IHaContext context, ILogger<BedroomModeController> logger)
    {
        _logger = logger;
        _entities = new Entities(context);

        BedroomMode = _entities.InputSelect.BedroomMode;
        LocationMode = _entities.InputSelect.LocationMode;
        InBed = _entities.InputBoolean.InBed;
        TimeOfDay = _entities.InputSelect.TimeOfDay;
        IsEnabled = _entities.InputBoolean.BedroomModeControlEnabled;

        // Got in bed
        InBed?.StateChanges()
        .Where(b => b.New.IsOn()
        && Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>()))
        // TODO This needs to ask if you want to transition to sleeping and retry with backoff
        .Throttle(TimeSpan.FromMinutes(10))
        .Subscribe(_ => Handle(Trigger.InBed));

        // Got out of bed
        InBed?.StateChanges()
        .Where(b => b.New.IsOff()
        && Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>()))
        // TODO This needs to ask if you want to transition to normal and retry with backoff
        .Subscribe(_ => Handle(Trigger.OutOfBed));

        // Set to normal if time is morning and we are away
        TimeOfDay?.StateChanges()
        .Where(t => t.New.IsOption(TimeOfDayOptions.Morning)
        && (LocationMode.IsOption(LocationModeOptions.Away)
        || LocationMode.IsOption(LocationModeOptions.HouseSitter)))
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.TimeOfDayMorning));

        // Set to normal if time is day
        TimeOfDay?.StateChanges()
        .Where(t => t.New.IsOption(TimeOfDayOptions.Day)
        && Constants.HouseOccupied.Contains(LocationMode.AsOption<LocationModeOptions>()))
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.TimeOfDayDay));

        // Set to night if time is night and we are away
        TimeOfDay?.StateChanges()
        .Where(t => t.New.IsOption(TimeOfDayOptions.Night)
        && (LocationMode.IsOption(LocationModeOptions.Away)
        || LocationMode.IsOption(LocationModeOptions.HouseSitter)))
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.TimeOfDayNight));

        // Manual change
        BedroomMode?.StateChanges()
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.Manual));

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                _logger.LogDebug("Bedroom mode control has been enabled.");
                Handle();
            });

        Handle();
    }

    void Handle(Trigger? trigger = null)
    {
        // TODO: For got in bed, set a scheduler with alexa conversation
        // to deal with "would you like me to keep the light on?"
        if (IsEnabled.IsOn())
        {
            switch (trigger)
            {
                case Trigger.TimeOfDayNight:
                case Trigger.InBed:
                    _logger.LogDebug($"Set state to Sleeping");
                    BedroomMode.Log($"Set state to Sleeping, triggered by {trigger.ToString()}.");
                    BedroomMode!.SelectOption(BedroomModeOptions.Sleeping);
                    break;
                case Trigger.TimeOfDayMorning:
                case Trigger.OutOfBed:
                    _logger.LogDebug($"Set state to Relaxing");
                    BedroomMode.Log($"Set state to Relaxing, triggered by {trigger.ToString()}.");
                    if (TimeOfDay!.IsOption(TimeOfDayOptions.Day))
                    {
                        BedroomMode!.SelectOption(BedroomModeOptions.Normal);
                    }
                    else
                    {
                        BedroomMode!.SelectOption(BedroomModeOptions.Relaxing);
                    }
                    break;
                case Trigger.Manual:
                    _logger.LogDebug("Manual bedroom mode: {State}, change occurred", BedroomMode!.State);
                    BedroomMode.Log($"Manual Bedroom Mode: {BedroomMode!.State}, change occurred.");
                    break;
                default:
                case Trigger.TimeOfDayDay:
                    _logger.LogDebug($"Set state to Normal");
                    BedroomMode.Log($"Set state to Normal, triggered by {trigger?.ToString()}.");
                    BedroomMode!.SelectOption(BedroomModeOptions.Normal);
                    break;
            }
        }
    }

    enum Trigger
    {
        InBed,
        OutOfBed,
        TimeOfDayMorning,
        TimeOfDayDay,
        TimeOfDayNight,
        Manual
    }
}