using LightApp.Tests;
using NetDaemon.apps.LightApp;
using NetDaemon.Enums;
using NetDaemon.Extensions.Testing;
using NetDaemon.HassModel.Entities;
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
        _harness.Config = new LightingConfig
        {
            Rooms = new List<RoomControl>
            {
                new RoomControl
                {
                    Name = "hallway",
                    IsEntrance = true,
                    TriggerSensors = new List<BinarySensorEntity>
                    {
                        _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.doorbell_button")
                    },
                    PresenceSensors = new List<BinarySensorEntity>
                    {
                        _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.hallway_motion")
                    },
                    Lights = new List<LightControl>
                    {
                        new LightControl
                        {
                            Light = _harness.EntityBuilder.CreateLightEntity("light.hallway_lamp"),
                            TriggerWithoutPresence = true,
                            Conditions = new List<Condition>
                            {
                                new Condition
                                {
                                    Entity = new Entity(_harness.HaContext, "sun.sun"),
                                    Operator = Operator.Equals,
                                    State = "below_horizon"
                                },
                                new Condition
                                {
                                    Entity = new Entity(_harness.HaContext, "select.bedroom_mode"),
                                    Operator = Operator.NotEquals,
                                    State = "Sleeping"
                                }
                            },
                            Timeout = 240,
                            TriggerSensors = new List<BinarySensorEntity>
                            {
                                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.doorbell_button")
                            },
                            PresenceSensors = new List<BinarySensorEntity>
                            {
                                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.hallway_motion")
                            }
                        }
                    }
                }
            }
        };

        // Set initial states
        _harness.StateManager
            .Change(new Entity(_harness.HaContext, "sun.sun"), "below_horizon")
            .Change(new Entity(_harness.HaContext, "select.bedroom_mode"), "Normal")
            .Change(_harness.EntityBuilder.CreateLightEntity("light.hallway_lamp"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.doorbell_button"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.hallway_motion"), "off");

        await _harness.InitializeAsync();

        // Act - Doorbell pressed
        _harness.StateManager.Change(
            _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.doorbell_button"), 
            "on");

        // Assert
        var serviceCalls = _harness.HaContext.ServiceCalls
            .Filter(Domain.Light, "turn_on")
            .Where(c => ((string)c.Target?.EntityIds?.FirstOrDefault()) == "light.hallway_lamp");
        
        Assert.Single(serviceCalls);
    }

    [Fact]
    public async Task KitchenLight_TurnsOn_WhenMotionDetectedAndDark()
    {
        // Arrange
        _harness.Config = new LightingConfig
        {
            Rooms = new List<RoomControl>
            {
                new RoomControl
                {
                    Name = "kitchen",
                    IlluminanceSensor = _harness.EntityBuilder.CreateNumericEntity("sensor.kitchen_illuminance"),
                    IlluminanceLowThreshold = 7,
                    IlluminanceHighThreshold = 71,
                    TriggerSensors = new List<BinarySensorEntity>
                    {
                        _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_motion")
                    },
                    PresenceSensors = new List<BinarySensorEntity>
                    {
                        _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_occupancy")
                    },
                    Lights = new List<LightControl>
                    {
                        new LightControl
                        {
                            Light = _harness.EntityBuilder.CreateLightEntity("light.kitchen_light"),
                            Timeout = 240,
                            TriggerSensors = new List<BinarySensorEntity>
                            {
                                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_motion")
                            },
                            PresenceSensors = new List<BinarySensorEntity>
                            {
                                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_occupancy")
                            }
                        }
                    }
                }
            }
        };

        // Set initial states
        _harness.StateManager
            .Change(_harness.EntityBuilder.CreateNumericEntity("sensor.kitchen_illuminance"), 5) // Below threshold
            .Change(_harness.EntityBuilder.CreateLightEntity("light.kitchen_light"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_motion"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_occupancy"), "off")
            .Change(new Entity(_harness.HaContext, "select.location_mode"), "Home")
            .Change(new Entity(_harness.HaContext, "select.kitchen_mode"), "Normal");

        await _harness.InitializeAsync();

        // Act - Motion detected
        _harness.StateManager.Change(
            _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.kitchen_motion"), 
            "on");

        // Assert
        var serviceCalls = _harness.HaContext.ServiceCalls
            .Filter(Domain.Light, "turn_on")
            .Where(c => ((string)c.Target?.EntityIds?.FirstOrDefault()) == "light.kitchen_light");
        
        Assert.Single(serviceCalls);
    }

    [Fact]
    public async Task LightControl_InitializesAllDependencies()
    {
        // Arrange
        var lightControl = new LightControl
        {
            Light = _harness.EntityBuilder.CreateLightEntity("light.test_light"),
            Timeout = 240,
            TriggerSensors = new List<BinarySensorEntity>
            {
                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_trigger1"),
                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_trigger2")
            },
            PresenceSensors = new List<BinarySensorEntity>
            {
                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_presence1"),
                _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_presence2")
            },
            BlockEntities = new List<Entity>
            {
                new Entity(_harness.HaContext, "switch.test_block")
            },
            KeepAliveEntities = new List<Entity>
            {
                new Entity(_harness.HaContext, "switch.test_keepalive")
            },
            Conditions = new List<Condition>
            {
                new Condition
                {
                    Entity = new Entity(_harness.HaContext, "sun.sun"),
                    Operator = Operator.Equals,
                    State = "below_horizon"
                }
            }
        };

        _harness.Config = new LightingConfig
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
        _harness.StateManager
            .Change(_harness.EntityBuilder.CreateLightEntity("light.test_light"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_trigger1"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_trigger2"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_presence1"), "off")
            .Change(_harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_presence2"), "off")
            .Change(new Entity(_harness.HaContext, "switch.test_block"), "off")
            .Change(new Entity(_harness.HaContext, "switch.test_keepalive"), "off")
            .Change(new Entity(_harness.HaContext, "sun.sun"), "below_horizon")
            .Change(new Entity(_harness.HaContext, "select.location_mode"), "Home")
            .Change(new Entity(_harness.HaContext, "select.test_mode"), "Normal");

        await _harness.InitializeAsync();

        // Act - Trigger each sensor to verify they're properly initialized
        _harness.StateManager.Change(
            _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_trigger1"), 
            "on");
        
        _harness.StateManager.Change(
            _harness.EntityBuilder.CreateBinarySensorEntity("binary_sensor.test_presence1"), 
            "on");
            
        _harness.StateManager.Change(
            new Entity(_harness.HaContext, "switch.test_block"), 
            "on");
            
        _harness.StateManager.Change(
            new Entity(_harness.HaContext, "switch.test_keepalive"), 
            "on");
            
        _harness.StateManager.Change(
            new Entity(_harness.HaContext, "sun.sun"), 
            "above_horizon");

        // Assert
        // Verify light turns on when trigger is activated
        var turnOnCalls = _harness.HaContext.ServiceCalls
            .Filter(Domain.Light, "turn_on")
            .Where(c => ((string)c.Target?.EntityIds?.FirstOrDefault()) == "light.test_light");
        
        Assert.Single(turnOnCalls);
        
        // Verify light turns off when block is activated
        var turnOffCalls = _harness.HaContext.ServiceCalls
            .Filter(Domain.Light, "turn_off")
            .Where(c => ((string)c.Target?.EntityIds?.FirstOrDefault()) == "light.test_light");
        
        Assert.NotEmpty(turnOffCalls);
    }
}