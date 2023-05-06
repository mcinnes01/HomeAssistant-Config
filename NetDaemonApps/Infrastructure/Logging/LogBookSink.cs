using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Serilog.Events;

class LogBookSink : ILogEventSink
{
    private readonly IServiceProvider _provider;

    public LogBookSink(IServiceProvider serviceProvider)
    {
        _provider = serviceProvider;
    }

    public void Emit(LogEvent logEvent)
    {
        if (logEvent.Properties.TryGetValue("Entity", out var entityProperty) &&
            entityProperty is ScalarValue entityIdValue &&
            entityIdValue.Value is string entityId)
        {
            // Rehydrate the entity from the ha context
            var haContext = _provider.GetService<IHaContext>();
            var entity = haContext?.Entity(entityId);
            if (entity == null)
                return;

            // Get the logbook service
            var services = _provider.GetService<IServices>();
            var logbook = services?.Logbook;
            if (logbook == null)
                return;

            // Log the message with the entity ID
            var message = logEvent.RenderMessage();
            var level = MapLogLevel(logEvent);
            var attribute = entity?.Attributes as FriendlyNameAttribute;
            var name = attribute?.FriendlyName ?? entity!.EntityId.ToString();
            logbook.Log(name, message, entityId, entity.Domain());
        }
    }
    
    private static string MapLogLevel(LogEvent logEvent) =>
    logEvent.Level switch
    {
        LogEventLevel.Fatal => "critical",
        LogEventLevel.Error => "error",
        LogEventLevel.Warning => "warning",
        LogEventLevel.Information => "info",
        LogEventLevel.Debug => "debug",
        _ => "info",
    };
}