using System.Text.Json.Serialization;

namespace NetDaemon.Notifications.Helpers;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PromptResponseType
{
    ResponseYes,
    ResponseNo,
    ResponseNone,
    ResponseSelect,
    ResponseNumeric,
    ResponseDuration
}