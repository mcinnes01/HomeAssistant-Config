namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class BedStateController
{
    LogbookServices Logbook;
    ILogger<BedStateController> logger;
    IEntities entities;
    InputSelectEntity? LocationMode;
    PersonEntity? Andy;
    PersonEntity? Claire;
    BinarySensorEntity? AndyInBed;
    BinarySensorEntity? ClaireInBed;
    InputBooleanEntity? InBed;

    bool claireBedStateChanged;
    bool andyBedStateChanged;
    bool manualBedStateChanged;

    // Controls the Lighting Control Mode Input Select which is used to manage global lighting controls
    // This can be manually overriden, but will mostly respond to being home/away, in/out bed, guests, time, brightness
    // Manual overrides should have a general time limit or reset at a certain state.

    public BedStateController(IHaContext context, IServices services, ILogger<BedStateController> logger)
    {
        Logbook = services.Logbook;
        this.logger = logger;
        this.entities = new Entities(context);

        InBed = entities.InputBoolean.InBed;
        AndyInBed = entities.BinarySensor.WithingsInBedAndy;
        ClaireInBed = entities.BinarySensor.WithingsInBedClaire;
        LocationMode = entities.InputSelect.LocationMode;
        Andy = entities.Person.Andy;
        Claire = entities.Person.Claire;

        InBed?.StateChanges()
        .Throttle(TimeSpan.FromMinutes(1)) // Debounce any loop behaviour
        .Subscribe(_ => {
            manualBedStateChanged = true;
            Handle();
        });

        // Andy in bed
        AndyInBed?.StateChanges()
        .Where(a => a.New.IsDetected() && !a.Old.IsDetected()
            && (LocationMode.IsOption(LocationModeOptions.Home)
            || LocationMode.IsOption(LocationModeOptions.OneAway))
        )
        .Throttle(TimeSpan.FromMinutes(5))
        .Subscribe(_ =>
        {
            andyBedStateChanged = true;
            Handle();
        });

        // Andy out of bed
        AndyInBed?.StateChanges()
        .Where(a => a.New.IsNotDetected() && a.Old.IsDetected()
            && (LocationMode.IsOption(LocationModeOptions.Home)
            || LocationMode.IsOption(LocationModeOptions.OneAway))
        )
        .Subscribe(_ =>
        {
            andyBedStateChanged = true;
            Handle();
        });

        // Claire in bed
        ClaireInBed?.StateChanges()
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
        ClaireInBed?.StateChanges()
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

    void Handle()
    {
        if (AndyInBed.IsDetected() && ClaireInBed.IsDetected()
        || AndyInBed.IsDetected() && LocationMode!.IsOption(LocationModeOptions.OneAway)
        || ClaireInBed.IsDetected() && LocationMode!.IsOption(LocationModeOptions.OneAway))
        {
            logger.LogDebug($"Set state to in Bed");
            InBed.Log($"Set state to in Bed, {WhoMadeAction}.");
            InBed!.TurnOn();
        } 
        else if ((andyBedStateChanged || claireBedStateChanged)
            && (!AndyInBed.IsDetected() || !ClaireInBed.IsDetected()))
        {
            logger.LogDebug($"Set state to out of Bed");
            InBed.Log($"Set state to out of Bed, {WhoMadeAction}.");
            // TODO use alexa questions on a backoff retry to check if you are actually up and not just going for a wee
            InBed!.TurnOff();
        }
        else if (manualBedStateChanged)
        {
            logger.LogDebug("Manual inBed: {State}, change occurred", InBed!.State);
            InBed.Log($"Manual inBed: {InBed?.State}, change occurred.");
        }
        
        Reset();
    }

    string WhoMadeAction()
    {
        var actor = LocationMode!.IsOption(LocationModeOptions.OneAway) ? Claire.IsHome() ? "Claire" : "Andy" :
        LocationMode!.IsOption(LocationModeOptions.Home) ? claireBedStateChanged ? "Claire" : "Andy" : "Cat";
        var action = andyBedStateChanged ? AndyInBed.IsDetected() ? "in Andy's side" : "out of Andy's side" :
        claireBedStateChanged ? ClaireInBed.IsDetected() ? "in Claire's side" : "out of Claire's side" : "unknown state";
        return $"{actor} got {action} of the bed";
    }

    void Reset()
    {
        andyBedStateChanged = false;
        claireBedStateChanged = false;
        manualBedStateChanged = false;
    }
}