
namespace NetDaemon.Models;

public sealed record MqttSelectAttributes: MqttCommonAttributes
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("optimistic")]
    public bool? Optimistic { get; init; }

    [JsonPropertyName("unit_of_measurement")]
    public string[]? Options { get; init; }

}
