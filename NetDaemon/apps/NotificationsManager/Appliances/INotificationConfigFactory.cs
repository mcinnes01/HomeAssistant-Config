namespace NetDaemon.apps.NotificationsManager.Appliances;

public interface INotificationConfigFactory
{
    IApplianceNotificationConfig CreateConfig(string applianceType, IEntities entities);
}