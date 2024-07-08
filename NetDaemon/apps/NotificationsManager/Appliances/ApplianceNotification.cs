using Humanizer;
using Humanizer.Localisation;
using NetDaemon.Helpers.Notifications;

namespace NetDaemon.apps.NotificationsManager.Appliances;

public class ApplianceNotification : IApplianceNotification
{
    private readonly InputBooleanEntity _acknowledge;

    private readonly string _appliance;
    private readonly Dictionary<string, CycleState> _cycleStates;
    private readonly SensorEntity _remainingTime;
    private readonly IScheduler _scheduler;
    private readonly ILogger<NotificationsManager> _logger;
    private readonly SensorEntity _status;

    public ApplianceNotification(IScheduler scheduler, IApplianceNotificationConfig config, ILogger<NotificationsManager> logger)
    {
        _scheduler = scheduler;
        _logger = logger;
        _appliance = config.Name;
        _status = config.Status;
        _remainingTime = config.RemainingTime;
        _acknowledge = config.Acknowledge;
        _cycleStates = config.CycleStates;
    }

    public CycleState CycleState => _status.State != null ? _cycleStates[_status.State.ToLower()] : CycleState.Unknown;

    public string EventId => $"{_appliance}Tts";

    private const int PromptInterval1 = 15;
    private const int PromptInterval2 = 10;
    private const int PromptInterval3 = 5;
    private const int AcknowledgeInterval = 60;

    public Notification? GetNotification(CycleState cycle, TimeSpan lastPrompt)
    {
        switch (cycle)
        {
            case CycleState.Running:
                return GetRunningNotification(lastPrompt);
            case CycleState.Finished:
            case CycleState.Ready:
                return GetReadyNotification(lastPrompt);
            case CycleState.Unknown:
                _logger.LogError("Unknown cycle state");
                return null;
            default:
                _logger.LogError("Unexpected cycle state");
                return null;
        }
    }

    private Notification? GetRunningNotification(TimeSpan lastPrompt)
    {
        return TimeRemaining.TotalMinutes switch
        {
            >= 60 when lastPrompt.TotalMinutes <= PromptInterval1 => null,
            >= 30 when lastPrompt.TotalMinutes <= PromptInterval2 => null,
            >= 10 when lastPrompt.TotalMinutes <= PromptInterval3 => null,
            _ => CreateNotification($"The {_appliance} will be done in {TimeRemaining.Humanize(minUnit: TimeUnit.Minute)}", Alexa.NotificationType.Announcement)
        };
    }

    private Notification? GetReadyNotification(TimeSpan lastPrompt)
    {
        var entityStateLastChanged = _scheduler.Now.LocalDateTime - _remainingTime.EntityState?.LastChanged ?? TimeSpan.MaxValue;
        if (_acknowledge.IsOff() && entityStateLastChanged.TotalMinutes <= PromptInterval1)
            return CreateNotification($"The {_appliance} just finished", Alexa.NotificationType.Announcement);

        if (_acknowledge.IsOff() && lastPrompt.TotalMinutes > PromptInterval1)
            return CreateNotification($"The {_appliance} finished {TimeFinished.Humanize(minUnit: TimeUnit.Minute)} ago. Has it been unloaded?", Alexa.NotificationType.Prompt);

        if (_acknowledge.IsOn() && lastPrompt.TotalMinutes >= AcknowledgeInterval)
            return CreateNotification($"The {_appliance} is ready", Alexa.NotificationType.Announcement);

        return null;
    }

    private Notification CreateNotification(string message, Alexa.NotificationType type)
    {
        return new Notification
        {
            EventId = EventId,
            Message = message,
            Type = type
        };
    }

    public Notification? HandleResponse(PromptResponseType? responseType)
    {
        if (responseType == null) return null;

        var notification = new Notification
        {
            EventId = EventId,
            Type = Alexa.NotificationType.Tts
        };

        switch (responseType)
        {
            case PromptResponseType.ResponseNo:
                notification.Message = "Ok";
                break;
            case PromptResponseType.ResponseYes:
                _acknowledge.TurnOn();
                notification.Message = "Thanks";
                break;
            default:
                return null;
        }

        return notification;
    }

    public TimeSpan TimeFinished => _scheduler.Now.LocalDateTime - _status.EntityState.LastChanged.Value;

    public TimeSpan TimeRemaining => DateTime.Parse(_remainingTime.State ?? _scheduler.Now.LocalDateTime.ToString()) - _scheduler.Now;
}