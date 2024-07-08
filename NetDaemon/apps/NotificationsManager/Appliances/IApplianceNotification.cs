using NetDaemon;
using NetDaemon.apps.NotificationsManager;

namespace NetDaemon.NotificationManager;

public interface IApplianceNotification
{
    CycleState CycleState { get; }
    string EventId { get; }
    TimeSpan TimeFinished { get; }
    TimeSpan TimeRemaining { get; }
    Notification? GetNotification(CycleState cycle, TimeSpan lastPrompt);
    Notification? HandleResponse(PromptResponseType? responseType);
}