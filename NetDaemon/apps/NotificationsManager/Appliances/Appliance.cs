namespace NetDaemon.apps.NotificationsManager.Appliances;

public record Appliance(
    BinarySensorEntity MotionSensor,
    IApplianceNotification Notification,
    MediaPlayerEntity MediaPlayer,
    SensorEntity Sensor,
    InputBooleanEntity Reminder,
    InputBooleanEntity Acknowledge,
    ICycleStateHandler CycleStateHandler
);