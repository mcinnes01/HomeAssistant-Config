
using NetDaemonApps.Infrastructure;

namespace NetDaemonApps.Automations.LightApp;

public class RGBHandler : AvailableEnabledHandler
{
    ILogger logger;
    IEntities entities;
    InputNumberEntity? minBrightness;
    InputNumberEntity? maxBrightness;
    InputNumberEntity? illuminanceThreshold;
    LightEntity light;
    NumericSensorEntity? illuminanceSensor;
    BinarySensorEntity? occupancySensor;
    BinarySensorEntity? motionSensor;
    InputSelectEntity? mode;
    INotificationService notify;

    public RGBHandler(LightEntity light, IHaContext context, IEntities entities, ILogger logger, INotificationService notify, 
        InputBooleanEntity enabledToggle) 
        : base(light, enabledToggle)
    {
        this.logger = logger;
        this.light = light;
        this.entities = entities;
        this.notify = notify;

        var id = light.EntityId.Substring(light.EntityId.IndexOf('.') + 1);
        var room = id.Substring(0, id.IndexOf('_'));

        var allEntities = context.GetAllEntities().Select(e => e.EntityId);
        var occupancySensorId = allEntities.FirstOrDefault(e => e == "binary_sensor." + room + "_occupancy");
        var illuminanceSensorId = allEntities.FirstOrDefault(e => e == "sensor.illuminance");
        var illuminanceThresholdId = allEntities.FirstOrDefault(e => e == "input_number." + room + "_rgb_automation_lux_threshold");
        var motionSendsorId = allEntities.FirstOrDefault(e => e == "binary_sensor." + room + "_motion");
        var modeId = allEntities.FirstOrDefault(e => e == "input_select." + room + "_rgb_automation_mode");
        var minBrightnessId = allEntities.FirstOrDefault(e => e == "input_number." + room + "_rgb_automation_ambient_brightness");
        var maxBrightnessId = allEntities.FirstOrDefault(e => e == "input_number." + room + "_rgb_automation_full_brightness");

        if (!String.IsNullOrEmpty(illuminanceSensorId))
            illuminanceSensor = new NumericSensorEntity(context, illuminanceSensorId);

        if (!String.IsNullOrEmpty(occupancySensorId))
            occupancySensor = new BinarySensorEntity(context, occupancySensorId);

        if (!String.IsNullOrEmpty(illuminanceThresholdId))
            illuminanceThreshold = new InputNumberEntity(context, illuminanceThresholdId);

        if (!String.IsNullOrEmpty(motionSendsorId))
            motionSensor = new BinarySensorEntity(context, motionSendsorId);

        if (!String.IsNullOrEmpty(modeId))
            mode = new InputSelectEntity(context, modeId);

        if (!String.IsNullOrEmpty(minBrightnessId))
            minBrightness = new InputNumberEntity(context, minBrightnessId);

        if (!String.IsNullOrEmpty(maxBrightnessId))
            maxBrightness = new InputNumberEntity(context, maxBrightnessId);

        occupancySensor?.StateChanges()
            .Where(occ => occ.New.IsDetected())
            .Subscribe(_ => { isOccupied = true; Handle(); });

        occupancySensor?.StateChanges()
            .WhenStateIsFor(occ => occ.IsCleared(), TimeSpan.FromSeconds(60))
            .Subscribe(_ => { isOccupied = false; Handle(); });
     
        motionSensor?.StateChanges()
            .Where(mot => mot.New.IsDetected())
            .Subscribe(_ => { isMoving = true; Handle(); });

        motionSensor?.StateChanges()
            .WhenStateIsFor(mot => mot.IsCleared(), TimeSpan.FromSeconds(60))
            .Subscribe(_ => { isMoving =false; Handle(); });

        illuminanceSensor?.StateChanges()
            .Where(i => i.New?.State < illuminanceThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => { isTooDark = true; Handle(); });

        illuminanceSensor?.StateChanges()
            .Where(i => i.New?.State >= illuminanceThreshold?.State)
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => { isTooDark = false; Handle(); });

        illuminanceThreshold?.StateChanges()
            .Subscribe(_ => { isTooDark = illuminanceSensor?.State <= illuminanceThreshold?.State; Handle(); });

        entities.Sun.Sun.StateChanges()
            .Where(s => s.New.IsBelowHorizon())
            .Subscribe(_ => { if (mode?.State == "sunset") { isRightTime = true; Handle(); } });

        entities.Sun.Sun.StateChanges()
            .Where(s => s.New.IsAboveHorizon())
            .Subscribe(_ => { if (mode?.State == "sunset") { isRightTime = false; Handle(); } });

        entities.InputSelect.TimeOfDay.StateChanges()
            .Where(s => s.New.IsOption(TimeOfDayOptions.Evening))
            .Subscribe(_ => { if (mode?.State == "evening") { isRightTime = true; Handle(); } });

        entities.InputSelect.TimeOfDay.StateChanges()
            .Where(s => s.New.IsNotOption(TimeOfDayOptions.Evening))
            .Subscribe(_ => { if (mode?.State == "evening") { isRightTime = false; Handle(); } });

        isOccupied = occupancySensor.IsDetected();
        isMoving = motionSensor.IsDetected();
        isTooDark = illuminanceSensor?.State <= illuminanceThreshold?.State;
        isRightTime = mode?.State == "always" || 
            (mode?.State == "evening" && entities.InputSelect.TimeOfDay.IsOption(TimeOfDayOptions.Evening)) || 
            (mode?.State == "sunset" && entities.Sun.Sun.IsBelowHorizon());
        
        Handle();
    }

    bool isOccupied;
    bool isTooDark;
    bool isMoving;
    bool isRightTime;

    void Handle()
    {
        logger.LogDebug($"{ light.Attributes?.FriendlyName } - on: {light.IsOn()}, avail: {IsAvailable}, enabled: {IsEnabled}, dark: {isTooDark}, occ: {isOccupied} mov: {isMoving}, right: {isRightTime}");

        if (IsAvailable && IsEnabled)
        {
            if (!isTooDark && light.IsOn())
                isTooDark = true;

            if (!isOccupied || !isTooDark || !isRightTime)
                TurnOff();
            else if (isOccupied && !isMoving)
                TurnOn((long)(minBrightness?.State ?? 10));
            else if (isOccupied && isMoving)
                TurnOn((long)(maxBrightness?.State ?? 100));
        }
    }

    protected override void OnAvailable(bool value)
    {
        if (value)
            Handle();
    }

    protected override void OnEnabled(bool value)
    {
        if (value)
            Handle();
    }

    private void TurnOn(long brightness)
    {
        if (light.IsOff())
        {
            logger.LogInformation($"{ light.Attributes?.FriendlyName } - turning on");
            light.TurnOn(transition: 3, brightnessPct: brightness);
            //notify.Send(ChannelTarget.State, String.Format(notify.GetMessage("light_on")!, light.Attributes?.FriendlyName));
        }
        else
        {
            double br = Math.Round(brightness * 255.0 / 100, MidpointRounding.AwayFromZero);
            var lbr = light.Attributes?.Brightness ?? 0;
            if (br != lbr)
            {
                logger.LogInformation($"{ light.Attributes?.FriendlyName } - setting brightness to {br:0} instead of {lbr:0}");
                light.TurnOn(transition: 3, brightnessPct: brightness);
            }
        }
    }

    private void TurnOff()
    {
        if (light.IsOn())
        {
            logger.LogInformation($"{ light.Attributes?.FriendlyName } - turning off");
            light.TurnOff();
            //notify.Send(ChannelTarget.State, String.Format(notify.GetMessage("light_off")!, light.Attributes?.FriendlyName));
        }
    }
}