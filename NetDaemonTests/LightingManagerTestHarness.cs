using NetDaemon.apps.LightApp;
using NetDaemon.Extensions.MqttEntityManager;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Reactive.Concurrency;
using NetDaemon.Extensions.Testing;
using NetDaemon.HassModel.Integration;

namespace LightApp.Tests;

public class LightingManagerTestHarness : IDisposable
{
    public HaContextMockImpl HaContextMock { get; }
    public Entities Entities { get; }
    public ILogger<LightingManager> Logger { get; }
    public IMqttEntityManager MqttEntityManager { get; }
    public IScheduler Scheduler { get; }
    public LightingManager Manager { get; private set; }
    public LightingConfig Config { get; set; }

    public LightingManagerTestHarness()
    {
        HaContextMock = new HaContextMockImpl();
        Entities = new Entities(HaContextMock);
        Logger = Substitute.For<ILogger<LightingManager>>();
        MqttEntityManager = Substitute.For<IMqttEntityManager>();
        Scheduler = new TestScheduler();

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
                            Light = new LightEntity(HaContextMock, "light.test_light"),
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
        HaContextMock.SetEntityState("light.test_light", "off");
        HaContextMock.SetEntityState("input_select.testroom_mode", "Normal");
        HaContextMock.SetEntityState("input_select.location_mode", "Home");

        Manager = new LightingManager(
            Scheduler,
            HaContextMock,
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