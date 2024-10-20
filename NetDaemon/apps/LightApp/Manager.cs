using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;

//[Focus]
//[NetDaemonApp]
public class Manager : IAsyncInitializable
{
    private readonly ManagerConfig _config;
    private readonly IMqttEntityManager _entityManager;
    private readonly IHaContext _haContext;
    private readonly ILogger<Manager> _managerLogger;
    private readonly IScheduler _scheduler;

    public Manager(IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager,
    IAppConfig<ManagerConfig> config, ILogger<Manager> managerLogger)
    {
        _scheduler = scheduler;
        _haContext = haContext;
        _entityManager = entityManager ?? throw new NullReferenceException("Entity Manager not registered with DI");
        _config = config.Value;
        _managerLogger = managerLogger;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        _managerLogger.LogInformation("Starting light manager configuration for {room} rooms", _config.Rooms.Count);
        _config.Rooms.ToList()
            .ForEach(async r =>
            {
                _managerLogger.LogInformation("Configuring light manager for {room}", r.Name);
                await r.Init(_managerLogger, _config.NdUserId, _scheduler, _haContext, _entityManager);
            });
        return Task.CompletedTask;
    }
}