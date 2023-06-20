namespace NetDaemonApps.Automations.LightApp;

//[NetDaemonApp]
public class LightApp
{
    private readonly IEntities entities;

    IList<LightSwitchHandler> lightSwitches = new List<LightSwitchHandler>();
    IList<RGBHandler> rgbLights = new List<RGBHandler>();

    public LightApp(IHaContext haContext, ILogger<LightApp> logger, IScheduler scheduler, INotificationService notificationService)
    {
        this.entities = new Entities(haContext);

        lightSwitches.Add(new LightSwitchHandler(entities.Light.Lounge, haContext, scheduler,
            notificationService, entities.InputBoolean.LoungeLightAutomation));

        lightSwitches.Add(new LightSwitchHandler(entities.Light.Lounge, haContext, scheduler,
            notificationService, entities.InputBoolean.LoungeLightAutomation));

        // lightSwitches.Add(new LightSwitchHandler(entities.Light.KitchenSwitch, haContext, scheduler,
        //     notificationService, entities.InputBoolean.KitchenLightAutomation));

        rgbLights.Add(new RGBHandler(entities.Light.LoungeCornerLamp, haContext, entities, logger, notificationService, entities.InputBoolean.LoungeLampAutomation, scheduler));

        //rgbLights.Add(new RGBHandler(entities.Light.DrawingRoomFloorLamp, haContext, entities, logger, notificationService, entities.InputBoolean.LoungeLampAutomation));

        // rgbLights.Add(new RGBHandler(entities.Light.ChildRoomRgb, haContext, entities, logger, notificationService, entities.InputBoolean.ChildRoomRgbAutomation));

        logger.LogInformation("Succesfully subscribed to events");
    }
}