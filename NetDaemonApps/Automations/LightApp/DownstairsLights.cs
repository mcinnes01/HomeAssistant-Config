using System.Reactive.Concurrency;
using NetDaemonApps.Infrastructure.State;

namespace Downstairs;

[NetDaemonApp]
public class DownstairsLights
{
    private readonly ILogger<DownstairsLights> _logger;
    private readonly Entities _entities;
    private readonly IScheduler _scheduler;
    private readonly ILightingStates _lightingStates;
    
    public DownstairsLights(IHaContext ha, ILogger<DownstairsLights> logger,
        IScheduler scheduler, ILightingStates lightingStates)
    {
        _logger = logger;
        _entities = new Entities(ha);
        _scheduler = scheduler;
        _lightingStates = lightingStates;

        // TODO: Fix Hallway motion sensor
        // TODO: Include door/doorbell to control hall lights too
        HallwayLampAndPorchLightOnWhenFrontDoorOpenOrDoorbell();
        // HallwayLightOnMovement();
        // HallwayLightOffNoMovement();
        // HallwayLampOnMovement();
        HallwayLampAndPorchLightOffWhenNoActivity();
        LoungeLightsOnMovement();
        LoungeLightsOffNoMovement();
        DrawingRoomLightsOnMovement();
        DrawingRoomLightsOffNoMovement();
        KitchenLightsOnMovement();
        KitchenLightsOffNoMovement();
    }

#region Hallway
    private void HallwayLampAndPorchLightOnWhenFrontDoorOpenOrDoorbell()
    {
        _entities.BinarySensor.FrontDoorContact.StateChanges()
        .Merge(_entities.BinarySensor.DoorbellButton.StateChanges())
        .Where(e => 
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Front Door: {_entities.BinarySensor.FrontDoorContact.State}, 
                Lamp: {_entities.Light.HallwayLamp.State}");
            return e.New.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && _entities.InputSelect.Brightness.IsNotOption(BrightnessOptions.Bright)
            && _entities.Sun.Sun.IsBelowHorizon(); //<< This should go when brightness automation is fixed 
        })
        .Subscribe(_ => 
        {
            _logger.LogDebug("Frontdoor open or doorbell rang, turning hallway lamp on");
            _entities.Light.HallwayLamp.TurnOn();
            _entities.Light.Porch.TurnOn();
        });
    }

    // private void HallwayLightOnMovement()
    // {
    //     _entities.BinarySensor.HallwayMotion.StateChanges()
    //     .Where(e => 
    //     {
    //         _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
    //             Hallway motion: Old: {e.Old?.State} - New: {e.New?.State}, 
    //             Light: {_entities.Light.Hallway.State}, 
    //             Lamp: {_entities.Light.HallwayLamp.State}");
    //         return !e.Old.IsOn()
    //         && e.New.IsOn()
    //         && _entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Relaxing)
    //         && _entities.Light.Hallway.IsOff()
    //         && _entities.Light.HallwayLamp.IsOff();
    //     })
    //     .Subscribe(_ => 
    //     {
    //         _logger.LogDebug("Motion detected, turning hallway light on");
    //         _entities.Light.Hallway.TurnOn();
    //     });
    // }

    // private void HallwayLightOffNoMovement()
    // {
    //     _entities.BinarySensor.HallwayMotion.StateAllChangesWithCurrent()
    //     .WhenStateIsFor(s => s.IsOff()
    //         && !_entities.Light.Hallway.IsOff()
    //         && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
    //         TimeSpan.FromMinutes(2))
    //     .Subscribe(_ => 
    //     {
    //         _logger.LogDebug("No motion, turning Hallway light off");
    //         _entities.Light.Hallway.TurnOff();
    //     });
    // }

    // private void HallwayLampOnMovement()
    // {
    //     _entities.BinarySensor.HallwayMotion.StateChanges() 
    //     .Where(e => 
    //     {
    //         _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
    //             Hallway motion: Old: {e.Old?.State} - New: {e.New?.State}, 
    //             Light: {_entities.Light.Hallway.State}, 
    //             Lamp: {_entities.Light.HallwayLamp.State}");
    //         return !e.Old.IsOn()
    //         && e.New.IsOn()
    //         && _entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Relaxing)
    //         && _entities.Light.Hallway.IsOff()
    //         && _entities.Light.HallwayLamp.IsOff();
    //     })
    //     .Subscribe(_ => 
    //     {
    //         _logger.LogDebug("Motion detected, turning Hallway Lamp on");
    //         _entities.Light.HallwayLamp.TurnOn();
    //     });
    // }

    private void HallwayLampAndPorchLightOffWhenNoActivity()
    {
        _entities.BinarySensor.FrontDoorContact.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.DoorbellButton.StateAllChangesWithCurrent())
        .Where(_ => TimeOnly.FromDateTime(DateTime.Now) > Constants.PORCH_LIGHT_OFF_TIME)
        .WhenStateIsFor(s => s.IsOff() &&
            _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2))
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Porch Light off");
            _entities.Light.Porch.TurnOff();
        });
    }
#endregion

#region Lounge
    private void LoungeLightsOnMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateChanges()
        .Where(e => 
        {
            return !e.Old.IsOn()
            && e.New.IsOn()
            && _lightingStates.InMotionMode()
            && _entities.Light.LoungeLights.IsOff();
        })
        .Subscribe(e => 
        {
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                Lounge Corner Lamp: {_entities.Light.LoungeCornerLamp.State},
                Lounge Floor Lamp: {_entities.Light.LoungeFloorLamp.State}, 
                Lounge Light: {_entities.Light.Lounge.State}");

            if (Constants.NormalMotionModes.Contains(lightMode)
                && Constants.LoungeLightModes.Contains(loungeMode))
            {
                _logger.LogDebug("Motion detected, turning Lounge Light On.");
                _entities.Light.Lounge.TurnOn();
                _entities.Light.LoungeCornerLamp.TurnOff();
                _entities.Light.LoungeFloorLamp.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode)
                && Constants.LoungeLampModes.Contains(loungeMode))
            {
                _logger.LogDebug("Motion detected, turning Lounge Lamps On.");
                _entities.Light.Lounge.TurnOff();
                _entities.Light.LoungeCornerLamp.TurnOn();
                _entities.Light.LoungeFloorLamp.TurnOn();
            }
        });
    }

    private void LoungeLightsOffNoMovement()
    {
        _entities.BinarySensor.LoungeMotion
        .StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.LoungeLights.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2))
        .Subscribe(e => 
        {
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                Lounge Corner Lamp: {_entities.Light.LoungeCornerLamp.State},
                Lounge Floor Lamp: {_entities.Light.LoungeFloorLamp.State}, 
                Lounge Light: {_entities.Light.Lounge.State}");

            if (Constants.NormalMotionModes.Contains(lightMode)
                && loungeMode != LoungeModeOptions.Reading)
            {
                _logger.LogDebug("No motion, turning Lounge Light Off");
                _entities.Light.Lounge.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode)
                && loungeMode != LoungeModeOptions.Television)
            {
                _logger.LogDebug("No motion, turning Lounge Lamps Off");
                _entities.Light.LoungeCornerLamp.TurnOff();
                _entities.Light.LoungeFloorLamp.TurnOff();
            }
        });
    }
#endregion

#region Drawing Room
    private void DrawingRoomLightsOnMovement()
    {
        _entities.BinarySensor.DrawingRoomMotion.StateChanges()
        .Where(e => 
        {
            return !e.Old.IsOn()
            && e.New.IsOn()
            && _lightingStates.InMotionMode()
            && _entities.Light.DrawingRoomLights.IsOff();
        })
        .Subscribe(e => 
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},  
                Brightness: {_entities.InputSelect.Brightness.State},
                Drawing Room Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Bookshelf Light: {_entities.Light.Bookshelf.State},
                Drawing Room Light: {_entities.Light.DrawingRoom.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Drawing Room Light On.");
                _entities.Light.DrawingRoom.TurnOn();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Bookshelf Light On.");
                _entities.Light.Bookshelf.TurnOn();
            }
        });
    }

    private void DrawingRoomLightsOffNoMovement()
    {
        _entities.BinarySensor.DrawingRoomMotion
        .StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.DrawingRoomLights.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2))
        .Subscribe(e => 
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},  
                Brightness: {_entities.InputSelect.Brightness.State},
                Drawing Room Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Bookshelf Light: {_entities.Light.Bookshelf.State},
                Drawing Room Light: {_entities.Light.DrawingRoom.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Drawing Room Light Off");
                _entities.Light.DrawingRoom.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Bookshelf Light Off");
                _entities.Light.Bookshelf.TurnOff();
            }
        });
    }
#endregion

#region Kitchen
    private void KitchenLightsOnMovement()
    {
        _entities.BinarySensor.KitchenMotion.StateChanges()
        .Merge(_entities.BinarySensor.KitchenCameraMotion.StateChanges())
        .Where(e => 
        {
            return !e.Old.IsOn()
            && e.New.IsOn()
            && _lightingStates.InMotionMode()
            && _entities.Light.Kitchen.IsOff()
            && _entities.Light.BreakfastBarLamp.IsOff();
        })
        .Subscribe(e => 
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},  
                Brightness: {_entities.InputSelect.Brightness.State},
                Kitchen Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Breakfast Bar Lamp: {_entities.Light.BreakfastBarLamp.State}, 
                Kitchen Light: {_entities.Light.Kitchen.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Kitchen Light On.");
                _entities.Light.Kitchen.TurnOn();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Breakfast Bar Lamp On.");
                _entities.Light.BreakfastBarLamp.TurnOn();
            }
        });
    }

    private void KitchenLightsOffNoMovement()
    {
        _entities.BinarySensor.KitchenMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.KitchenCameraMotion.StateAllChangesWithCurrent())
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.Kitchen.IsOff()
            && !_entities.Light.BreakfastBarLamp.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2))
        .Subscribe(e => 
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},  
                Brightness: {_entities.InputSelect.Brightness.State},
                Kitchen Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Breakfast Bar Lamp: {_entities.Light.BreakfastBarLamp.State}, 
                Kitchen Light: {_entities.Light.Kitchen.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Kitchen Light Off");
                _entities.Light.Kitchen.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Breakfast Bar Light Off");
                _entities.Light.BreakfastBarLamp.TurnOff();
            }
        });
    }
#endregion
}


        // .Select(s =>
        // {
        //     // Get how long light has been on for or defaults to now
        //     var lightState = _entities.Light.Lounge.EntityState;
        //     var turnedOn = lightState.IsOn()
        //         ? lightState?.LastUpdated ?? DateTime.Now 
        //         : DateTime.Now;
        //     // The default duration before turning the light off
        //     var duration = TimeSpan.FromMinutes(2);
        //     // The max duration before turning the light off
        //     var maxDuration = TimeSpan.FromMinutes(15);
        //     // The exponential delay factor is half the time the light has been on for
        //     var exponentialDelay = duration + ((DateTime.Now - turnedOn) / 2);
        //     _logger.LogTrace($"Exponential Delay: {exponentialDelay} - Light turn on at: {turnedOn} - Old duration: {duration}");
        //     // Set the new duration between our default and max duration
        //     duration = exponentialDelay < maxDuration 
        //         ? exponentialDelay : maxDuration;    
        //     return Observable.Timer(duration);
        // })
        // .Switch()
        // .ObserveOn(_scheduler)