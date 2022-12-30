namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class LocationModeController
{
    LogbookServices Logbook;
    ILogger<LocationModeController> logger;
    IEntities entities;
    InputSelectEntity? LocationMode;
    PersonEntity? Andy;
    PersonEntity? Claire;
    CalendarEntity? Calendar;

    bool andyChanged;
    bool claireChanged;
    bool manualChange;

    public LocationModeController(IHaContext context, IServices services, ILogger<LocationModeController> logger)
    {
        Logbook = services.Logbook;
        this.logger = logger;
        this.entities = new Entities(context);

        LocationMode = entities.InputSelect.LocationMode;
        Andy = entities.Person.Andy;
        Claire = entities.Person.Claire;
        Calendar = entities.Calendar.HomeAndisoftGmailCom;

        // Location Mode Manual Change
        LocationMode?.StateChanges()
        .Throttle(TimeSpan.FromMinutes(1)) // Debounce for loops
        .Subscribe(_ =>
        {
            manualChange = true;
            Handle();
        });

        // Andy goes away
        Andy?.StateChanges()
        .Where(a => a.New.IsNotHome() && !a.Old.IsNotHome())
        .Throttle(TimeSpan.FromMinutes(5))
        .Subscribe(_ =>
        {
            andyChanged = true;
            Handle();
        });

        // Andy goes away
        Andy?.StateChanges()
        .Where(a => a.New.IsHome() && !a.Old.IsHome())
        .Subscribe(_ =>
        {
            andyChanged = true;
            Handle();
        });

        // Claire goes away
        Claire?.StateChanges()
        .Where(a => a.New.IsNotHome() && !a.Old.IsNotHome())
        .Throttle(TimeSpan.FromMinutes(5))
        .Subscribe(_ =>
        {
            claireChanged = true;
            Handle();
        });

        // Claire goes away
        Claire?.StateChanges()
        .Where(a => a.New.IsHome() && !a.Old.IsHome())
        .Subscribe(_ =>
        {
            claireChanged = true;
            Handle();
        });

        // Calendar?.StateChanges()
        // .Where(c => c.New.Attributes.)
        
        Init();
    }

    void Init()
    {
        Reset();
        Handle();
    }

    void Handle()
    {
        if (!Andy.IsHome() && !Claire.IsHome())
        {
            logger.LogDebug("House set to Away, {WhoMadeAction}.", WhoMadeAction());
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"House set to Away, {WhoMadeAction}.",
                name: "Location Mode",
                domain: "InputSelect");
            LocationMode.SelectOption(LocationModeOptions.Away);
        }
        else if ((Andy.IsHome() && !Claire.IsHome())
            || (!Andy.IsHome() && Claire.IsHome()))
        {
            logger.LogDebug("House set to OneAway, {WhoMadeAction}.", WhoMadeAction());
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"House set to OneAway, {WhoMadeAction}.",
                name: "Location Mode",
                domain: "InputSelect");
            LocationMode.SelectOption(LocationModeOptions.OneAway);
        }
        else if (Andy.IsHome() && Claire.IsHome())
        {
            logger.LogDebug("House set to Home, {WhoMadeAction}.", WhoMadeAction());
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"House set to Home, {WhoMadeAction}.",
                name: "Location Mode",
                domain: "InputSelect");
            LocationMode.SelectOption(LocationModeOptions.Home);
        }
        else if (manualChange)
        {
            logger.LogDebug("House set to {State} by manual change.", LocationMode!.State);
            Logbook.Log(entityId: LocationMode!.EntityId,
                message: $"House set to {LocationMode!.State}.",
                name: "Location Mode",
                domain: "InputSelect");
        }

        Reset();
    }

    string WhoMadeAction()
    {
        if (andyChanged)
        {
            return $"Andy is {Andy!.State}";
        }
        if (claireChanged)
        {
            return $"Claire is {Claire!.State}";
        }
        return "Unknown change";
    }

    void Reset()
    {
        andyChanged = false;
        claireChanged = false;
        manualChange = false;
    }
}