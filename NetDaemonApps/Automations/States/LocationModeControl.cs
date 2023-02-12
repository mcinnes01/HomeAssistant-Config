namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class LocationModeController
{
    ILogger<LocationModeController> _logger;
    IEntities _entities;
    InputSelectEntity? LocationMode;
    PersonEntity? Andy;
    PersonEntity? Claire;
    CalendarEntity? Calendar;
    InputBooleanEntity? IsEnabled;

    bool andyChanged;
    bool claireChanged;
    bool manualChange;

    public LocationModeController(IHaContext context, ILogger<LocationModeController> logger)
    {
        _logger = logger;
        _entities = new Entities(context);

        LocationMode = _entities.InputSelect.LocationMode;
        Andy = _entities.Person.Andy;
        Claire = _entities.Person.Claire;
        Calendar = _entities.Calendar.HomeAndisoftGmailCom;
        IsEnabled = _entities.InputBoolean.LocationModeEnabled;

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

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                _logger.LogDebug("Location mode control has been enabled.");
                Init();
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
        if (IsEnabled.IsOn())
        {
            if (!Andy.IsHome() && !Claire.IsHome())
            {
                _logger.LogDebug("House set to Away, {WhoMadeAction}.", WhoMadeAction());
                LocationMode.Log($"House set to Away, {WhoMadeAction}.");
                LocationMode?.SelectOption(LocationModeOptions.Away);
            }
            else if ((Andy.IsHome() && !Claire.IsHome())
                || (!Andy.IsHome() && Claire.IsHome()))
            {
                _logger.LogDebug("House set to OneAway, {WhoMadeAction}.", WhoMadeAction());
                LocationMode.Log($"House set to OneAway, {WhoMadeAction}.");
                LocationMode?.SelectOption(LocationModeOptions.OneAway);
            }
            else if (Andy.IsHome() && Claire.IsHome())
            {
                _logger.LogDebug("House set to Home, {WhoMadeAction}.", WhoMadeAction());
                LocationMode.Log($"House set to Home, {WhoMadeAction}.");
                LocationMode?.SelectOption(LocationModeOptions.Home);
            }
            else if (manualChange)
            {
                _logger.LogDebug("House set to {State} by manual change.", LocationMode?.State);
                LocationMode.Log($"House set to {LocationMode?.State}.");
            }

            Reset();
        }
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