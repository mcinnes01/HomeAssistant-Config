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

        // If motion mode (dark and in motion)
        // Lounge motion or presence and lamps off, turn lounge light on
        // Main sofa or window sofa presence, turn on lounge corner lamp, turn off lounge light
        // Guest sofa presence, turn on lounge floor lamp
        // TV mode,







        LoungeLightOnMovement();
        LoungeCornerLampOnMovement();
        LoungeFloorLampOnMovement();
        LoungeLightsOffNoMovement();
        LoungeCornerLampOffNoMovement();
        LoungeFloorLampOffNoMovement();
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
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Porch Light off");
            _entities.Light.Porch.TurnOff();
        });
    }
#endregion

#region Lounge
    private void LoungeLightOnMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.LoungeOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.GuestSofaOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.MainSofaOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.WindowSofaOccupancy.StateAllChangesWithCurrent())
        .Where(e =>
        {
            return e.New.IsOn();
        })
        .Subscribe(e =>
        {
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                Lounge Light: {_entities.Light.Lounge.State}");

            if (Constants.NormalMotionModes.Contains(lightMode)
                && Constants.LoungeLightModes.Contains(loungeMode)
                && _entities.Light.Lounge.IsOff()
                && _lightingStates.InMotionMode())
            {
                _logger.LogDebug("Motion detected, turning Lounge Light On.");
                _entities.Light.Lounge.TurnOn();
            }
            else if (Constants.LampMotionModes.Contains(lightMode)
                && Constants.LoungeLampModes.Contains(loungeMode)
                && _entities.Light.Lounge.IsOn()
                && (_entities.BinarySensor.GuestSofaOccupancy.IsDetected()
                || _entities.BinarySensor.MainSofaOccupancy.IsDetected()
                || _entities.BinarySensor.WindowSofaOccupancy.IsDetected()))
            {
                _logger.LogDebug("Motion detected but in a lamp mode, turning Lounge Light Off.");
                _entities.Light.Lounge.TurnOff();
            }
        });
    }

     private void LoungeCornerLampOnMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.LoungeOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.MainSofaOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.WindowSofaOccupancy.StateAllChangesWithCurrent())
        .Where(e =>
        {
            return e.New.IsOn()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(e =>
        {
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                Lounge Corner Lamp: {_entities.Light.LoungeCornerLamp.State}");

            if (Constants.NormalMotionModes.Contains(lightMode)
                && Constants.LoungeLightModes.Contains(loungeMode)
                && _entities.Light.LoungeCornerLamp.IsOn()
                && _entities.BinarySensor.LoungeOccupancy.IsDetected()
                && _entities.BinarySensor.MainSofaOccupancy.IsNotDetected()
                && _entities.BinarySensor.WindowSofaOccupancy.IsNotDetected())
            {
                _logger.LogDebug("Motion detected but not in lamp zone, turning Lounge Corner Lamp Off.");
                _entities.Light.LoungeCornerLamp.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode)
                && Constants.LoungeLampModes.Contains(loungeMode)
                && _entities.Light.LoungeCornerLamp.IsOff())
            {
                _logger.LogDebug("Motion detected, turning Lounge Corner Lamp On.");
                _entities.Light.LoungeCornerLamp.TurnOn();
            }
        });
    }

    private void LoungeFloorLampOnMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.LoungeOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.GuestSofaOccupancy.StateAllChangesWithCurrent())
        .Where(e =>
        {
            return e.New.IsOn()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(e =>
        {
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                Lounge Corner Lamp: {_entities.Light.LoungeCornerLamp.State}");

            if (Constants.NormalMotionModes.Contains(lightMode)
                && Constants.LoungeLightModes.Contains(loungeMode)
                && _entities.Light.LoungeFloorLamp.IsOn()
                && _entities.BinarySensor.LoungeOccupancy.IsDetected()
                && _entities.BinarySensor.GuestSofaOccupancy.IsNotDetected())
            {
                _logger.LogDebug("Motion detected but not in lamp zone, turning Lounge Floor Lamp Off.");
                _entities.Light.LoungeFloorLamp.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode)
                && Constants.LoungeLampModes.Contains(loungeMode)
                && _entities.Light.LoungeFloorLamp.IsOff())
            {
                _logger.LogDebug("Motion detected, turning Lounge Floor Lamp On.");
                _entities.Light.LoungeFloorLamp.TurnOn();
            }
        });
    }

    private void LoungeLightsOffNoMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.LoungeOccupancy.StateAllChangesWithCurrent())
        .WhenStateIsFor(s =>
        {
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: {s?.State},
                Lounge Light: {_entities.Light.Lounge.State}");

            return s.IsOff()
            && _entities.BinarySensor.LoungeMotion.IsOff()
            && _entities.BinarySensor.LoungeOccupancy.IsOff()
            && _entities.Light.Lounge.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual);
        }, TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(e =>
        {
            _logger.LogDebug("No motion, turning Lounge Light Off");
            _entities.Light.Lounge.TurnOff();
        });
    }

    private void LoungeFloorLampOffNoMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.LoungeOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.GuestSofaOccupancy.StateAllChangesWithCurrent())
        .WhenStateIsFor(s =>
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: {s?.State},
                Lounge Floor Lamp: {_entities.Light.LoungeFloorLamp.State}");

            return s.IsOff()
            && ((_entities.BinarySensor.LoungeMotion.IsOff()
            && _entities.BinarySensor.LoungeOccupancy.IsOff())
            || _entities.BinarySensor.GuestSofaOccupancy.IsOff())
            && _entities.Light.LoungeFloorLamp.IsOn()
            && !Constants.LoungeLampModes.Contains(LoungeModeOptions.Television)
            && Constants.LampMotionModes.Contains(lightMode);
        }, TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(e =>
        {
            _logger.LogDebug("No motion, turning Lounge Floor Lamp Off");
            _entities.Light.LoungeFloorLamp.TurnOff();
        });
    }

    private void LoungeCornerLampOffNoMovement()
    {
        _entities.BinarySensor.LoungeMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.LoungeOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.MainSofaOccupancy.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.WindowSofaOccupancy.StateAllChangesWithCurrent())
        .WhenStateIsFor(s =>
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            var loungeMode = _entities.InputSelect.LoungeMode.AsOption<LoungeModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Lounge Mode: {loungeMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Lounge motion: {s?.State},
                Lounge Corner Lamp: {_entities.Light.LoungeCornerLamp.State}");

            return s.IsOff()
            && ((_entities.BinarySensor.LoungeMotion.IsOff()
            && _entities.BinarySensor.LoungeOccupancy.IsOff())
            || (_entities.BinarySensor.MainSofaOccupancy.IsOff()
            && _entities.BinarySensor.WindowSofaOccupancy.IsOff()))
            && _entities.Light.LoungeCornerLamp.IsOn()
            && !Constants.LoungeLampModes.Contains(LoungeModeOptions.Television)
            && Constants.LampMotionModes.Contains(lightMode);
        }, TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(e =>
        {
            _logger.LogDebug("No motion, turning Lounge Corner Lamp Off");
            _entities.Light.LoungeCornerLamp.TurnOff();
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
            TimeSpan.FromMinutes(2), _scheduler)
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
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && (!_entities.Light.Kitchen.IsOff() || !_entities.Light.BreakfastBarLamp.IsOff()),
            TimeSpan.FromMinutes(2), _scheduler)
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