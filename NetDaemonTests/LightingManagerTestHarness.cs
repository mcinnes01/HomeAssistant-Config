using NetDaemon.apps.LightApp;
using NetDaemon.Extensions.MqttEntityManager;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NetDaemon.Extensions.Testing;

namespace LightApp.Tests;

public class LightingManagerTestHarness : IDisposable
{
    public HaContextMockImpl HaContext { get; }
    public Entities Entities { get; }
    public ILogger<LightingManager> Logger { get; }
    public IMqttEntityManager MqttEntityManager { get; }
    public TestScheduler Scheduler { get; }
    public LightingManager Manager { get; private set; }
    public LightingConfig Config { get; set; }
    public StateChangeManager StateManager { get; }
    public TestEntityBuilder EntityBuilder { get; }

    public LightingManagerTestHarness()
    {
        HaContext = new HaContextMockImpl();
        Entities = new Entities(HaContext);
        Logger = Substitute.For<ILogger<LightingManager>>();
        MqttEntityManager = Substitute.For<IMqttEntityManager>();
        Scheduler = new TestScheduler();
        StateManager = new StateChangeManager(HaContext, Scheduler);
        EntityBuilder = new TestEntityBuilder(HaContext, StateManager);

        // Default configuration - can be overridden in tests
        Config = new LightingConfig
        {
            Rooms = new List<RoomControl>
            {
                new RoomControl
                {
                    Name = "TestRoom",
                    TriggerSensors = new List<BinarySensorEntity>(),
                    PresenceSensors = new List<BinarySensorEntity>(),
                    Lights = new List<LightControl>
                    {
                        new LightControl
                        {
                            Light = EntityBuilder.CreateLightEntity("light.test_light"),
                            Timeout = 240,
                            TriggerSensors = new List<BinarySensorEntity>(),
                            PresenceSensors = new List<BinarySensorEntity>()
                        }
                    }
                }
            }
        };
    }

    public async Task InitializeAsync()
    {
        // Initialize default states
        StateManager.Change(Entities.Light.TestLight, "off");
        StateManager.Change(Entities.InputSelect.TestroomMode, "Normal");
        StateManager.Change(Entities.InputSelect.LocationMode, "Home");

        Manager = new LightingManager(
            Scheduler,
            HaContext,
            MqttEntityManager,
            new LightingConfig(Config),
            Logger
        );

        await Manager.InitializeAsync(CancellationToken.None);
    }

    public void Dispose()
    {
        // Clean up if needed
    }
}