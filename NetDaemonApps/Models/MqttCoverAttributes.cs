
namespace NetDaemonApps.Models;

public sealed record MqttCoverAttributes: MqttCommonAttributes
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload_press")]
    public string? PayloadPress { get; init; }

    
}
