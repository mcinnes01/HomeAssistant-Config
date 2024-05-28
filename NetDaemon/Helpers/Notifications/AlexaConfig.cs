namespace NetDaemon.Notifications.Helpers;

public class AlexaConfig
{
    public IDictionary<string, AlexaDeviceConfig> Devices { get; set; }
    public IDictionary<string, AlexaPeopleConfig> People { get; set; }
}