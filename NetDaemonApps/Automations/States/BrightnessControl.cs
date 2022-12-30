namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class BrightnessController
{
    LogbookServices Logbook;
    private readonly ILogger<BrightnessController> logger;
    private readonly IEntities entities;
    InputNumberEntity? darkThreshold;
    InputNumberEntity? brightThreshold;
    NumericSensorEntity? illuminanceSensor;
    InputSelectEntity? timeOfDay;
    InputSelectEntity? brightness;
    SunEntity? sun;
    InputBooleanEntity? IsEnabled;
    bool isTooDark;
    bool sensorFault;
    bool isMaxBrightness;
    DateTime? timeInState;

    public BrightnessController(IHaContext context, IServices services, ILogger<BrightnessController> logger)
    {
        Logbook = services.Logbook;
        this.logger = logger;
        this.entities = new Entities(context);

        illuminanceSensor = entities.Sensor.WeatherStationAmbientLight;
        darkThreshold = entities.InputNumber.BrightnessDarkThreshold;
        brightThreshold = entities.InputNumber.BrightnessBrightThreshold;
        brightness = entities.InputSelect.Brightness;
        timeOfDay = entities.InputSelect.TimeOfDay;
        sun = entities.Sun.Sun;
        IsEnabled = entities.InputBoolean.TimeOfDayEnabled;
        timeInState = brightness.EntityState?.LastChanged;

        illuminanceSensor?.StateChanges()
            .Where(i => i.New == null || i.New.IsUnavailable() || i.New.IsUnknown())
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                sensorFault = true;
                Handle();
            });

        illuminanceSensor?.StateChanges()
            .Where(i => i.New?.State < brightThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                sensorFault = false;
                isTooDark = true;
                Handle();
            });

        illuminanceSensor?.StateChanges()
            .Where(i => i.New?.State >= brightThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                sensorFault = false;
                isTooDark = false;
                isMaxBrightness = true;
                Handle();
            });

        brightThreshold?.StateChanges()
            .Subscribe(_ =>
            {
                // TODO doesn't handle sensor fault at start could produce error, 
                //basic handling added but something to do with sun would help
                isTooDark = sensorFault ? false : illuminanceSensor?.State <= brightThreshold?.State;
                isMaxBrightness = sensorFault ? false : !isTooDark;
                Handle();
            });

        sun?.StateChanges()
            .Subscribe(s =>
            {
                Handle();
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
        sensorFault = illuminanceSensor?.State == null ||
            illuminanceSensor.IsUnavailable() ||
            illuminanceSensor.IsUnknown();
        // TODO doesn't handle sensor fault at start could produce error, 
        //basic handling added but something to do with sun would help
        isTooDark = sensorFault ? false : illuminanceSensor?.State <= brightThreshold?.State;
        isMaxBrightness = sensorFault ? false : !isTooDark;
        Handle();
    }    
    
    BrightnessOptions MapBrightness(NumericEntityState<HomeAssistantGenerated.NumericSensorAttributes>? entityState) =>
    entityState?.State switch
    {
        <= Constants.DARK_THRESHOLD => BrightnessOptions.Dark,
        >= Constants.BRIGHT_THRESHOLD => BrightnessOptions.Bright,
        null => sun!.Attributes?.Elevation > 2 ? BrightnessOptions.Bright : BrightnessOptions.Dim,
        _ => sun!.Attributes?.Elevation > 2 ? BrightnessOptions.Bright : BrightnessOptions.Dim,
    };

    void Handle()
    {
        if (IsEnabled.IsOn())
        {
            if (!sensorFault)
            {
                var brightnessState = MapBrightness(illuminanceSensor!.EntityState);
                Logbook.Log(entityId: brightness!.EntityId,
                message: $"Lux: {illuminanceSensor.State}, setting brightness to {brightnessState.ToString()}.",
                name: "Brightness",
                domain: "InputSelect");
                brightness!.SelectOption(brightnessState);
            }
            else
            {
                if (sun.IsAboveHorizon() &&
                    isMaxBrightness &&
                    DateTime.TryParse(sun?.Attributes?.NextSetting, out DateTime nextSetting) &&
                    DateTime.TryParse(sun?.Attributes?.NextRising, out DateTime nextRising) &&
                    nextSetting < nextRising &&
                    nextSetting > DateTime.Now.AddHours(2))
                {
                    Logbook.Log(entityId: brightness!.EntityId,
                    message: $"Lux sensor fault, using sun, previous state and time of day to set brightness: Bright.",
                    name: "Brightness",
                    domain: "InputSelect");
                    brightness?.SelectOption(BrightnessOptions.Bright);
                }
                else if (sun.IsAboveHorizon())
                {
                    Logbook.Log(entityId: brightness!.EntityId,
                    message: $"Lux sensor fault, using sun and time of day to set brightness Dim.",
                    name: "Brightness",
                    domain: "InputSelect");
                    brightness?.SelectOption(BrightnessOptions.Dim);
                    isMaxBrightness = false;
                }
                else
                {
                    Logbook.Log(entityId: brightness!.EntityId,
                    message: $"Lux sensor fault, using sun below horizon to set brightness Dark.",
                    name: "Brightness",
                    domain: "InputSelect");
                    brightness?.SelectOption(BrightnessOptions.Dark);
                    isMaxBrightness = false;
                }
            }
        }
    }
}