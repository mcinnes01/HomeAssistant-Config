namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class BrightnessController
{
    private readonly ILogger<BrightnessController> _logger;
    private readonly IEntities _entities;
    InputNumberEntity? DarkThreshold;
    InputNumberEntity? BrightThreshold;
    NumericSensorEntity? IlluminanceSensor;
    InputSelectEntity? TimeOfDay;
    InputSelectEntity? Brightness;
    SunEntity? Sun;
    InputBooleanEntity? IsEnabled;
    bool sensorFault;
    string? lastState;
    DateTime? TimeInState;


    public BrightnessController(IHaContext context, ILogger<BrightnessController> logger)
    {
        _logger = logger;
        _entities = new Entities(context);

        IlluminanceSensor = _entities.Sensor.WeatherStationAmbientLight;
        DarkThreshold = _entities.InputNumber.BrightnessDarkThreshold;
        BrightThreshold = _entities.InputNumber.BrightnessBrightThreshold;
        Brightness = _entities.InputSelect.Brightness;
        TimeOfDay = _entities.InputSelect.TimeOfDay;
        Sun = _entities.Sun.Sun;
        IsEnabled = _entities.InputBoolean.BrightnessControlEnabled;
        TimeInState = Brightness.EntityState?.LastChanged;

        // Lux sensor goes out of range or loses connection
        IlluminanceSensor?.StateChanges()
            .Where(i => i.New == null || i.New.IsUnavailable() || i.New.IsUnknown())
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(i =>
            {
                _logger.LogWarning("Fault on the illuminance sensor.");
                lastState = i.Old?.State?.ToString();
                sensorFault = true;
                Handle(Trigger.LuxFault);
            });

        // Lux sensor threshold change
        IlluminanceSensor?.StateAllChangesWithCurrent()
        .Where(e => !sensorFault && MapBrightness(e.Old) != MapBrightness(e.New))
        .Throttle(TimeSpan.FromMinutes(3))
        .Select(e => (Lux: e.New?.State, Option: MapBrightness(e.New)))
        .Subscribe(e => 
        {
            _logger.LogDebug($"Transitioning Brightness to: {e.Option} - Ambient Light {e.Lux}lx");
            sensorFault = false;
            Handle(GetTransition(e.Option));
        });

        // Update brightness when sensor is working and dark theshold is changed
        DarkThreshold?.StateChanges()
            .Where(_ => !sensorFault)
            .Throttle(TimeSpan.FromMinutes(1))
            .Subscribe(b =>
            {
                _logger.LogDebug("Dark threshold was changed to {Lux}.", b.New?.State);
                Handle(Trigger.DarkThreshold);
            });

        // Update brightness when sensor is working and bright theshold is changed
        BrightThreshold?.StateChanges()
            .Where(_ => !sensorFault)
            .Throttle(TimeSpan.FromMinutes(1))
            .Subscribe(b =>
            {
                _logger.LogDebug("Bright threshold was changed to {Lux}.", b.New?.State);
                Handle(Trigger.BrightThreshold);
            });

        // Observe sun changes when the sensor is in fault
        Sun?.StateChanges()
            .Where(_ => sensorFault)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(s =>
            {
                _logger.LogDebug("Sun changed to {Sun}.", s.New?.State);
                Handle(Trigger.Sun);
            });

        // Observe time of day changes when the sensor is in fault
        TimeOfDay.StateChanges()
            .Where(_ => sensorFault)
            .Throttle(TimeSpan.FromMinutes(1))
            .Subscribe(t =>
            {
                _logger.LogDebug("Time of day changed to {Time}.", t.New?.State);
                Handle(Trigger.TimeOfDay);
            });

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                _logger.LogDebug("Brightness control has been enabled.");
                Init();
            });
        
        Init();
    }

    void Init()
    {
        sensorFault = IlluminanceSensor?.State == null ||
            IlluminanceSensor.IsUnavailable() ||
            IlluminanceSensor.IsUnknown();
        if (sensorFault)
        {
            Handle(Trigger.LuxFault);
        } 
        else 
        {
            Handle();
        }
    }    
    
    BrightnessOptions MapBrightness(NumericEntityState<HomeAssistantGenerated.NumericSensorAttributes>? entityState) =>
    entityState?.State switch
    {
        <= Constants.DARK_THRESHOLD => BrightnessOptions.Dark,
        > Constants.DARK_THRESHOLD and < Constants.BRIGHT_THRESHOLD => BrightnessOptions.Dim,
        >= Constants.BRIGHT_THRESHOLD => BrightnessOptions.Bright,
        null => Sun!.Attributes?.Elevation > 2 ? BrightnessOptions.Bright : BrightnessOptions.Dim,
        _ => Sun!.Attributes?.Elevation > 2 ? BrightnessOptions.Bright : BrightnessOptions.Dim,
    };

    Trigger GetTransition(BrightnessOptions to) => to switch
    {
        BrightnessOptions.Bright => Trigger.SensorBright,
        BrightnessOptions.Dim => Trigger.SensorDim,
        BrightnessOptions.Dark => Trigger.SensorDark,
        _ => Trigger.LuxFault
    };

    void Handle(Trigger? trigger = null)
    {
        if (IsEnabled.IsOn())
        {
            switch (trigger)
            {
                case Trigger.SensorDark: 
                    Brightness!.SelectOption(BrightnessOptions.Dark);
                    break;
                case Trigger.SensorDim: 
                    Brightness!.SelectOption(BrightnessOptions.Dim);
                    break;
                case Trigger.SensorBright:
                    Brightness!.SelectOption(BrightnessOptions.Bright);
                    break;
                case Trigger.LuxFault:
                case Trigger.Sun:
                case Trigger.TimeOfDay:
                    if (Sun.IsBelowHorizon())
                    {
                        Brightness.Log($"Trigger: {trigger}, Lux sensor fault, using sun below horizon to set brightness Dark.");
                        Brightness?.SelectOption(BrightnessOptions.Dark);
                    }
                    else if (Sun.IsAboveHorizon() &&
                    DateTime.TryParse(Sun?.Attributes?.NextSetting, out DateTime nextSetting) &&
                    DateTime.TryParse(Sun?.Attributes?.NextRising, out DateTime nextRising) &&
                    nextSetting < nextRising &&
                    nextSetting > DateTime.Now.AddHours(2) &&
                    TimeOfDay!.IsNotOption(TimeOfDayOptions.Night))
                    {
                        Brightness.Log($"Trigger: {trigger}, Lux sensor fault, using sun, previous state and time of day to set brightness: Bright.");
                        Brightness?.SelectOption(BrightnessOptions.Bright);
                    }
                    else
                    {
                        Brightness.Log($"Trigger: {trigger}, Lux sensor fault, using sun and time of day to set brightness Dim.");
                        Brightness?.SelectOption(BrightnessOptions.Dim);
                    }
                    break;
                case Trigger.DarkThreshold:
                case Trigger.BrightThreshold:
                default:
                    Brightness.Log($"Trigger: {trigger?.ToString()}, Lux: {IlluminanceSensor?.State}, setting brightness to {Brightness?.State}.");
                    Brightness!.SelectOption(MapBrightness(IlluminanceSensor?.EntityState));
                    break;
            };
        }
    }

    enum Trigger
    {
        DarkThreshold,
        BrightThreshold,
        LuxFault,
        SensorBright,
        SensorDim,
        SensorDark,
        Sun,
        TimeOfDay
    }
}