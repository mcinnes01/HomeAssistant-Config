namespace daemonapp.apps.NotificationsManager;

public class BatteryNotificationsConfig(NumericSensorEntity batteryLevel, SensorEntity batteryState, string mobileApp)
{
    public NumericSensorEntity BatteryLevel { get; } = batteryLevel;
    public SensorEntity BatteryState { get; } = batteryState;
    public string MobileApp { get; } = mobileApp;
}