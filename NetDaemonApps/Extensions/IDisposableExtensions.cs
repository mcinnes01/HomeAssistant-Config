namespace NetDaemonApps.Extensions;
public static class IDisposableExtensions
{
    public static void TryDispose(this IDisposable disposable)
    {
        try { disposable.Dispose(); }
        catch {}
    }
}