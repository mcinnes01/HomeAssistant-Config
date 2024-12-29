using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;

//[Focus]
[NetDaemonApp]
public class LightingManager : IAsyncInitializable
{
    private readonly LightingConfig _config;
    private readonly IMqttEntityManager _entityManager;
    private readonly IHaContext _haContext;
    private readonly ILogger<LightingManager> _logger;
    private readonly IScheduler _scheduler;

    public LightingManager(IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager,
    IAppConfig<LightingConfig> config, ILogger<LightingManager> logger)
    {
        _scheduler = scheduler;
        _haContext = haContext;
        _entityManager = entityManager ?? throw new NullReferenceException("Entity Manager not registered with DI");
        _config = config.Value;
        _logger = logger;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting lighter configuration for {count} rooms", _config.Rooms.Count);
        _config.Rooms.ForEach(async room =>
        {
            _logger.LogInformation("Configuring room {Room}", room.Name);
            await room.Register(_entityManager, _scheduler, _haContext, _logger);
            foreach(var light in room.Lights)
            {
                _logger.LogInformation("Configuring light {light} for {Room}", light.Light.Name(), room.Name);
                await light.Register(room, _entityManager, _scheduler, _haContext, _logger);
            }
        });
        return Task.CompletedTask;
    }
}