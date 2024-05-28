namespace NetDaemon.Models;

public record MobileAppMessageData
{
    [JsonPropertyName("icon_url")]
    public string? Icon { get; init; }

    [JsonPropertyName("image")]
    public string? Image { get; init; }

    [JsonPropertyName("video")]
    public string? Video { get; init; }

    [JsonPropertyName("actions")]
    public MobileAppMessageAction[]? Actions { get; init; }

    [JsonPropertyName("clickAction")]
    public string? ClickAction { get; init; }

    [JsonPropertyName("group")]
    public string? Group { get; init; }

    [JsonPropertyName("tag")]
    public string? Tag { get; init; }

    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    [JsonPropertyName("color")]
    public string? Color { get; init; }

    [JsonPropertyName("sticky")]
    public string? Sticky { get; init; }

    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    [JsonPropertyName("importance")]
    public string? Importance { get; init; }

    [JsonPropertyName("vibrationPattern")]
    public string? VibrationPattern { get; init; }

    [JsonPropertyName("ledColor")]
    public string? LedColor { get; init; }

    [JsonPropertyName("persistent")]
    public bool? Persistent { get; init; }

    [JsonPropertyName("timeout")]
    public long? Timeout { get; init; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; init; }

    [JsonPropertyName("chronometer")]
    public string? Chronometer { get; init; }

    [JsonPropertyName("when")]
    public string? When { get; init; }

    [JsonPropertyName("alert_once")]
    public bool? AlertOnce { get; init; }

    [JsonPropertyName("notification_icon")]
    public string? NotificationIcon { get; init; }

    [JsonPropertyName("ttl")]
    public long? TTL { get; init; }

    [JsonPropertyName("priority")]
    public string? Priority { get; init; }
}
