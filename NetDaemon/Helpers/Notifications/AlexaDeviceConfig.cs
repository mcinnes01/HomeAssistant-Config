namespace NetDaemon.Notifications.Helpers;

public class AlexaDeviceConfig
{
    public bool NightWhisper { get; set; } = true;
    public double DayVolume { get; set; } = 0.4;
    public double NightVolume { get; set; } = 0.1;

    /// <summary>
    ///     Media Player EntityId
    /// </summary>
    //public string EntityId { get; set; }
}

public class AlexaPeopleConfig
{
    public string Name { get; set; } = "UNKNOWN";
}