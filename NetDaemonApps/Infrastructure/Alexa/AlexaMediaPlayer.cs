using System.Reactive.Subjects;

namespace NetDaemon.Infrastructure.Alexa;
//https://github.com/eugeneniemand/netdaemon-app-template/blob/main/Helpers/Notifications/IAlexa.cs
public interface IAlexa
{
    void Announce(AlexaMediaPlayer.Config config);
    void Announce(string mediaPlayer, string message);
    void TextToSpeech(AlexaMediaPlayer.Config config);
    void TextToSpeech(string mediaPlayer, string message);
    void TurnScreenOn(string entityId);
    void TurnScreenOff(string entityId);
}

public class AlexaMediaPlayer : IAlexa
{
    private readonly IDictionary<string, AlexaDeviceConfig> _devices;
    private readonly IEntities                              _entities;
    private readonly IHaContext                             _ha;
    private readonly Subject<Config>                        _messages = new();
    private readonly IScheduler                             _scheduler;
    private readonly IServices                              _services;
    private readonly List<string>                           _voices = new() { "Amy", "Brian", "Emma", "Nicole", "Russell", "Geraint" };
    private readonly ILogger<AlexaMediaPlayer>              _logger;


    public AlexaMediaPlayer(IHaContext ha, IEntities entities, IServices services,
        IScheduler scheduler, IAppConfig<AlexaConfig> config, ILogger<AlexaMediaPlayer> logger)
    {
        _ha        = ha;
        _entities  = entities;
        _services  = services;
        _scheduler = scheduler;
        _devices   = config.Value.Devices;
        _logger    = logger;

        _messages.Buffer(TimeSpan.FromMilliseconds(500)).Subscribe(ProcessNotifications);
    }

    private string RandomVoice => _voices[Random.Shared.Next(0, _voices.Count - 1)];

    public void Announce(Config config) =>
        QueueNotification(config, "announce");

    public void Announce(string mediaPlayer, string message) =>
        QueueNotification(new Config { Entity = mediaPlayer, Message = message }, "announce");

    public void TextToSpeech(Config config) =>
        QueueNotification(config, "tts");

    public void TextToSpeech(string mediaPlayer, string message) =>
        QueueNotification(new Config { Entity = mediaPlayer, Message = message }, "tts");

    public void TurnScreenOn(string entityId) =>
        SetScreen(entityId, "on");

    public void TurnScreenOff(string entityId) =>
        SetScreen(entityId, "off");

    private string FormatMessage(string message, string voice, bool whisper)
    {
        var messageBreaks  = message.Replace(",", "<break />");
        var normalMessage  = $"<voice name='{voice}'>{messageBreaks}</voice>";
        var whisperMessage = $"<amazon:effect name='whispered'>{messageBreaks}</amazon:effect>";
        return whisper ? whisperMessage : normalMessage;
    }

    private double GetVolume(string entityId)
    {
        object? vol = null;
        _ha.Entity(entityId).Attributes?.ToDictionary()?.TryGetValue("volume_level", out vol);
        return double.Parse(vol?.ToString() ?? "-1");
    }

    private bool HasScreen(string entityId)
    {
        _devices.TryGetValue(entityId, out var deviceConfig);
        return deviceConfig?.HasScreen ?? false;
    }

    private void ProcessNotifications(IEnumerable<Config> cfgs)
    {
        var          entitiesVolumeLevel = new Dictionary<string, double>();
        var          randomVoice         = RandomVoice;
        var          message             = "";
        List<string> entities            = new();
        var          notificationType    = "";
        foreach (var cfg in cfgs)
        {
            message          += cfg.Message + ",,,,";
            entities         =  cfg.Entities;
            notificationType =  cfg.NotifyType;
        }

        foreach (var entity in entities)
        {
            _devices.TryGetValue(entity, out var deviceConfig);

            var whisper = false;
            var volume  = 0d;
            switch (_entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>())
            {
                case LightControlModeOptions.Relaxing:
                case LightControlModeOptions.Sleeping:
                    whisper = deviceConfig?.NightWhisper ?? true;
                    volume  = deviceConfig?.NightVolume ?? 0.2d;
                    break;
                default:
                    whisper = deviceConfig?.NightWhisper ?? false;
                    volume  = deviceConfig?.DayVolume ?? 0.4d;
                    break;
            }

            var formatMessage = FormatMessage(message, randomVoice, whisper);
            StoreVolume(entity, entitiesVolumeLevel);
            SetVolume(entity, volume);
            _services.Notify.AlexaMedia(formatMessage, target: entity, data: new { type = notificationType });
        }

        Thread.Sleep(5000);

        RevertVolume(entitiesVolumeLevel);
    }

    private void QueueNotification(Config cfg, string type)
    {
        cfg.NotifyType = type;
        _messages.OnNext(cfg);
    }

    private void RevertVolume(Dictionary<string, double> entitiesVolumeLevel)
    {
        foreach (var (entity, volume) in entitiesVolumeLevel)
            _services.MediaPlayer.VolumeSet(ServiceTarget.FromEntity(entity), new MediaPlayerVolumeSetParameters { VolumeLevel = volume });
    }

    private void SetVolume(string entityId, double volumeLevel)
    {
        _services.MediaPlayer.VolumeSet(ServiceTarget.FromEntity(entityId), new MediaPlayerVolumeSetParameters { VolumeLevel = volumeLevel });
        _scheduler.Sleep(TimeSpan.FromMilliseconds(100));
    }

    private void StoreVolume(string entityId, IDictionary<string, double> entitiesVolumeLevel)
    {
        entitiesVolumeLevel.Add(entityId, GetVolume(entityId));
    }

    private void SetScreen(string entityId, string action)
    {
        _logger.LogDebug($"Set screen to {action} for entity: {entityId}");
        if (!HasScreen(entityId))
            return;

        _logger.LogDebug("Alexa {entityId} has screen turning it {action}");
        for (int i = 0; i < 2; i++)
        {
            _services.MediaPlayer.PlayMedia(ServiceTarget.FromEntity(entityId), $"turn screen {action}", "custom");
            Thread.Sleep(3000);
        }
    }

    public class Config
    {
        private List<string> _entities = new();
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
        public string NotifyType { get; set; } = "tts";
    }
}