
namespace NetDaemonApps.Models;

public record MqttCommonAttributes
{
    //Set in EntityCreationOptions:
    //Name, DeviceClass, UniqueId, ObjectId, CommandTopic, StateTopic, PayloadAvailable,
    //PayloadNotAvailable, PayloadOn, PayloadOff, AvailabilityTopic, JsonAttributesTopic

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("device")]
    MqttDeviceAttributes? Device { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("encoding")]
    public string? Encoding { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("entity_category")]
    public string? EntityCategory { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expire_after")]
    public int? ExpireAfter { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("force_update")]
    public bool? ForceUpdate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("qos")]
    public int? QOS { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("retain")]
    public bool? Retain { get; init; }

}
