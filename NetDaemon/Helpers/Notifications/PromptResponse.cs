namespace NetDaemon.Helpers.Notifications;

public record PromptResponse
{
    [JsonPropertyName("event_response")] public object? Response { get; init; }

    [JsonPropertyName("event_response_type")]
    public PromptResponseType? ResponseType { get; init; }

    [JsonPropertyName("event_id")] public string? EventId { get; init; }
    [JsonPropertyName("event_person_id")] public string? ResponsePersonId { get; init; }
    public string? ResponsePersonName { get; set; } = "UNKNOWN";
}