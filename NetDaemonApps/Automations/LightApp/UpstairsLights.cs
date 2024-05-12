using NetDaemonApps.Infrastructure.State;

namespace Upstairs;

[NetDaemonApp]
public class UpstairsLights
{
    private readonly IScheduler _scheduler;
    private readonly ILogger<UpstairsLights> _logger;
    private readonly Entities _entities;
    private readonly ILightingStates _lightingStates;
    private IDisposable _bathroomOccupancyDisposable;
    private bool _bathroomWaspInABox = false;
    private bool OutOfBed => 
        _entities.InputSelect.BedroomMode.IsNotOption(BedroomModeOptions.Sleeping) ||
        _entities.InputSelect.BedroomMode.IsOption(BedroomModeOptions.Sleeping) &&
        _entities.InputSelect.LocationMode.IsOption(LocationModeOptions.Home) &&
        (_entities.BinarySensor.AndyInBed.IsOff() || _entities.BinarySensor.ClaireInBed.IsOff()) ||
        (_entities.InputSelect.LocationMode.IsOption(LocationModeOptions.OneAway) &&
        _entities.BinarySensor.AndyInBed.IsOff() && _entities.BinarySensor.ClaireInBed.IsOff());

    public UpstairsLights(IHaContext ha, ILogger<UpstairsLights> logger, ILightingStates lightingStates, IScheduler scheduler)
    {
        _scheduler = scheduler;
        _logger = logger;
        _entities = new Entities(ha);
        _lightingStates = lightingStates;

        LandingLightOnMovement();
        LandingLightOffNoMovement();
        //BathroomLightsOnMovement();
        //BathroomLightsOffNoMovement();
        BedroomLightsOnMovement();
        BedroomLightsOffNoMovement();
        // GuestRoomLightOnMovement();
        // GuestRoomLightOffNoMovement();
        //StudioLightOnMovement();
        //StudioLightOffNoMovement();
        DressingRoomLightOnMovement();
        DressingRoomLightOffNoMovement();
    }

#region Landing
    private void LandingLightOnMovement()
    {
        _entities.BinarySensor.LandingMotion.StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Landing motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.LandingLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.LandingLight.IsOff()
            && _lightingStates.InMotionMode(true)
            && ((_entities.InputSelect.BedroomMode.IsOption(BedroomModeOptions.Sleeping)
            && (_entities.BinarySensor.AndyInBed.IsOff() && _entities.Person.Andy.IsHome())
            || (_entities.BinarySensor.ClaireInBed.IsOff() && _entities.Person.Claire.IsHome()))
            || _entities.InputSelect.BedroomMode.IsNotOption(BedroomModeOptions.Sleeping));
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Landing Light on");
            _entities.Light.LandingLight.TurnOn();
        });
    }

    private void LandingLightOffNoMovement()
    {
        _entities.BinarySensor.LandingMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.LandingLight.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Landing Light off");
            _entities.Light.LandingLight.TurnOff();
        });
    }
#endregion

#region Bathroom
    private void BathroomLightsOnMovement()
    {
        _entities.BinarySensor.BathroomMotion.StateChanges()
        .Merge(_entities.BinarySensor.BathroomDoor.StateChanges())
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Bathroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.LandingLight.State},
                Mirror: {_entities.Light.MirrorLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && e.New.IsOn()
            && _entities.Light.BathroomLights.IsOff()
            && _lightingStates.InMotionMode(true)
            && OutOfBed;
        })
        .Subscribe(e =>
        {
            var bathroomMode = _entities.InputSelect.BathroomMode.AsOption<BathroomModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Bathroom Mode: {bathroomMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Bathroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Mirror Light: {_entities.Light.MirrorLight.State},
                Bathroom Light: {_entities.Light.BathroomLight.State}");

            

            if (Constants.NormalMotionModes.Contains(lightMode)
                && BathroomModeOptions.Relaxing != bathroomMode
                && !_entities.Light.BathroomLight.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Bathroom Light On.");
                _entities.Light.BathroomLight.TurnOn();
            }
            if ((LightControlModeOptions.Relaxing == lightMode
                || LightControlModeOptions.Sleeping == lightMode)
                && !_entities.Light.MirrorLight.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Mirror Lght On.");
                _entities.Light.MirrorLight.TurnOn();
            }
        });
    }

    private void CheckBathroomWaspInBox()
    {
        _bathroomOccupancyDisposable?.Dispose(); // Dispose previous subscription, if any

        var motionSensor = _entities.BinarySensor.BathroomMotion.State;
        var doorSensor = _entities.BinarySensor.BathroomDoor.State;

        if (_entities.BinarySensor.BathroomDoor.IsOpen() || _entities.BinarySensor.BathroomMotion.IsDetected())
        {
            _bathroomOccupancyDisposable = _entities.BinarySensor.BathroomDoor.StateAllChangesWithCurrent()
                .Buffer(TimeSpan.FromMinutes(2))
                .Where(buffer => buffer.Any(s => s.New.IsCleared()))
                .Subscribe(_ =>
                {
                    if (!_bathroomWaspInABox)
                    {
                        _logger.LogDebug("No door movement within 2 minutes, turning Bathroom Light on.");
                        _entities.Light.BathroomLight.TurnOn();

                        // Turn off light after 2 minutes of no door movement or being opened
                        _scheduler.Schedule(TimeSpan.FromMinutes(2), () =>
                        {
                            _entities.Light.BathroomLight.TurnOff();
                        });
                    }
                });

            _bathroomWaspInABox = false; // Reset wasp in box flag
        }
        else if (_entities.BinarySensor.BathroomDoor.IsClosed())
        {
            _bathroomOccupancyDisposable?.Dispose(); // Cancel previous wasp-in-box logic

            _bathroomOccupancyDisposable = _entities.BinarySensor.BathroomMotion.StateAllChangesWithCurrent()
                .Buffer(TimeSpan.FromMinutes(2))
                .Where(buffer => buffer.All(s => s.New.IsCleared()))
                .Subscribe(_ =>
                {
                    _logger.LogDebug("No motion after door closed, turning Bathroom Light off");
                    _entities.Light.BathroomLight.TurnOff();
                });

            _bathroomWaspInABox = true; // Set flag for potential wasp in the box
        }
    }

    private void BathroomWaspInABox()
    {
        _bathroomOccupancyDisposable?.Dispose();
        _bathroomOccupancyDisposable = _entities.BinarySensor.BathroomMotion.StateAllChangesWithCurrent()
            .Buffer(TimeSpan.FromMinutes(2))
            .Where(buffer => buffer.All(s => s.Entity.EntityId == "binary_sensor.bathroom_motion" 
                && s.New.IsCleared())
                && _entities.BinarySensor.BathroomDoor.IsOpen()
                && _entities.Light.BathroomLight.IsOn())
            .Subscribe(_ =>
            {
                _logger.LogDebug("Wasp in a box scenario detected, keeping Bathroom Light on.");
                _entities.Light.BathroomLight.TurnOn();
            });
    }

    private void BathroomLightsOffNoMovement()
    {
        _entities.BinarySensor.BathroomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.BathroomLights.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(e =>
        {
            _logger.LogTrace(@$"
                Brightness: {_entities.InputSelect.Brightness.State},
                Bathroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Mirror Light: {_entities.Light.MirrorLight.State},
                Bathroom Light: {_entities.Light.BathroomLight.State}");

            if (!_entities.Light.BathroomLight.IsOff())
            {
                _logger.LogDebug("No motion, turning Batroom Light Off");
                _entities.Light.BathroomLight.TurnOff();
            }
            if (!_entities.Light.MirrorLight.IsOff())
            {
                _logger.LogDebug("No motion, turning Mirror Light Off");
                _entities.Light.MirrorLight.TurnOff();
            }
        });
    }
#endregion

#region Bedroom
    private void BedroomLightsOnMovement()
    {
        _entities.BinarySensor.BedroomMotion.StateChanges()
        .Where(e =>
        {
            return !e.Old.IsOn()
            && e.New.IsOn()
            && _lightingStates.InMotionMode()
            && _entities.InputSelect.BedroomMode.IsNotOption(BedroomModeOptions.Sleeping)
            && _entities.Light.BedroomLights.IsOff();
        })
        .Subscribe(e =>
        {
            var bedroomMode = _entities.InputSelect.BedroomMode.AsOption<BedroomModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Bedroom Mode: {bedroomMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Bedroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Bedside Lamp: {_entities.Light.BedroomLamp.State},
                Bedroom Light: {_entities.Light.BedroomLight.State}");

            if (Constants.NormalMotionModes.Contains(lightMode)
                && BedroomModeOptions.Normal == bedroomMode
                && !_entities.Light.BedroomLight.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Bedroom Light On.");
                _entities.Light.BedroomLight.TurnOn();
            }
            if ((LightControlModeOptions.Relaxing == lightMode
                || LightControlModeOptions.Sleeping == lightMode)
                && !_entities.Light.BedroomLamp.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Bedside Lamp On.");
                _entities.Light.BedroomLamp.TurnOn();
            }
        });
    }

    private void BedroomLightsOffNoMovement()
    {
        _entities.BinarySensor.BedroomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.BedroomLights.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(e =>
        {
            var bedroomMode = _entities.InputSelect.BedroomMode.AsOption<BedroomModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Bedroom Mode: {bedroomMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Bedroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Bedside Lamp: {_entities.Light.BedroomLamp.State},
                Bedroom Light: {_entities.Light.BedroomLight.State}");

            if (lightMode != LightControlModeOptions.Manual)
            {
                if (bedroomMode != BedroomModeOptions.Bright
                    && !_entities.Light.BedroomLight.IsOff())
                {
                    _logger.LogDebug("No motion, turning Bedroom Light Off");
                    _entities.Light.BedroomLight.TurnOff();
                }
                if (bedroomMode != BedroomModeOptions.Relaxing
                    && !_entities.Light.BedroomLamp.IsOff())
                {
                    _logger.LogDebug("No motion, turning Bedside Lamp Off");
                    _entities.Light.BedroomLamp.TurnOff();
                }
            }
        });
    }
#endregion

#region Guest Room
    private void GuestRoomLightOnMovement()
    {
        _entities.BinarySensor.GuestRoomMotion.StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Guest Room motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.GuestRoomLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.GuestRoomLight.IsOff()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Guest Room Light on");
            _entities.Light.GuestRoomLight.TurnOn();
        });
    }

    private void GuestRoomLightOffNoMovement()
    {
        _entities.BinarySensor.GuestRoomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.GuestRoomLight.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Guest Room Light off");
            _entities.Light.GuestRoomLight.TurnOff();
        });
    }
#endregion

#region Studio
    private void StudioLightOnMovement()
    {
        _entities.BinarySensor.StudioMotion.StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Studio motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.StudioLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.StudioLight.IsOff()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Studio Light on");
            _entities.Light.StudioLight.TurnOn();
        });
    }

    private void StudioLightOffNoMovement()
    {
        _entities.BinarySensor.StudioMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.StudioLight.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Studio Light off");
            _entities.Light.StudioLight.TurnOff();
        });
    }
#endregion

#region Dressing Room
    private void DressingRoomLightOnMovement()
    {
        _entities.BinarySensor.DressingRoomMotion.StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Dressing Room motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.DressingRoomLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.DressingRoomLight.IsOff()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Dressing Room Light on");
            _entities.Light.DressingRoomLight.TurnOn();
        });
    }

    private void DressingRoomLightOffNoMovement()
    {
        _entities.BinarySensor.DressingRoomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.DressingRoomLight.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Dressing Room Light off");
            _entities.Light.DressingRoomLight.TurnOff();
        });
    }
#endregion
}