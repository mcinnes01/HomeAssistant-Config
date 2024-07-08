namespace NetDaemon.Helpers.Notifications;

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