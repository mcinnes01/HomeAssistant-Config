namespace NetDaemonApps.Extensions;

using System.Threading.Tasks;

public static class MediaPlayerExtensions
{
    public static async Task PlayMediaAsync(this MediaPlayerEntity mediaPlayer, string @mediaContentId, string @mediaContentType, int maxDelay = Timeout.Infinite, object? @enqueue = null, bool? @announce = null)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        var observer = mediaPlayer.StateChanges()
            .Where(s => s.New?.State != "playing")
            .Subscribe(_ => cts.Cancel() );

        try
        {
            mediaPlayer.PlayMedia(@mediaContentId, @mediaContentType, @enqueue, @announce);
            await Task.Delay(maxDelay, cts.Token);
        }
        catch (OperationCanceledException)
        { }
        finally
        {
            observer.Dispose();
        }
    }

    public static async Task PlayMediaAsync(this IEnumerable<MediaPlayerEntity> target, string @mediaContentId, string @mediaContentType, int maxDelay = Timeout.Infinite, object? @enqueue = null, bool? @announce = null)
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        IList<IDisposable> observers = new List<IDisposable>();
        Dictionary<MediaPlayerEntity, bool> terminated = new Dictionary<MediaPlayerEntity, bool>();

        foreach (var t in target)
        {
            terminated[t] = false;
            observers.Add(t.StateChanges()
                .Where(s => s.New?.State != "playing")
                .Subscribe(_ =>
                {
                    terminated[t] = true;
                    if (terminated.Values.All(v => v))
                        cts.Cancel();
                }));
        }

        try
        {
            target.PlayMedia(@mediaContentId, @mediaContentType, @enqueue, @announce);
            await Task.Delay(maxDelay, cts.Token);

        }
        catch (OperationCanceledException)
        { }
        finally
        {
            foreach (var observer in observers)
                observer.Dispose();
        }

    }

    // public static void EdgeSay(this MediaPlayerEntity mediaPlayer, string @message, bool? @cache = null, string? @language = null, object? @options = null)
    // {
    //     mediaPlayer.HaContext.CallService("tts", "edge_say",
    //         null, new TtsEdgeSayParameters { EntityId = mediaPlayer.EntityId, Message = @message, Cache = @cache, Language = @language, Options = @options });
    // }

    // public static async Task EdgeSayAsync(this MediaPlayerEntity mediaPlayer, string @message, int maxDelay = Timeout.Infinite, bool? @cache = null, string? @language = null, object? @options = null)
    // {
    //     CancellationTokenSource cts = new CancellationTokenSource();
    //     var observer = mediaPlayer.StateChanges()
    //         .Where(s => s.New?.State != "playing")
    //         .Subscribe(_ => cts.Cancel());

    //     try
    //     {
    //         mediaPlayer.EdgeSay(@message, @cache, @language, @options);
    //         await Task.Delay(maxDelay, cts.Token);
    //     }
    //     catch (OperationCanceledException)
    //     { }
    //     finally
    //     {
    //         observer.Dispose();
    //     }
    // }

    // public static void GoogleTranslateSay(this MediaPlayerEntity mediaPlayer, string @message, bool? @cache = null, string? @language = null, object? @options = null)
    // {
    //     mediaPlayer.HaContext.CallService("tts", "google_translate_say", 
    //         null, new TtsGoogleTranslateSayParameters { EntityId = mediaPlayer.EntityId, Message = @message, Cache = @cache, Language = @language, Options = @options });
    // }

    // public static async Task GoogleTranslateSayAsync(this MediaPlayerEntity mediaPlayer, string @message, int maxDelay = Timeout.Infinite, bool? @cache = null, string? @language = null, object? @options = null)
    // {
    //     CancellationTokenSource cts = new CancellationTokenSource();
    //     var observer = mediaPlayer.StateChanges()
    //         .Where(s => s.New?.State != "playing")
    //         .Subscribe(_ => cts.Cancel());

    //     try
    //     {
    //         mediaPlayer.GoogleTranslateSay(@message, @cache, @language, @options);
    //         await Task.Delay(maxDelay, cts.Token);
    //     }
    //     catch (OperationCanceledException)
    //     { }
    //     finally
    //     {
    //         observer.Dispose();
    //     }
    // }
}