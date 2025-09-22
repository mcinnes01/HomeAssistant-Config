using Humanizer;
using NetDaemon.Extensions.MqttEntityManager;

namespace NetDaemon.apps.LightApp;

//[Focus]
[NetDaemonApp]
public class LightingManager : IAsyncInitializable
{
    private readonly LightingConfig _config;
    private readonly IMqttEntityManager _entityManager;
    private readonly IHaContext _haContext;
    private readonly Entities _entities;
    private readonly ILogger<LightingManager> _logger;
    private readonly IScheduler _scheduler;
    private readonly InputSelectEntity _locationMode;

    public LightingManager(IScheduler scheduler, IHaContext haContext, IMqttEntityManager entityManager,
    IAppConfig<LightingConfig> config, ILogger<LightingManager> logger)
    {
        _scheduler = scheduler;
        _haContext = haContext;
        _entities = new Entities(haContext);
        _entityManager = entityManager ?? throw new NullReferenceException("Entity Manager not registered with DI");
        _config = config.Value;
        _logger = logger;
        _locationMode = _entities.InputSelect.LocationMode;
    }

    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting lighter configuration for {count} rooms", _config.Rooms.Count);
        _config.Rooms.ForEach(async room =>
        {
            _logger.LogInformation("Configuring room {Room}", room.TitleName);
            await room.Register(_entityManager, _scheduler, _haContext, _logger);
            foreach (var light in room.Lights)
            {
                _logger.LogInformation("Configuring light {light} for {Room}", light.Light.Name(), room.TitleName);
                await light.Register(room, _entityManager, _scheduler, _haContext, _logger);
            }
        });


        return Task.CompletedTask;
    }

    private async Task SubscribeToBedroomModeControls()
    {
        SelectEntity bedroomMode = _entities.Select.BedroomMode;

        List<SelectEntity> bedroomModes = _config.Rooms
            .Where(r => r.IsBedroom && r.RoomMode != null && r.Name != "Bedroom")
            .Select(r => r.RoomMode!)
            .ToList();

        var bedroomModeState = bedroomMode.StateChanges();
        bedroomModes.Select(r => bedroomModeState.Merge(r.StateChanges()));
        bedroomModeState.Where(s => s.New?.State != null && (s.New.IsSleeping() || s.New.IsNormal()))
        .Subscribe(s =>
        {
            // If we are home and no guests, set all other room modes to match the beedroom mode
            if (s.Entity.EntityId == bedroomMode.EntityId)
            {
                if (_locationMode.OneOrBothHome())
                {
                    _logger.LogInformation("Setting all rooms to {Mode} based on bedroom mode.", s.New!.State);
                    bedroomModes.ForEach(r => r.SelectOption(s.New.State!));
                }
                // If people are staying and there is no presence in party rooms for 20 minutes we can change the room modes
                else if (_locationMode.PeopleStaying() && s.New.State == "sleeping")
                {
                    foreach (var room in _config.Rooms.Where(r => r.Name != "Bedroom"))
                    {
                        room.PresenceSensors.All().WhenStateFor(
                            () =>
                                (!room.IsBedroom && room.PresenceSensors.All(p =>
                                    p.IsNotDetected() &&
                                    p.EntityState.LastChanged != null &&
                                    (DateTime.UtcNow - p.EntityState.LastChanged.Value).TotalMinutes >= 20))
                                ||
                                (room.IsBedroom && room.PresenceSensors.Any(p => p.IsDetected())),
                            async () =>
                            {
                                _logger.LogInformation("Setting {Room} to sleeping due to presence state.", room.TitleName);
                                await room.RoomMode.SelectOption("sleeping");
                            });
                    }
                }
            }
        });
    }
}