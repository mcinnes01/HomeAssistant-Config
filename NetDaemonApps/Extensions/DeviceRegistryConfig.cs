namespace NetDaemonApps.Extensions;


public record DeviceRegistryConfig
{
	[JsonPropertyName("cu")]
	public string? ConfigurationURL { get; init; }

	[JsonPropertyName("cns")]
	public string[][]? Connections { get; init; }

	[JsonPropertyName("ids")]
	public string[]? Identifiers { get; init; }

	[JsonPropertyName("name")]
	public string? Name { get; init; }

	[JsonPropertyName("mf")]
	public string? Manufacturer { get; init; }

	[JsonPropertyName("mdl")]
	public string? Model { get; init; }

	[JsonPropertyName("sw")]
	public string? SoftwareVersion { get; init; }

	[JsonPropertyName("sa")]
	public string? SuggestedArea { get; init; }

	[JsonPropertyName("hw_version")]
	public string? Hardwareversion { get; init; }

	[JsonPropertyName("via_device")]
	public string? ViaDevice { get; init; }


}