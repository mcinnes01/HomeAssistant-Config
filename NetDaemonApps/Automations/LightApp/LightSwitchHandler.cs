namespace NetDaemonApps.Automations.LightApp;

public class LightSwitchHandler: AvailableEnabledHandler
{
    INotificationService notify;
    IScheduler scheduler;
    LightEntity light;
    BinarySensorEntity? occupancySensor;
    NumericSensorEntity? illuminanceSensor;
    InputNumberEntity? illuminanceThreshold;
    SunEntity? sun;
    InputNumberEntity? overrideThreshold;
    bool isLamp;

    public LightSwitchHandler(LightEntity light, IHaContext context, IScheduler scheduler,
        INotificationService notify, InputBooleanEntity enabledToggle) 
        : base(light, enabledToggle)
    {
        this.light = light;
        this.notify = notify;
        this.scheduler = scheduler;

        var id = light.EntityId.Substring(light.EntityId.IndexOf('.') + 1);
        if (string.IsNullOrEmpty(id))
            return;

        var entityParts = id.Split('_');
        if (entityParts == null)
            return;

		if (entityParts?.Length > 0 && entityParts[entityParts.Length - 1] == "lamp")
        {
            isLamp = true;
            entityParts = entityParts.Take(entityParts.Length - 1).ToArray();
        }
				
        var roomSpecifiers = new[] { "room", "hall" };
        // Get the room from the lights area
        var room = light.Area ?? 
        // Otherwise try to extract it form the light name
        (entityParts.Length == 1 || !roomSpecifiers.Contains(entityParts[1]) ?
            entityParts[0] : $"{entityParts[0]}_{entityParts[1]}");
        
        var occupancySensorId = context.GetEntityId("binary_sensor." + room + "_motion");
        var illuminanceSensorId = context.GetEntityId("sensor.weather_station_ambient_light");
        var sunId = context.GetEntityId("sun.sun");
        var illuminanceThresholdId = context.GetEntityId("input_number." + room + "_light_automation_lux_threshold");
        var overrideThresholdId = context.GetEntityId("input_number." + room + "_light_automation_override_threshold");

        if (!String.IsNullOrEmpty(illuminanceSensorId))       
            illuminanceSensor = new NumericSensorEntity(context, illuminanceSensorId);
            
        if (!String.IsNullOrEmpty(sunId))       
            sun = new SunEntity(context, sunId);

        if (!String.IsNullOrEmpty(occupancySensorId))
            occupancySensor = new BinarySensorEntity(context, occupancySensorId);

        if (!String.IsNullOrEmpty(illuminanceThresholdId))
            illuminanceThreshold = new InputNumberEntity(context, illuminanceThresholdId);

        if (!String.IsNullOrEmpty(overrideThresholdId))
            overrideThreshold = new InputNumberEntity(context, overrideThresholdId);

        occupancySensor?.StateChanges()
           .Where(occ => occ.New.IsDetected())
           .Subscribe(_ => { isOccupied = true; Handle(); });

        occupancySensor?.StateChanges()
            .WhenStateIsFor(occ => occ.IsCleared(), TimeSpan.FromSeconds(120))
            .Subscribe(_ => { isOccupied = false; Handle(); });

        illuminanceSensor?.StateChanges()
            .Where(i => (i.New == null && sun.IsBelowHorizon()) || i.New?.State <= illuminanceThresholdValue)            
            .Subscribe(i => { isTooDark = true; Handle(); });

        illuminanceSensor?.StateChanges()
            .Where(i => (i.New == null && sun.IsAboveHorizon()) || i.New?.State >= illuminanceThresholdValue)
            .Subscribe(_ => { isTooDark = false; Handle(); });

        illuminanceThreshold?.StateChanges()
            .Subscribe(_ => { isTooDark = illuminanceSensor?.State <= illuminanceThresholdValue; Handle(); });

        sun?.StateChanges()
            .Where(s => illuminanceSensor?.State == null)
            .Subscribe(s => { isTooDark = s.New.IsBelowHorizon(); });

        overrideThreshold?.StateChanges()
            .Subscribe(_ => HandleOverride());

        light.WhenOn(s => LightTurnedOn());

        light.WhenOff(s => LightTurnedOff()); 

        isOccupied = occupancySensor?.IsDetected() ?? false;
        isTooDark = illuminanceSensor?.State <= illuminanceThresholdValue;
        Handle();
    }

    private void HandleOverride()
    {
        if (personHasTurnedItOn)
        {
            TimeSpan elapsedFromSchedule = DateTime.UtcNow - onOverrideScheduled;
            onOverride?.Dispose();
            if (elapsedFromSchedule.TotalMinutes >= overrideThresholdValue)
                personHasTurnedItOn = false;
            else
            {
                var remaining = overrideThresholdValue - elapsedFromSchedule.TotalMinutes;
                onOverride = scheduler.Schedule(TimeSpan.FromMinutes(remaining), () => personHasTurnedItOn = false);
            }
        }

        if (personHasTurnedItOff)
        {
            TimeSpan elapsedFromSchedule = DateTime.UtcNow - offOverrideScheduled;
            offOverride?.Dispose();
            if (elapsedFromSchedule.TotalMinutes >= overrideThresholdValue)
                personHasTurnedItOff = false;
            else
            {
                var remaining = overrideThresholdValue - elapsedFromSchedule.TotalMinutes;
                offOverride = scheduler.Schedule(TimeSpan.FromMinutes(remaining), () => personHasTurnedItOff = false);
            }
        }
    }

    IDisposable? offOverride;
    IDisposable? onOverride;

    DateTime onOverrideScheduled;
    DateTime offOverrideScheduled;

    double overrideThresholdValue =>
        overrideThreshold?.State ?? 30;
    double illuminanceThresholdValue =>
        illuminanceThreshold?.State ?? 3500;        

    private void LightTurnedOff()
    {
        if (turnedOffByHandler)
            turnedOffByHandler = false;
        else
        {
            if (personHasTurnedItOn)
            {
                personHasTurnedItOn = false;
                onOverride?.Dispose();
                onOverride = null;
            }
            else
            {
                personHasTurnedItOff = true;
                offOverride = scheduler.Schedule(TimeSpan.FromMinutes(overrideThresholdValue), () => personHasTurnedItOff = false);
                offOverrideScheduled = DateTime.UtcNow;
            }
        }
    }

    void LightTurnedOn()
    {
        if (turnedOnByHandler)
            turnedOnByHandler = false;
        else
        {
            if (personHasTurnedItOff)
            {
                personHasTurnedItOff = false;
                offOverride?.Dispose();
                offOverride = null;
            }
            else
            {
                personHasTurnedItOn = true;
                onOverride = scheduler.Schedule(TimeSpan.FromMinutes(overrideThresholdValue), () => personHasTurnedItOn = false);
                onOverrideScheduled = DateTime.UtcNow;
            }
        }
    }

    bool isOccupied;
    bool isTooDark;

    bool turnedOnByHandler;
    bool turnedOffByHandler;

    bool personHasTurnedItOff;
    bool personHasTurnedItOn;

    void Handle()
    {
          if (IsAvailable && IsEnabled && !personHasTurnedItOff && !personHasTurnedItOn)
        {
            if (!isOccupied || !isTooDark)            
                TurnOff();
            else if (isOccupied && isTooDark)
                TurnOn();
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

    private void TurnOn()
    {
        if (light.IsOff())
        {            
            turnedOnByHandler = true;
            light.TurnOn();
            //notify.Send(ChannelTarget.State, String.Format(notify.GetMessage("light_on")!, light.Attributes?.FriendlyName));
        }
    }

    private void TurnOff()
    {
        if (light.IsOn())
        {                        
            turnedOffByHandler = true;
            light.TurnOff();
            //notify.Send(ChannelTarget.State, String.Format(notify.GetMessage("light_off")!, light.Attributes?.FriendlyName));
        }
    }
}