
namespace NetDaemonApps.Models;

public sealed record MqttDeviceAttributes
{
    [JsonPropertyName("configuration_url")]
    public string? ConfigurationURL { get; init; }

    [JsonPropertyName("connections")]
    public string?[]?[]? Connections { get; init; }

    [JsonPropertyName("identifiers")]
    public string?[]? Identifiers { get; init; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; init; }

    [JsonPropertyName("model")]
    public string? Model { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("suggested_area")]
    public string? SuggestedArea { get; init; }

    [JsonPropertyName("sw_version")]
    public string? SoftwareVersion { get; init; }

    [JsonPropertyName("via_device")]
    public string? ViaDevice { get; init; }
}
