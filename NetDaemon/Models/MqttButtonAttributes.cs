
namespace NetDaemon.Models;

public sealed record MqttButtonAttributes: MqttCommonAttributes
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload_press")]
    public string? PayloadPress { get; init; }
}