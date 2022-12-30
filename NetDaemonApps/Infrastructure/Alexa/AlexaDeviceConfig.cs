namespace NetDaemon.Infrastructure.Alexa;

public class AlexaDeviceConfig
{
    public bool NightWhisper { get; set; } = true;
    public double DayVolume { get; set; } = 0.4;
    public double NightVolume { get; set; } = 0.1;
}