namespace NetDaemon.Models;

public record MobileAppMessageAction
{
    [JsonPropertyName("action")]
    public string? Action { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
