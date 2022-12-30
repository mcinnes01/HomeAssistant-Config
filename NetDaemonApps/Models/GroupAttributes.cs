namespace NetDaemonApps.Models;

public record GroupAttributes
{
    [JsonPropertyName("entity_id")]
    public string[]? EntityIds { get; init; }
}
