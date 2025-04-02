using LightApp.Tests;
using Moq;
using NetDaemon.apps.LightApp;
using NetDaemon.Enums;
using NetDaemon.Models;
using Xunit;

public class LightingManagerTests : IClassFixture<LightingManagerTestHarness>
{
    private readonly LightingManagerTestHarness _harness;

    public LightingManagerTests(LightingManagerTestHarness harness)
    {
        _harness = harness;
    }

    [Fact]
    public async Task HallwayLight_TurnsOn_WhenDoorbellPressedAtNight()
    {
        // Arrange
        _harness._config = new LightingConfig
        {
            Rooms = new List<RoomControl>
            {
                new RoomControl
                {
                    Name = "hallway",
                    IsEntrance = true,
                    TriggerSensors = new List<BinarySensorEntity>
                    {
                        new BinarySensorEntity(_harness._haContextMock, "binary_sensor.doorbell_button")
                    },
                    PresenceSensors = new List<BinarySensorEntity>
                    {
                        new BinarySensorEntity(_harness._haContextMock, "binary_sensor.hallway_motion")
                    },
                    Lights = new List<LightControl>
                    {
                        new LightControl
                        {
                            Light = new LightEntity(_harness._haContextMock, "light.hallway_lamp"),
                            TriggerWithoutPresence = true,
                            Conditions = new List<Condition>
                            {
                                new Condition
                                {
                                    Entity = new Entity(_harness._haContextMock, "sun.sun"),
                                    Operator = Operator.Equals,
                                    State = "below_horizon"
                                },
                                new Condition
                                {
                                    Entity = new Entity(_harness._haContextMock, "input_select.bedroom_mode"),
                                    Operator = Operator.NotEquals,
                                    State = "Sleeping"
                                }
                            },
                            Timeout = 240,
                            TriggerSensors = new List<BinarySensorEntity>
                            {
                                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.doorbell_button")
                            },
                            PresenceSensors = new List<BinarySensorEntity>
                            {
                                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.hallway_motion")
                            }
                        }
                    }
                }
            }
        };

        // Set initial states
        _harness._haContextMock.SetupEntityState("sun.sun", "below_horizon");
        _harness._haContextMock.SetupEntityState("input_select.bedroom_mode", "Normal");
        _harness._haContextMock.SetupEntityState("light.hallway_lamp", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.doorbell_button", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.hallway_motion", "off");

        await _harness.InitializeAsync();

        // Act - Doorbell pressed
        _harness._haContextMock.TriggerStateChange("binary_sensor.doorbell_button", "off", "on");

        // Assert
        _harness._haContextMock.VerifyServiceCalled("light", "turn_on", 
            "light.hallway_lamp", Times.Once());
    }

    [Fact]
    public async Task KitchenLight_TurnsOn_WhenMotionDetectedAndDark()
    {
        // Arrange
        _harness._config = new LightingConfig
        {
            Rooms = new List<RoomControl>
            {
                new RoomControl
                {
                    Name = "kitchen",
                    IlluminanceSensor = new NumericSensorEntity(_harness._haContextMock, "sensor.kitchen_illuminance"),
                    IlluminanceLowThreshold = 7,
                    IlluminanceHighThreshold = 71,
                    TriggerSensors = new List<BinarySensorEntity>
                    {
                        new BinarySensorEntity(_harness._haContextMock, "binary_sensor.kitchen_motion")
                    },
                    PresenceSensors = new List<BinarySensorEntity>
                    {
                        new BinarySensorEntity(_harness._haContextMock, "binary_sensor.kitchen_occupancy")
                    },
                    Lights = new List<LightControl>
                    {
                        new LightControl
                        {
                            Light = new LightEntity(_harness._haContextMock, "light.kitchen_light"),
                            Timeout = 240,
                            TriggerSensors = new List<BinarySensorEntity>
                            {
                                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.kitchen_motion")
                            },
                            PresenceSensors = new List<BinarySensorEntity>
                            {
                                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.kitchen_occupancy")
                            }
                        }
                    }
                }
            }
        };

        // Set initial states
        _harness._haContextMock.SetupEntityState("sensor.kitchen_illuminance", "5"); // Below threshold
        _harness._haContextMock.SetupEntityState("light.kitchen_light", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.kitchen_motion", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.kitchen_occupancy", "off");
        _harness._haContextMock.SetupEntityState("input_select.location_mode", "Home");
        _harness._haContextMock.SetupEntityState("input_select.kitchen_mode", "Normal");

        await _harness.InitializeAsync();

        // Act - Motion detected
        _harness._haContextMock.TriggerStateChange("binary_sensor.kitchen_motion", "off", "on");

        // Assert
        _harness._haContextMock.VerifyServiceCalled("light", "turn_on", 
            "light.kitchen_light", Times.Once());
    }

    [Fact]
    public async Task LightControl_InitializesAllDependencies()
    {
        // Arrange
        var lightControl = new LightControl
        {
            Light = new LightEntity(_harness._haContextMock, "light.test_light"),
            Timeout = 240,
            TriggerSensors = new List<BinarySensorEntity>
            {
                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.test_trigger1"),
                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.test_trigger2")
            },
            PresenceSensors = new List<BinarySensorEntity>
            {
                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.test_presence1"),
                new BinarySensorEntity(_harness._haContextMock, "binary_sensor.test_presence2")
            },
            BlockEntities = new List<Entity>
            {
                new Entity(_harness._haContextMock, "switch.test_block")
            },
            KeepAliveEntities = new List<Entity>
            {
                new Entity(_harness._haContextMock, "switch.test_keepalive")
            },
            Conditions = new List<Condition>
            {
                new Condition
                {
                    Entity = new Entity(_harness._haContextMock, "sun.sun"),
                    Operator = Operator.Equals,
                    State = "below_horizon"
                }
            }
        };

        _harness._config = new LightingConfig
        {
            Rooms = new List<RoomControl>
            {
                new RoomControl
                {
                    Name = "test",
                    Lights = new List<LightControl> { lightControl },
                    TriggerSensors = new List<BinarySensorEntity>(),
                    PresenceSensors = new List<BinarySensorEntity>()                    
                }
            }
        };

        // Set initial states
        _harness._haContextMock.SetupEntityState("light.test_light", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.test_trigger1", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.test_trigger2", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.test_presence1", "off");
        _harness._haContextMock.SetupEntityState("binary_sensor.test_presence2", "off");
        _harness._haContextMock.SetupEntityState("switch.test_block", "off");
        _harness._haContextMock.SetupEntityState("switch.test_keepalive", "off");
        _harness._haContextMock.SetupEntityState("sun.sun", "below_horizon");
        _harness._haContextMock.SetupEntityState("input_select.location_mode", "Home");
        _harness._haContextMock.SetupEntityState("input_select.test_mode", "Normal");

        await _harness.InitializeAsync();

        // Act - Trigger each sensor to verify they're properly initialized
        _harness._haContextMock.TriggerStateChange("binary_sensor.test_trigger1", "off", "on");
        _harness._haContextMock.TriggerStateChange("binary_sensor.test_presence1", "off", "on");
        _harness._haContextMock.TriggerStateChange("switch.test_block", "off", "on");
        _harness._haContextMock.TriggerStateChange("switch.test_keepalive", "off", "on");
        _harness._haContextMock.TriggerStateChange("sun.sun", "below_horizon", "above_horizon");

        // Assert
        // Verify light turns on when trigger is activated
        _harness._haContextMock.VerifyServiceCalled("light", "turn_on", 
            "light.test_light", Times.Once());
        
        // Verify light turns off when block is activated
        _harness._haContextMock.VerifyServiceCalled("light", "turn_off", 
            "light.test_light", Times.AtLeastOnce());
    }
}