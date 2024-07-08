namespace NetDaemon.Helpers.Notifications;

public class VoiceProvider : IVoiceProvider
{
    private readonly List<string> _voices = new() { "Amy", "Brian", "Emma", "Nicole", "Russell", "Geraint" };

    public string GetRandomVoice() => _voices[Random.Shared.Next(0, _voices.Count - 1)];
}