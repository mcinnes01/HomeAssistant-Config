namespace LightManagerV2;

public class ManagerConfig
{
    public List<Manager> Rooms { get; set; } = new List<Manager>();
    public int GuardTimeout { get; set; } = 900;
    public string MaxDuration { get; set; } = default!;
    public string MinDuration { get; set; } = default!;
    public string NdUserId { get; set; } = default!;
    public InputSelectEntity LightControlMode { get; set; } = default!;
    public InputSelectEntity LocationMode { get; set; } = default!;
    public SwitchEntity RandomSwitchEntity { get; set; } = default!;
}