using NetDaemon.Extensions.MqttEntityManager;

namespace LightManagerV2;

//[Focus]
[NetDaemonApp]
public class LightsManager : IAsyncInitializable
{
    private readonly ManagerConfig          _config;
    private readonly IMqttEntityManager     _entityManager;
    private readonly IHaContext             _haContext;
    private readonly ILogger<LightsManager> _managerLogger;
    private readonly ILogger<RandomManager> _randomLogger;
    private readonly IScheduler             _scheduler;
    private          RandomManager          _randomManager;

    public LightsManager(IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager,
    IAppConfig<ManagerConfig> config, ILogger<LightsManager> managerLogger, ILogger<RandomManager> randomLogger)
    {
        _scheduler     = scheduler;
        _haContext     = haContext;
        _entityManager = entityManager ?? throw new NullReferenceException("Entity Manager not registered with DI");
        _config        = config.Value;
        _managerLogger = managerLogger;
        _randomLogger  = randomLogger;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        _managerLogger.LogInformation("Starting light manager configuration for {room} rooms", _config.Rooms.Count);
        _randomManager = new RandomManager(_scheduler, _config.RandomSwitchEntity, _config.MinDuration, _config.MaxDuration, _randomLogger);
        ( _config.Rooms.Any(r => r.Debug)
                ? _config.Rooms.Where(r => r.Debug).ToList()
                : _config.Rooms.ToList())
            .ForEach(async r =>
            {
                _managerLogger.LogInformation("Configuring light manager for {room}", r.Name);
                await r.Init(_managerLogger, _config.NdUserId, _randomManager, _scheduler, _haContext, _entityManager, _config.GuardTimeout, _config.LocationMode, _config.LightControlMode);
            });
        return Task.CompletedTask;
    }
}