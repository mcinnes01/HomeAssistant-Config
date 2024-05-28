namespace NetDaemon;

public interface IApplianceFactory
{
    Appliance CreateAppliance(string applianceType);
    List<Appliance> CreateAppliances(string[] applianceType);
}