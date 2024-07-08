#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace NetDaemon.LightApp;

public abstract class Room
{
    // Room Settings
    public string Name { get; init; } = null!;
    public string RoomState { get; set; }
    public InputSelectEntity? RoomMode { get; set; }
    public SwitchEntity ManagerEnabled { get; set; }
    public string EnabledSwitch { get; set; }
    public string RoomModeSelect { get; set; }
    public string LocationMode { get; set; }
    public string LightControlMode { get; set; }
    public bool IsBedroom { get; set; }

    // Condition Settings
    public Entity? ConditionEntity { get; set; }
    public string? ConditionEntityState { get; set; }
    public string GuardTimeout { get; set; }
    public int Timeout { get; init; }
    public int OverrideTimeout { get; init; }
    public int NightTimeout { get; init; }
    public bool Watchdog { get; set; } = true;

    // Light Settings
    public int? LuxLimit { get; set; }
    public NumericSensorEntity? LuxEntity { get; set; }
    public NumericSensorEntity? LuxLimitEntity { get; set; }
    public List<LightEntity> LampEntities { get; init; } = [];
    public List<LightEntity> LightEntities { get; init; } = [];
    public List<LightEntity> NightLightEntities { get; init; } = [];

    // Presence Settings
    private List<LightEntity> MonitorEntities { get; } = [];
    public List<Entity> SupressionEntities { get; init; } = [];
    public List<BinarySensorEntity> KeepAliveEntities { get; init; } = [];
    public List<BinarySensorEntity> PresenceEntities { get; init; } = [];
}
