using System.Reactive.Subjects;

namespace NetDaemon.Helpers.Notifications;

public class Alexa : IAlexa
{
    public enum NotificationType
    {
        Prompt,
        Announcement,
        Tts
    }

    private readonly IDictionary<string, AlexaDeviceConfig> _devices;
    private readonly IEntities _entities;
    private readonly IHaContext _ha;
    private readonly ILogger<Alexa> _logger;
    private readonly Subject<Config> _messages = new();

    private readonly Subject<PromptResponse> _promptResponses = new();
    private readonly IScheduler _scheduler;
    private readonly IServices _services;
    private readonly IVoiceProvider _voice;


    public Alexa(IHaContext ha, IEntities entities, IServices services, IScheduler scheduler, IVoiceProvider voice, IAppConfig<AlexaConfig> config, ILogger<Alexa> logger)
    {
        _ha = ha;
        _entities = entities;
        _services = services;
        _scheduler = scheduler;
        _voice = voice;
        _logger = logger;
        _devices = config.Value.Devices;
        People = (Dictionary<string, AlexaPeopleConfig>)config.Value.People;

        _messages.Where(msg => msg.NotifyType is "tts" or "announce")
                 .Buffer(TimeSpan.FromMilliseconds(500), scheduler)
                 .Where(buffer => buffer.Any())
                 .SubscribeAsync(ProcessNotifications);

        _messages.Where(msg => msg.NotifyType is "prompt")
                 .Buffer(TimeSpan.FromMilliseconds(500), scheduler)
                 .Where(buffer => buffer.Any())
                 .SubscribeAsync(ProcessPrompts);

        SetupResponseHandler(ha);
    }

    private MediaPlayerEntity? LastCalledMediaPlayerEntity => _ha
                                                              .GetAllEntities()
                                                              .Where(e => e != null && e.EntityId.StartsWith("media_player."))
                                                              .Select(e => new MediaPlayerEntity(_ha, e!.EntityId))
                                                              .FirstOrDefault(e => e.Attributes?.LastCalled != null && (bool)e.Attributes.LastCalled);


    public void Announce(Config config) =>
        QueueNotification(config, "announce");

    public void Announce(string mediaPlayer, string message) =>
        QueueNotification(new Config { Entity = mediaPlayer, Message = message }, "announce");

    public Dictionary<string, AlexaPeopleConfig> People { get; } = new();

    public void Prompt(string mediaPlayer, string message, string eventId) =>
        QueueNotification(new Config { Entity = mediaPlayer, Message = message, EventId = eventId }, "prompt");

    public IObservable<PromptResponse> PromptResponses => _promptResponses;

    public void TextToSpeech(Config config) =>
        QueueNotification(config, "tts");

    public void TextToSpeech(string mediaPlayer, string message) =>
        QueueNotification(new Config { Entity = mediaPlayer, Message = message }, "tts");

    private string FormatMessage(string message, string voice, bool whisper)
    {
        var messageBreaks = message.Replace(",", "<break />");
        var normalMessage = $"<voice name='{voice}'>{messageBreaks}</voice>";
        var whisperMessage = $"<amazon:effect name='whispered'>{messageBreaks}</amazon:effect>";
        return whisper ? whisperMessage : normalMessage;
    }

    private double GetVolume(string entityId)
    {
        object? vol = null;
        _ha.Entity(entityId).Attributes?.ToDictionary()?.TryGetValue("volume_level", out vol);
        return double.Parse(vol?.ToString() ?? "-1");
    }

    private (bool whisper, double volume) GetVolumeDetails(AlexaDeviceConfig? deviceConfig)
    {
        var whisper = false;
        var volume = 0d;
        switch (_entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>())
        {
            case LightControlModeOptions.Sleeping:
                whisper = deviceConfig?.NightWhisper ?? true;
                volume = deviceConfig?.NightVolume ?? 0.2d;
                break;
            case LightControlModeOptions.Motion:
                whisper = false;
                volume = deviceConfig?.DayVolume ?? 0.4d;
                break;
        }

        return (whisper, volume);
    }

    private async Task ProcessNotifications(IEnumerable<Config> cfgs)
    {
        var entitiesVolumeLevel = new Dictionary<string, double>();
        var voice = _voice.GetRandomVoice();
        var message = "";
        List<string> entities = new();
        var notificationType = "";
        var eventId = "";
        double? volumeOverride = null;
        int? delayOverride = null;
        bool? whisperOverride = null;

        foreach (var cfg in cfgs)
        {
            message += (message != "" ? ",,,and," : "") + cfg.Message;
            entities = cfg.Entities;
            notificationType = cfg.NotifyType;
            eventId = cfg.EventId;
            volumeOverride = cfg.VolumeLevel;
            delayOverride = cfg.VolumeResetDelay;
            whisperOverride = cfg.Whisper;
        }


        foreach (var entity in entities)
        {
            _devices.TryGetValue(entity, out var deviceConfig);

            var (whisper, volume) = GetVolumeDetails(deviceConfig);
            var formatMessage = FormatMessage(message, voice, whisperOverride ?? whisper);
            StoreCurrentVolume(entity, entitiesVolumeLevel);
            SetVolume(entity, volumeOverride ?? volume);
            _services.Notify.AlexaMedia(formatMessage, target: entity, data: new { type = notificationType });
        }

        _scheduler.Sleep(TimeSpan.FromSeconds(delayOverride ?? 5)).GetAwaiter().OnCompleted(() => RevertVolume(entitiesVolumeLevel));
    }

    private async Task ProcessPrompts(IEnumerable<Config> cfgs)
    {
        var entitiesVolumeLevel = new Dictionary<string, double>();
        var voice = _voice.GetRandomVoice();
        var message = "";
        List<string> entities = new();
        var notificationType = "";
        var eventId = "";
        double? volumeOverride = null;
        int? delayOverride = null;
        bool? whisperOverride = null;

        foreach (var cfg in cfgs)
        {
            message = cfg.Message;
            entities = cfg.Entities;
            notificationType = cfg.NotifyType;
            eventId = cfg.EventId;
            volumeOverride = cfg.VolumeLevel;
            delayOverride = cfg.VolumeResetDelay;
            whisperOverride = cfg.Whisper;


            foreach (var entity in entities)
            {
                _devices.TryGetValue(entity, out var deviceConfig);

                var (whisper, volume) = GetVolumeDetails(deviceConfig);
                var formatMessage = FormatMessage(message, voice, whisperOverride ?? whisper);
                StoreCurrentVolume(entity, entitiesVolumeLevel);
                SetVolume(entity, volumeOverride ?? volume);
                //_services.Script.ActivateAlexaActionableNotification(formatMessage, eventId, entity);
            }
            _scheduler.Sleep(TimeSpan.FromSeconds(5));
        }
    }

    private void QueueNotification(Config cfg, string type)
    {
        cfg.NotifyType = type;
        _messages.OnNext(cfg);
    }

    private void RevertVolume(Dictionary<string, double> entitiesVolumeLevel)
    {
        foreach (var (entity, volume) in entitiesVolumeLevel)
            SetVolume(entity, volume);
    }

    private void SetupResponseHandler(IHaContext haContext)
    {
        haContext.Events.Filter<PromptResponse>("alexa_actionable_notification").Subscribe(responseEvent =>
        {
            _logger.LogInformation("Event(alexa_actionable_notification): {EventId} - {Response} - {ResponseType} by {ResponsePersonId}", responseEvent.Data?.EventId, responseEvent.Data?.Response?.ToString(), responseEvent.Data?.ResponseType, responseEvent?.Data?.ResponsePersonId);

            if (responseEvent?.Data == null) return;
            if (responseEvent?.Data?.ResponsePersonId != null)
                responseEvent.Data.ResponsePersonName = People[responseEvent.Data.ResponsePersonId].Name;
            _promptResponses.OnNext(responseEvent.Data);
        });
    }

    private void SetVolume(string entityId, double volumeLevel)
    {
        _services.MediaPlayer.VolumeSet(ServiceTarget.FromEntity(entityId), new MediaPlayerVolumeSetParameters { VolumeLevel = volumeLevel });
    }

    private void StoreCurrentVolume(string entityId, IDictionary<string, double> entitiesVolumeLevel)
    {
        entitiesVolumeLevel.Add(entityId, GetVolume(entityId));
    }


    public class Config
    {
        public bool? Whisper = null;
        private List<string> _entities = new();
        public double? VolumeLevel { get; set; } = null;
        public int? VolumeResetDelay { get; set; } = null;

        public List<string> Entities
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Entity) && !_entities.Contains(Entity))
                    _entities.Add(Entity);
                return _entities;
            }
            set => _entities = value;
        }

        public string Entity { get; set; } = "";
        public string Message { get; set; } = "";
        internal string EventId { get; set; } = "";
        internal string NotifyType { get; set; } = "tts";
    }
}