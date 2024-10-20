using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;

//[Focus]
[NetDaemonApp]
public class Lighting : IAsyncInitializable
{
    private readonly LighterConfig _config;
    private readonly IMqttEntityManager _entityManager;
    private readonly IHaContext _haContext;
    private readonly ILogger<Lighting> _logger;
    private readonly IScheduler _scheduler;

    public Lighting(IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager,
    IAppConfig<LighterConfig> config, ILogger<Lighting> logger)
    {
        _scheduler = scheduler;
        _haContext = haContext;
        _entityManager = entityManager ?? throw new NullReferenceException("Entity Manager not registered with DI");
        _config = config.Value;
        _logger = logger;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting lighter configuration for {count} lights", _config.Lights.Count);
        _config.Lights.ToList()
            .ForEach(async r =>
            {
                _logger.LogInformation("Configuring lighter for {light}", r.Light.EntityId);
                await r.Register(_entityManager, _scheduler, _haContext, _logger);
            });
        return Task.CompletedTask;
    }
}