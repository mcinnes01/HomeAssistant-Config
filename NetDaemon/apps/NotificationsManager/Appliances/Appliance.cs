using NetDaemon.NotificationManager;

namespace NetDaemon;

public record Appliance(
    BinarySensorEntity MotionSensor,
    IApplianceNotification Notification,
    MediaPlayerEntity MediaPlayer,
    SensorEntity Sensor,
    InputBooleanEntity Reminder,
    InputBooleanEntity Acknowledge,
    ICycleStateHandler CycleStateHandler
);