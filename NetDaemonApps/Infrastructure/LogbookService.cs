namespace NetDaemonApps.Infrastructure;

public class LogbookHelperRegister
{
    public LogbookHelperRegister(IServices services)
    {
        LogbookHelper.Configure(services.Logbook);
    }
}

public static class LogbookHelper
{
    private static LogbookServices? Logbook;

    public static void Configure(LogbookServices logbook)
    {
        Logbook = logbook;
    }

    public static void Log(this Entity? entity, string message)
    {
        var attribute = entity?.Attributes as FriendlyNameAttribute;
        var name = attribute?.FriendlyName ?? entity?.EntityId?.ToString();
        Logbook?.Log(name, message, entity?.EntityId, entity.Domain());
    }
}