using NetDaemon.NotificationManager;

namespace NetDaemon;

public class NotificationConfigFactory : INotificationConfigFactory
{
    public IApplianceNotificationConfig CreateConfig(string applianceType, IEntities entities)
    {
        switch (applianceType)
        {
            // case "Dishwasher":
            //     return new DishwasherNotificationConfig(entities);
            // case "Washer":
            //     return new WasherNotificationConfig(entities);
            // case "Dryer":
            //     return new DryerNotificationConfig(entities);
            default:
                throw new ArgumentException($"Invalid appliance type: {applianceType}");
        }
    }
}