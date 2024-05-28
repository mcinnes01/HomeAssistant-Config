
namespace NetDaemon.Models;

public sealed record MqttBinarySensorAttributes: MqttCommonAttributes
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("off_delay")]
    public int? OffDelay { get; init; }
}
