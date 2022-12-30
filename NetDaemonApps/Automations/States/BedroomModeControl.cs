using Helpers.Extensions;

namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class BedroomModeController
{
    LogbookServices Logbook;
    ILogger<BedroomModeController> logger;
    IEntities entities;
    InputSelectEntity? LocationMode;
    InputBooleanEntity? inBed;

    // Controls the Lighting Control Mode Input Select which is used to manage global lighting controls
    // This can be manually overriden, but will mostly respond to being home/away, in/out bed, guests, time, brightness
    // Manual overrides should have a general time limit or reset at a certain state.

    public BedroomModeController(IHaContext context, IServices services, ILogger<BedroomModeController> logger)
    {
        Logbook = services.Logbook;
        this.logger = logger;
        this.entities = new Entities(context);

        LocationMode = entities.InputSelect.LocationMode;
        inBed = entities.InputBoolean.InBed;

        inBed?.StateChanges()
        .Throttle()
        .Subscribe(_ => Handle(Trigger.InBed));



        // Claire in bed
        claireInBed?.StateChanges()
        .Where(a => a.New.IsDetected() && !a.Old.IsDetected()
            && (LocationMode.IsOption(LocationModeOptions.Home)
            || LocationMode.IsOption(LocationModeOptions.OneAway))
        )
        .Throttle(TimeSpan.FromMinutes(5))
        .Subscribe(_ =>
        {
            claireBedStateChanged = true;
            Handle();
        });

        // Claire out of bed
        claireInBed?.StateChanges()
        .Where(a => a.New.IsNotDetected() && !a.Old.IsDetected()
            && (LocationMode.IsOption(LocationModeOptions.Home)
            || LocationMode.IsOption(LocationModeOptions.OneAway))
        )
        .Subscribe(_ =>
        {
            claireBedStateChanged = true;
            Handle();
        });
        
        Init();
    }

    void Init()
    {
        Reset();
        Handle();
    }

    void Handle(Trigger trigger)
    {
        if (andyInBed.IsDetected() && claireInBed.IsDetected()
        || andyInBed.IsDetected() && LocationMode!.IsOption(LocationModeOptions.OneAway)
        || claireInBed.IsDetected() && LocationMode!.IsOption(LocationModeOptions.OneAway))
        {
            logger.LogDebug($"Set state to in Bed");
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"Set state to in Bed, {WhoMadeAction}.",
                name: "In Bed",
                domain: "InputBoolean");
            inBed!.TurnOn();
        } 
        else if ((andyBedStateChanged || claireBedStateChanged)
            && (!andyInBed.IsDetected() || !claireInBed.IsDetected()))
        {
            logger.LogDebug($"Set state to out of Bed");
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"Set state to in Bed, {WhoMadeAction}.",
                name: "In Bed",
                domain: "InputBoolean");
            inBed!.TurnOff();
        }
        else if (manualBedStateChanged)
        {
            logger.LogDebug("Manual inBed: {State}, change occurred", inBed!.State);
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"Manual inBed: {inBed!.State}, change occurred.",
                name: "In Bed",
                domain: "InputBoolean");
        }
        
        Reset();
    }

    string WhoMadeAction()
    {
        var actor = LocationMode!.IsOption(LocationModeOptions.OneAway) ? Claire.IsHome() ? "Claire" : "Andy" :
        LocationMode!.IsOption(LocationModeOptions.Home) ? claireBedStateChanged ? "Claire" : "Andy" : "Cat";
        var action = andyBedStateChanged ? andyInBed.IsDetected() ? "in Andy's side" : "out of Andy's side" :
        claireBedStateChanged ? claireInBed.IsDetected() ? "in Claire's side" : "out of Claire's side" : "unknown state";
        return $"{actor} got {action} of the bed";
    }

    void Reset()
    {
        andyBedStateChanged = false;
        claireBedStateChanged = false;
        manualBedStateChanged = false;
    }

    enum Trigger
    {
        InBed,
        TimeOfDay
    }
}