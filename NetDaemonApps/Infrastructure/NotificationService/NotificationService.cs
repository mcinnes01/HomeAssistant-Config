using System.IO;
using System.Threading.Tasks;
using System;

namespace NetDaemonApps.Infrastructure;

public class NotificationService : INotificationService
{
    readonly IServices services;
    readonly IEntities entities;
    readonly IHaContext haContext;

    Dictionary<string, string[]> Messages 
        => JsonSerializer.Deserialize<Dictionary<string, string[]>>(File.ReadAllText("messages.json"))!;

    public NotificationService(IHaContext haContext)
    {
        this.haContext = haContext;
        this.services = new Services(haContext);
        this.entities = new Entities(haContext);        
    }
    public void Send(PhoneTarget phone, string message, string? title, MobileAppMessageData? data = null)
    {
        if (phone == PhoneTarget.All)
        {
            foreach (var e in Enum.GetValues(typeof(PhoneTarget)).Cast<PhoneTarget>().Where(p => p != PhoneTarget.All))
                Send(e, message, title, data);
        }
        else
        {
            haContext.CallService("notify", $"mobile_app_{phone.GetDescription()}_phone", null,
                new
                {
                    message,
                    title,
                    data
                });        
        }
    }

    public void Send(TVTarget tv, string message, string? icon)
    {
        if (tv == TVTarget.All)
        {
            foreach (var e in Enum.GetValues(typeof(TVTarget)).Cast<TVTarget>().Where(p => p != TVTarget.All))
                Send(e, message, icon);
        }
        else
        {
            haContext.CallService("notify", $"{tv.GetDescription()}_tv", null,
                new
                {
                    message,                    
                    data = new
                    {
                        icon
                    }
                });
        }
    }  

    public void Speak(SpeakerTarget speaker, string message, bool? cache = null, string? language = null)
    {
        string?[]? targets;

        if (speaker == SpeakerTarget.All)
        {
            targets = Enum
                .GetValues(typeof(SpeakerTarget))
                .Cast<SpeakerTarget>()
                .Where(p => p != SpeakerTarget.All)
                .Select(t => $"media_player.{t.GetDescription()}").ToArray();
        }
        else
            targets = new[] { $"media_player.{speaker.GetDescription()}" };

        haContext.CallService("tts", "edge_say", null,
            new
            {
                message,
                entity_id = targets,
                cache,
                language,
            });
    }


    public async Task SpeakAsync(SpeakerTarget speaker, string message, int maxDelay = Timeout.Infinite, bool? cache = null, string? language = null)
    {
        string?[]? targets;
        CancellationTokenSource source = new CancellationTokenSource();

        if (speaker == SpeakerTarget.All)
        {
            targets = Enum
                .GetValues(typeof(SpeakerTarget))
                .Cast<SpeakerTarget>()
                .Where(p => p != SpeakerTarget.All)
                .Select(t => $"media_player.{t.GetDescription()}").ToArray();
        }
        else
            targets = new[] { $"media_player.{speaker.GetDescription()}" };

        var players = targets.Select(t => haContext.Entity(t!));

        List<IDisposable> subscribers = new();

        foreach (var player in players)
        {
            subscribers.Add(
                player.StateChanges()
                .Where(p => p.New?.State != "playing")
                .Subscribe(_ => 
                {
                    if (players.All(p => p.State != "playing"))
                        source.Cancel();
                })
            );
        }


        haContext.CallService("tts", "edge_say", null,
            new
            {
                message,
                entity_id = targets,
                cache,
                language,
            });

        try
        {
            await Task.Delay(maxDelay, source.Token);
        }
        catch (OperationCanceledException)
        { }
        finally
        {
            subscribers.ForEach(s => s?.Dispose());
        }
    }

    public void Speak(PhoneTarget phone, string message, SpeakPriority priority)
    {
        if (phone == PhoneTarget.All)
        {
            foreach (var e in Enum.GetValues(typeof(PhoneTarget)).Cast<PhoneTarget>().Where(p => p != PhoneTarget.All))
                Speak(e, message, priority);
        }
        else
        {
            haContext.CallService("notify", $"mobile_app_{phone.GetDescription()}_phone", null,
                new
                {
                    message =  "TTS",
                    title = message,
                    data = new
                    {
                        ttl = 0,
                        priority = priority == SpeakPriority.VeryHigh || priority == SpeakPriority.High ? "high": null,
                        channel = priority == SpeakPriority.VeryHigh ? "alarm_stream_max" :
                                 (priority == SpeakPriority.High ? "alarm_stream" : null)
                    }
                });
        }
    }

    public string? GetMessage(string key)
    {
        return Messages[key].Random();
    }
}

