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

        // Lux sensor goes out of range or loses connection
        IlluminanceSensor?.StateChanges()
            .Where(i => i.IsFaulted())
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(i =>
            {
                _logger.LogWarning("Fault on the illuminance sensor.", new { Entity = Brightness });
                sensorFault = true;
                Handle(BrightnessTrigger.LuxFault);
            });

        // Lux sensor threshold change
        IlluminanceSensor?.StateAllChangesWithCurrent()
        .Where(i => !i.IsFaulted() && MapBrightness(i.Old) != MapBrightness(i.New))
        .Select(e => (Lux: e.New?.State, Option: MapBrightness(e.New)))
        .Subscribe(e =>
        {
            _logger.LogDebug("Transitioning Brightness to: {To} - Ambient Light {Lux}lx",
                e.Option, e.Lux, new { Entity = Brightness });
            sensorFault = false;
            Handle(GetTransition(e.Option));
        });

        // Update brightness when sensor is working and dark theshold is changed
        DarkThreshold?.StateChanges()
            .Where(_ => !sensorFault)
            .Throttle(TimeSpan.FromMinutes(1))
            .Subscribe(b =>
            {
                _logger.LogDebug("Dark threshold was changed to {Lux}.", b.New?.State, new { Entity = Brightness });
                Handle(BrightnessTrigger.DarkThreshold);
            });

        // Update brightness when sensor is working and bright theshold is changed
        BrightThreshold?.StateChanges()
            .Where(_ => !sensorFault)
            .Throttle(TimeSpan.FromMinutes(1))
            .Subscribe(b =>
            {
                _logger.LogDebug("Bright threshold was changed to {Lux}.", b.New?.State, new { Entity = Brightness });
                Handle(BrightnessTrigger.BrightThreshold);
            });

        // Observe sun changes when the sensor is in fault
        Sun?.StateChanges()
            .Where(_ => sensorFault)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(s =>
            {
                _logger.LogDebug("Sun changed to {Sun}.", s.New?.State, new { Entity = Brightness });
                Handle(BrightnessTrigger.Sun);
            });

        // Observe time of day changes when the sensor is in fault
        TimeOfDay.StateChanges()
            .Where(_ => sensorFault)
            .Throttle(TimeSpan.FromMinutes(1))
            .Subscribe(t =>
            {
                _logger.LogDebug("Time of day changed to {Time}.", t.New?.State, new { Entity = Brightness });
                Handle(BrightnessTrigger.TimeOfDay);
            });

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                _logger.LogDebug("Brightness control has been enabled.", new { Entity = Brightness });
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
            Handle(BrightnessTrigger.LuxFault);
        }
        else
        {
            Handle();
        }
    }

    BrightnessOptions MapBrightness(NumericEntityState<NumericSensorAttributes>? entityState) =>
    entityState?.State switch
    {
        <= Constants.DARK_THRESHOLD => BrightnessOptions.Dark,
        > Constants.DARK_THRESHOLD and < Constants.BRIGHT_THRESHOLD => BrightnessOptions.Dim,
        >= Constants.BRIGHT_THRESHOLD => BrightnessOptions.Bright,
        _ => BrightnessOptions.Dark
    };

    BrightnessTrigger GetTransition(BrightnessOptions to) => to switch
    {
        BrightnessOptions.Bright => BrightnessTrigger.SensorBright,
        BrightnessOptions.Dim => BrightnessTrigger.SensorDim,
        BrightnessOptions.Dark => BrightnessTrigger.SensorDark,
        _ => BrightnessTrigger.LuxFault
    };

    void Handle(BrightnessTrigger? trigger = null)
    {
        if (IsEnabled.IsOn())
        {
            switch (trigger)
            {
                case BrightnessTrigger.SensorDark:
                    _logger.LogDebug("Sensor is in Dark range, setting Brightness to Dark.", new { Entity = Brightness });
                    Brightness!.SelectOption(BrightnessOptions.Dark);
                    break;
                case BrightnessTrigger.SensorDim:
                    _logger.LogDebug("Sensor is in Dim range, setting Brightness to Dim.", new { Entity = Brightness });
                    Brightness!.SelectOption(BrightnessOptions.Dim);
                    break;
                case BrightnessTrigger.SensorBright:
                    _logger.LogDebug("Sensor is in Bright range, setting Brightness to Bright.", new { Entity = Brightness });
                    Brightness!.SelectOption(BrightnessOptions.Bright);
                    break;
                case BrightnessTrigger.LuxFault:
                case BrightnessTrigger.Sun:
                case BrightnessTrigger.TimeOfDay:
                    if (IlluminanceSensor?.State > 0.0)
                    {
                        var brightness = MapBrightness(IlluminanceSensor.EntityState);
                        _logger.LogDebug("BrightnessTrigger: {Trigger}, Lux: {Lux}, setting brightness to {Brightness}.",
                            trigger, IlluminanceSensor?.State, brightness, new { Entity = Brightness });
                        Brightness!.SelectOption(brightness);
                    }
                    else if (Sun.IsBelowHorizon())
                    {
                        _logger.LogDebug("BrightnessTrigger: {Trigger}, Lux sensor fault, using sun below horizon to set brightness Dark.",
                            trigger.ToString(), new { Entity = Brightness });
                        Brightness?.SelectOption(BrightnessOptions.Dark);
                    }
                    else if (Sun.IsAboveHorizon() &&
                    DateTime.TryParse(Sun?.Attributes?.NextSetting, out DateTime nextSetting) &&
                    DateTime.TryParse(Sun?.Attributes?.NextRising, out DateTime nextRising) &&
                    nextSetting < nextRising &&
                    nextSetting > DateTime.Now.AddHours(2) &&
                    TimeOfDay!.IsNotOption(TimeOfDayOptions.Night))
                    {
                        _logger.LogDebug("BrightnessTrigger: {Trigger}, Lux sensor fault, using sun, previous state and time of day to set brightness: Bright.",
                           trigger.ToString(), new { Entity = Brightness });
                        Brightness?.SelectOption(BrightnessOptions.Bright);
                    }
                    else
                    {
                        _logger.LogDebug("BrightnessTrigger: {Trigger}, Lux sensor fault, using sun and time of day to set brightness Dim.",
                            trigger.ToString(), new { Entity = Brightness });
                        Brightness?.SelectOption(BrightnessOptions.Dim);
                    }
                    break;
                case BrightnessTrigger.DarkThreshold:
                case BrightnessTrigger.BrightThreshold:
                default:
                    _logger.LogDebug("BrightnessTrigger: {Trigger}, Lux: {Lux}, setting brightness to {Brightness}.",
                        trigger?.ToString(), IlluminanceSensor?.State, Brightness?.State, new { Entity = Brightness });
                    Brightness!.SelectOption(MapBrightness(IlluminanceSensor?.EntityState));
                    break;
            };
        }
    }
}