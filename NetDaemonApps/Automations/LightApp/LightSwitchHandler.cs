namespace NetDaemonApps.Automations.LightApp;

public class LightSwitchHandler: AvailableEnabledHandler
{
    Entities _entities;
    INotificationService Notify;
    IScheduler Scheduler;
    LightEntity Light;
    BinarySensorEntity? OccupancySensor;
    InputSelectEntity? Brightness;
    bool isLamp;

    public LightSwitchHandler(LightEntity light, IHaContext context, IScheduler scheduler,
        INotificationService notify, InputBooleanEntity enabledToggle) 
        : base(light, enabledToggle)
    {
        _entities = new Entities(context);
        Light = light;
        Notify = notify;
        Scheduler = scheduler;

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
        var Brightness = context.GetEntityId("sensor.weather_station_ambient_light");

        // if (!String.IsNullOrEmpty(Brightness))
        //     Brightness = _entities.InputSelect.Brightness;

        if (!String.IsNullOrEmpty(occupancySensorId))
            OccupancySensor = new BinarySensorEntity(context, occupancySensorId);

        OccupancySensor?.StateChanges()
           .Where(occ => occ.New.IsDetected())
           .Subscribe(_ => { isOccupied = true; Handle(); });

        OccupancySensor?.StateChanges()
            .WhenStateIsFor(occ => occ.IsCleared(), TimeSpan.FromSeconds(120))
            .Subscribe(_ => { isOccupied = false; Handle(); });

        // sun?.StateChanges()
        //     .Where(s => illuminanceSensor?.State == null)
        //     .Subscribe(s => { isTooDark = s.New.IsBelowHorizon(); });

        // overrideThreshold?.StateChanges()
        //     .Subscribe(_ => HandleOverride());

        light.WhenOn(s => LightTurnedOn());

        light.WhenOff(s => LightTurnedOff()); 

        isOccupied = OccupancySensor?.IsDetected() ?? false;
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
                onOverride = Scheduler.Schedule(TimeSpan.FromMinutes(remaining), () => personHasTurnedItOn = false);
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
                offOverride = Scheduler.Schedule(TimeSpan.FromMinutes(remaining), () => personHasTurnedItOff = false);
            }
        }
    }

    IDisposable? offOverride;
    IDisposable? onOverride;

    DateTime onOverrideScheduled;
    DateTime offOverrideScheduled;

    double overrideThresholdValue = 30;
    double illuminanceThresholdValue = 3500;        

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
                offOverride = Scheduler.Schedule(TimeSpan.FromMinutes(overrideThresholdValue), () => personHasTurnedItOff = false);
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
                onOverride = Scheduler.Schedule(TimeSpan.FromMinutes(overrideThresholdValue), () => personHasTurnedItOn = false);
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
        if (Light.IsOff())
        {            
            turnedOnByHandler = true;
            Light.TurnOn();
            //notify.Send(ChannelTarget.State, String.Format(notify.GetMessage("light_on")!, light.Attributes?.FriendlyName));
        }
    }

    private void TurnOff()
    {
        if (Light.IsOn())
        {                        
            turnedOffByHandler = true;
            Light.TurnOff();
            //notify.Send(ChannelTarget.State, String.Format(notify.GetMessage("light_off")!, light.Attributes?.FriendlyName));
        }
    }
}