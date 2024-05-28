namespace NetDaemon.Models;

public record MobileAppNotificationAction
{
    [JsonPropertyName("action")]
    public string? Action { get; init; }

    [JsonPropertyName("device_id")]
    public string? DeviceId { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }
}


