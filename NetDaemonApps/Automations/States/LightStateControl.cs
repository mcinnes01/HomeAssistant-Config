namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class LightStateController
{
    LogbookServices LogBook;
    ILogger<LightStateController> logger;
    IEntities entities;
    InputSelectEntity? bedroomMode;
    InputSelectEntity? timeOfDay;
    InputSelectEntity? lightControlMode;
    InputSelectEntity? locationMode;
    InputSelectEntity? brightness;

    // Controls the Lighting Control Mode Input Select which is used to manage global lighting controls
    // This can be manually overriden, but will mostly respond to being home/away, in/out bed, guests, time, brightness
    // Manual overrides should have a general time limit or reset at a certain state.

    public LightStateController(IHaContext context, IServices services, ILogger<LightStateController> logger)
    {
        LogBook = services.Logbook;
        this.logger = logger;
        this.entities = new Entities(context);

        lightControlMode = entities.InputSelect.LightControlMode;
        locationMode = entities.InputSelect.LocationMode;   
        timeOfDay = entities.InputSelect.TimeOfDay;
        brightness = entities.InputSelect.Brightness;
        bedroomMode = entities.InputSelect.BedroomMode;

        // Manual change or scene or schedule
        lightControlMode?.StateChanges()
        .Throttle(TimeSpan.FromMinutes(1)) // Debounce for loops
        .Subscribe(_ => Handle(Trigger.LightControlMode));

        locationMode?.StateChanges()
        .Subscribe(_ => Handle(Trigger.LocationMode));

        timeOfDay?.StateChanges()
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.TimeOfDay));

        brightness?.StateChanges()
        .Throttle(TimeSpan.FromMinutes(1))
        .Subscribe(_ => Handle(Trigger.Brightness));

    }

    void Handle(Trigger trigger)
    {
        logger.LogDebug($"Light control state:");

        switch (trigger) 
        {
            Trigger.InBed:

        }
        if (inBed.IsOff()
    }

    enum Trigger
    {
        Brightness,
        InBed,
        LightControlMode,
        LocationMode,
        TimeOfDay
    }
}