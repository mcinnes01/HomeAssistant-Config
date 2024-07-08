using NetDaemon.NotificationManager;

namespace NetDaemon.apps.NotificationsManager;

//[NetDaemonApp]
//[Focus]
public class NotificationsManager
{
    private readonly IAlexa _alexa;
    private readonly IEntities _entities;
    private readonly IServices _services;
    private readonly IHaContext _haContext;
    private readonly IDictionary<string, DateTime> _lastPrompt = new Dictionary<string, DateTime>();
    private readonly IScheduler _scheduler;
    private readonly ILogger<NotificationsManager> _logger;

    public NotificationsManager(IHaContext haContext, IEntities entities, IServices services, IAlexa alexa, IScheduler scheduler, ILogger<NotificationsManager> logger, IApplianceFactory applianceFactory)
    {
        _haContext = haContext;
        _entities = entities;
        _services = services;
        _alexa = alexa;
        _scheduler = scheduler;
        _logger = logger;

        var appliances = applianceFactory.CreateAppliances(["Dishwasher", "Washer", "Dryer"]);
        foreach (var appliance in appliances) SubscribeAppliance(appliance);

        AlarmReminder();
    }

    private void SubscribeAppliance(Appliance appliance)
    {
        SubscribeMotion(appliance.MotionSensor, appliance.Notification, appliance.MediaPlayer);
        SubscribePromptResponse(appliance.Notification, appliance.MediaPlayer);
        SubscribeApplianceState(appliance.Sensor, appliance.Notification, appliance.Reminder, appliance.Acknowledge, appliance.CycleStateHandler, appliance.MediaPlayer);
    }

    private void AlarmReminder()
    {
        _entities.AlarmControlPanel.Alarmo.StateChanges().Subscribe(s =>
        {
            switch (s.New.State)
            {
                case "armed_night":
                    var reminderMessages = new List<string>();
                    // if (_entities.InputBoolean.DryerReminder.IsOn())
                    //     reminderMessages.Add("Dryer");
                    // if (_entities.InputBoolean.WashingReminder.IsOn())
                    //     reminderMessages.Add("Washer");
                    // if (_entities.InputBoolean.DryerReminder.IsOn())
                    //     reminderMessages.Add("Dishwasher");

                    var reminderMessage = reminderMessages.Any() ? string.Join(",", reminderMessages) + " is ready but not turned on." : "";
                    _alexa.TextToSpeech(new Alexa.Config { Entities = new List<string> { "media_player.master", "media_player.office" }, Message = $"{reminderMessage} Alarm armed" });
                    break;
                case "disarmed":
                    break;
            }
        });
    }

    private void SubscribeMotion(BinarySensorEntity motionSensor, IApplianceNotification applianceNotification, MediaPlayerEntity mediaPlayer)
    {
        motionSensor.StateChanges()
                    .Where(s => s.Old.IsOff() && s.New.IsOn())
                    .Subscribe(s =>
                    {
                        var notification = applianceNotification.GetNotification(applianceNotification.CycleState, LastPrompt(applianceNotification.EventId));
                        SendNotification(notification, mediaPlayer.EntityId);
                    });
    }

    private void SubscribePromptResponse(IApplianceNotification applianceNotification, MediaPlayerEntity mediaPlayer)
    {
        _alexa.PromptResponses?
              .Where(r => r.EventId == applianceNotification.EventId)
              .Subscribe(r =>
              {
                  var notification = applianceNotification.HandleResponse(r.ResponseType);
                  SendNotification(notification, mediaPlayer.EntityId);
              });
    }

    private void SubscribeApplianceState(SensorEntity sensor, IApplianceNotification applianceNotification, InputBooleanEntity applianceReminder, InputBooleanEntity applianceAcknowledge, ICycleStateHandler cycleStateHandler, MediaPlayerEntity mediaPlayer)
    {
        sensor.StateChanges().Subscribe(s =>
        {
            cycleStateHandler.HandleCycleState(applianceNotification.CycleState, applianceReminder, applianceAcknowledge);
            if (applianceNotification.CycleState != CycleState.Ready) return;
            var notification = applianceNotification.GetNotification(applianceNotification.CycleState, LastPrompt(applianceNotification.EventId));
            SendNotification(notification, mediaPlayer.EntityId);
        });
    }

    private TimeSpan LastPrompt(string eventId) => _lastPrompt.ContainsKey(eventId) ? _scheduler.Now.LocalDateTime - _lastPrompt[eventId] : TimeSpan.MaxValue;


    private void SendNotification(Notification? notification, string mediaPlayer)
    {
        if (notification == null || string.IsNullOrEmpty(notification.Message)) return;

        _logger.LogDebug("SendNotification: {eventId}:{message} Last Notification: {lastPrompt}", notification.EventId, notification.Message, _lastPrompt.TryGetValue(notification.EventId, out var value) ? value : "NULL");
        _lastPrompt[notification.EventId] = _scheduler.Now.LocalDateTime;
        switch (notification.Type)
        {
            case Alexa.NotificationType.Prompt:
                _alexa.Prompt(mediaPlayer, notification.Message, notification.EventId);
                break;
            case Alexa.NotificationType.Announcement:
                _alexa.Announce(mediaPlayer, notification.Message);
                break;
            case Alexa.NotificationType.Tts:
                _alexa.TextToSpeech(mediaPlayer, notification.Message);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}