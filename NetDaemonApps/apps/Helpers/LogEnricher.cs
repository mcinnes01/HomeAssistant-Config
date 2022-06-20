namespace Helpers;

public class LogEnricher : ILogger
{
    private readonly Entities _entities;
    private readonly ILogger<LogEnricher> _logger;

    public LogEnricher(IHaContext context, ILogger<LogEnricher> logger)
    {
        _entities = new Entities(context);
        _logger = logger;
    }

    public override void LogDebug()
    {

    }

}