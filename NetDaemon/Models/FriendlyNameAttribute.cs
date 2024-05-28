namespace NetDaemon.Models;

public record FriendlyNameAttribute
{
    [JsonPropertyName("friendly_name")] public string FriendlyName { get; set; } = "";
}