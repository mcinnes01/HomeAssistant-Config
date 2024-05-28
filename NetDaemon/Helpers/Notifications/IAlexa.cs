namespace NetDaemon.Notifications.Helpers;

public interface IAlexa
{
    public Dictionary<string, AlexaPeopleConfig> People { get; }
    public IObservable<PromptResponse> PromptResponses { get; }
    void Announce(Alexa.Config config);
    void Announce(string mediaPlayer, string message);
    void Prompt(string mediaPlayer, string message, string eventId);
    void TextToSpeech(Alexa.Config config);
    void TextToSpeech(string mediaPlayer, string message);
}