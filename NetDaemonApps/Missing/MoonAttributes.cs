namespace NetDaemonApps;

public record AMoonAttributes
{
	[JsonPropertyName("device_class")]
	public string? DeviceClass { get; init; }

	[JsonPropertyName("icon")]
	public string? Icon { get; init; }

	[JsonPropertyName("friendly_name")]
	public string? FriendlyName { get; init; }

}
