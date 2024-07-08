namespace NetDaemon.apps.LightApp;

public class ManagerConfig
{
    public List<LightManager> Rooms { get; set; } = new List<LightManager>();
    public int GuardTimeout { get; set; } = 900;
    public string MaxDuration { get; set; } = default!;
    public string MinDuration { get; set; } = default!;
    public string NdUserId { get; set; } = default!;
}