namespace NetDaemon.apps.NotificationsManager.Appliances;

public interface IApplianceNotificationConfig
{
    Dictionary<string, CycleState> CycleStates { get; }
    ICycleStateHandler CycleStateHandler { get; }
    InputBooleanEntity Acknowledge { get; }
    InputBooleanEntity Reminder { get; }
    MediaPlayerEntity MediaPlayer { get; }
    BinarySensorEntity MotionSensor { get; }
    SensorEntity RemainingTime { get; }
    SensorEntity Status { get; }
    string Name { get; }
}