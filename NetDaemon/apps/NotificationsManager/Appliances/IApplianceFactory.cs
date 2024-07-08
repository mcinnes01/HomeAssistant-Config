namespace NetDaemon.apps.NotificationsManager.Appliances;

public interface IApplianceFactory
{
    Appliance CreateAppliance(string applianceType);
    List<Appliance> CreateAppliances(string[] applianceType);
}