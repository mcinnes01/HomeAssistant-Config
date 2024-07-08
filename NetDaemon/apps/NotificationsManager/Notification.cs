using NetDaemon.Helpers.Notifications;

namespace NetDaemon.apps.NotificationsManager;

public class Notification
{
    public Alexa.NotificationType Type { get; set; }
    public string EventId { get; set; }
    public string Message { get; set; }
}