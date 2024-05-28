
namespace NetDaemon.Models;

public sealed record MqttSensorAttributes: MqttCommonAttributes
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("state_class")]
    public string? StateClass { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unit_of_measurement")]
    public string? UnitOfMeasurement { get; init; }
}
