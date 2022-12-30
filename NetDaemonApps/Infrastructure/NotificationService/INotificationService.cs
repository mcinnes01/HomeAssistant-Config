using System.Threading.Tasks;

namespace NetDaemonApps.Infrastructure;

public interface INotificationService
{
    void Send(PhoneTarget phone, string message, string? title, MobileAppMessageData? data = null);

    void Send(TVTarget tv, string message, string? icon);

    void Speak(SpeakerTarget speaker, string message, bool? cache = null, string? language = null);

    Task SpeakAsync(SpeakerTarget speaker, string message, int maxDelay = Timeout.Infinite, bool? cache = null, string? language = null);

    void Speak(PhoneTarget phone, string message, SpeakPriority priority);

    string? GetMessage(string key);    
}