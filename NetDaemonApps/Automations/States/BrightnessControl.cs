namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class BrightnessController
{
    private readonly ILogger<BrightnessController> logger;
    private readonly IEntities entities;
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
        this.logger = logger;
        this.entities = new Entities(context);

        IlluminanceSensor = entities.Sensor.WeatherStationAmbientLight;
        DarkThreshold = entities.InputNumber.BrightnessDarkThreshold;
        BrightThreshold = entities.InputNumber.BrightnessBrightThreshold;
        Brightness = entities.InputSelect.Brightness;
        TimeOfDay = entities.InputSelect.TimeOfDay;
        Sun = entities.Sun.Sun;
        IsEnabled = entities.InputBoolean.TimeOfDayEnabled;
        TimeInState = Brightness.EntityState?.LastChanged;

        // Lux sensor goes out of range or loses connection
        IlluminanceSensor?.StateChanges()
            .Where(i => i.New == null || i.New.IsUnavailable() || i.New.IsUnknown())
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(i =>
            {
                lastState = i.Old?.State?.ToString();
                sensorFault = true;
                Handle(Trigger.LuxFault);
            });

        // Lux below dark threshold
        IlluminanceSensor?.StateChanges()
            .Where(i => i.New?.State <= DarkThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                sensorFault = false;
                Handle(Trigger.SensorDark);
            });

        // Lux in dim range
        IlluminanceSensor?.StateChanges()
            .Where(i => i.New?.State < BrightThreshold?.State
                     && i.New?.State > DarkThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                sensorFault = false;
                Handle(Trigger.SensorDim);
            });

        // Lux above bright threshold
        IlluminanceSensor?.StateChanges()
            .Where(i => i.New?.State >= BrightThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                sensorFault = false;
                Handle(Trigger.SensorBright);
            });

        // Update brightness when sensor is working and dark theshold is changed
        DarkThreshold?.StateChanges()
            .Where(_ => !sensorFault)
            .Subscribe(_ =>
            {
                Handle(Trigger.DarkThreshold);
            });

        // Update brightness when sensor is working and bright theshold is changed
        BrightThreshold?.StateChanges()
            .Where(_ => !sensorFault)
            .Subscribe(_ =>
            {
                Handle(Trigger.BrightThreshold);
            });

        // Observe sun changes when the sensor is in fault
        Sun?.StateChanges()
            .Where(_ => sensorFault)
            .Subscribe(s =>
            {
                Handle(Trigger.Sun);
            });

        // Observe time of day changes when the sensor is in fault
        TimeOfDay.StateChanges()
            .Where(_ => sensorFault)
            .Subscribe(s =>
            {
                Handle(Trigger.TimeOfDay);
            });

        IsEnabled?.StateChanges()
            .Where(s => s.New.IsOn())
            .Subscribe(_ =>
            {
                Init();
            });
        
        Init();
    }

    void Init()
    {
        sensorFault = IlluminanceSensor?.State == null ||
            IlluminanceSensor.IsUnavailable() ||
            IlluminanceSensor.IsUnknown();
        Handle();
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
                    if (Sun.IsAboveHorizon() &&
                    DateTime.TryParse(Sun?.Attributes?.NextSetting, out DateTime nextSetting) &&
                    DateTime.TryParse(Sun?.Attributes?.NextRising, out DateTime nextRising) &&
                    nextSetting < nextRising &&
                    nextSetting > DateTime.Now.AddHours(2) &&
                    TimeOfDay!.IsNotOption(TimeOfDayOptions.Night))
                    {
                        Brightness.Log($"Trigger: {trigger}, Lux sensor fault, using sun, previous state and time of day to set brightness: Bright.");
                        Brightness?.SelectOption(BrightnessOptions.Bright);
                    }
                    else if (Sun.IsAboveHorizon() || TimeOfDay!.IsNotOption(TimeOfDayOptions.Night))
                    {
                        Brightness.Log($"Trigger: {trigger}, Lux sensor fault, using sun and time of day to set brightness Dim.");
                        Brightness?.SelectOption(BrightnessOptions.Dim);
                    }
                    else
                    {
                        Brightness.Log($"Trigger: {trigger}, Lux sensor fault, using sun below horizon to set brightness Dark.");
                        Brightness?.SelectOption(BrightnessOptions.Dark);
                    }
                    break;
                case Trigger.DarkThreshold:
                case Trigger.BrightThreshold:
                default:
                    Brightness!.SelectOption(MapBrightness(IlluminanceSensor?.EntityState));
                    break;
            };

            Brightness.Log($"Trigger: {trigger}, Lux: {IlluminanceSensor?.State}, setting brightness to {Brightness.State}.");
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