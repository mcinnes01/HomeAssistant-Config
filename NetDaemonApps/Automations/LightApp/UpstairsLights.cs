using NetDaemonApps.Infrastructure.State;

namespace Upstairs;

[NetDaemonApp]
public class UpstairsLights
{
    private readonly ILogger<UpstairsLights> _logger;
    private readonly Entities _entities;
    private readonly ILightingStates _lightingStates;

    public UpstairsLights(IHaContext ha, ILogger<UpstairsLights> logger, ILightingStates lightingStates)
    {
        _logger = logger;
        _entities = new Entities(ha);
        _lightingStates = lightingStates;

        LandingLightOnMovement();
        LandingLightOffNoMovement();
        BathroomLightsOnMovement();
        BathroomLightsOffNoMovement();
        BedroomLightsOnMovement();
        BedroomLightsOffNoMovement();
        GuestRoomLightOnMovement();
        GuestRoomLightOffNoMovement();
        StudioLightOnMovement();
        StudioLightOffNoMovement();
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
                Light: {_entities.Light.Landing.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.Landing.IsOff()
            && _lightingStates.InMotionMode(true)
            && ((_entities.InputSelect.BedroomMode.IsOption(BedroomModeOptions.Sleeping)
            && (_entities.BinarySensor.WithingsInBedAndy.IsOff() && _entities.Person.Andy.IsHome())
            || (_entities.BinarySensor.WithingsInBedClaire.IsOff() && _entities.Person.Claire.IsHome()))
            || _entities.InputSelect.BedroomMode.IsNotOption(BedroomModeOptions.Sleeping));
        })
        .Subscribe(_ => 
        {
            _logger.LogDebug("Motion detected, turning Landing Light on");
            _entities.Light.Landing.TurnOn();
        });
    }

    private void LandingLightOffNoMovement()
    {
        _entities.BinarySensor.LandingMotion.StateAllChangesWithCurrent()  
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.Landing.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2)
        )
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Landing Light off");
            _entities.Light.Landing.TurnOff();
        });
    }
#endregion

#region Bathroom
    private void BathroomLightsOnMovement()
    {
        _entities.BinarySensor.BathroomMotion.StateChanges()      
        .Where(e => 
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                Bathroom motion: Old: {e.Old?.State} - New: {e.New?.State}, 
                Light: {_entities.Light.Landing.State}, 
                Mirror: {_entities.Light.Mirror.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.BathroomLights.IsOff()
            && _lightingStates.InMotionMode(true)
            && ((_entities.InputSelect.BedroomMode.IsOption(BedroomModeOptions.Sleeping)
            && (_entities.BinarySensor.WithingsInBedAndy.IsOff() && _entities.Person.Andy.IsHome())
            || (_entities.BinarySensor.WithingsInBedClaire.IsOff() && _entities.Person.Claire.IsHome()))
            || _entities.InputSelect.BedroomMode.IsNotOption(BedroomModeOptions.Sleeping));
        })
        
        .Subscribe(e => 
        {
            var bathroomMode = _entities.InputSelect.BathroomMode.AsOption<BathroomModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Bathroom Mode: {bathroomMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Bathroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Mirror Light: {_entities.Light.Mirror.State},
                Bathroom Light: {_entities.Light.Bathroom.State}");

            if (Constants.NormalMotionModes.Contains(lightMode) 
                && BathroomModeOptions.Relaxing != bathroomMode
                && !_entities.Light.Bathroom.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Bathroom Light On.");
                _entities.Light.Bathroom.TurnOn();
            }
            if ((LightControlModeOptions.Relaxing == lightMode
                || LightControlModeOptions.Sleeping == lightMode)
                && !_entities.Light.Mirror.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Mirror Lght On.");
                _entities.Light.Mirror.TurnOn();
            }
        });
    }

    private void BathroomLightsOffNoMovement()
    {
        _entities.BinarySensor.BathroomMotion.StateAllChangesWithCurrent()  
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.BathroomLights.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2)
        )
        .Subscribe(e => 
        {
            _logger.LogTrace(@$"
                Brightness: {_entities.InputSelect.Brightness.State},
                Bathroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Mirror Light: {_entities.Light.Mirror.State}, 
                Bathroom Light: {_entities.Light.Bathroom.State}");

            if (!_entities.Light.Bathroom.IsOff())
            {
                _logger.LogDebug("No motion, turning Batroom Light Off");
                _entities.Light.Bathroom.TurnOff();
            }
            if (!_entities.Light.Mirror.IsOff())
            {
                _logger.LogDebug("No motion, turning Mirror Light Off");
                _entities.Light.Mirror.TurnOff();
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
                Bedside Lamp: {_entities.Light.BedsideLamp.State},
                Bedroom Light: {_entities.Light.Bedroom.State}");

            if (Constants.NormalMotionModes.Contains(lightMode) 
                && BedroomModeOptions.Normal == bedroomMode
                && !_entities.Light.Bedroom.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Bedroom Light On.");
                _entities.Light.Bedroom.TurnOn();
            }
            if ((LightControlModeOptions.Relaxing == lightMode
                || LightControlModeOptions.Sleeping == lightMode)
                && !_entities.Light.BedsideLamp.IsOn())
            {
                _logger.LogDebug("Motion detected, turning Bedside Lamp On.");
                _entities.Light.BedsideLamp.TurnOn();
            }
        });
    }

    private void BedroomLightsOffNoMovement()
    {
        _entities.BinarySensor.BedroomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.BedroomLights.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2)
        )
        .Subscribe(e => 
        {
            var bedroomMode = _entities.InputSelect.BedroomMode.AsOption<BedroomModeOptions>();
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Bedroom Mode: {bedroomMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Bedroom motion: Old: {e.Old?.State} - New: {e.New?.State},
                Bedside Lamp: {_entities.Light.BedsideLamp.State}, 
                Bedroom Light: {_entities.Light.Bedroom.State}");

            if (lightMode != LightControlModeOptions.Manual)
            {
                if (bedroomMode != BedroomModeOptions.Bright
                    && !_entities.Light.Bedroom.IsOff())
                {
                    _logger.LogDebug("No motion, turning Bedroom Light Off");
                    _entities.Light.Bedroom.TurnOff();
                }
                if (bedroomMode != BedroomModeOptions.Relaxing
                    && !_entities.Light.BedsideLamp.IsOff())
                {
                    _logger.LogDebug("No motion, turning Bedside Lamp Off");
                    _entities.Light.BedsideLamp.TurnOff();
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
                Light: {_entities.Light.GuestRoom.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.GuestRoom.IsOff()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(_ => 
        {
            _logger.LogDebug("Motion detected, turning Guest Room Light on");
            _entities.Light.GuestRoom.TurnOn();
        });
    }

    private void GuestRoomLightOffNoMovement()
    {
        _entities.BinarySensor.GuestRoomMotion.StateAllChangesWithCurrent()  
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.GuestRoom.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2)
        )
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Guest Room Light off");
            _entities.Light.GuestRoom.TurnOff();
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
                Light: {_entities.Light.Studio.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.Studio.IsOff()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(_ => 
        {
            _logger.LogDebug("Motion detected, turning Studio Light on");
            _entities.Light.Studio.TurnOn();
        });
    }

    private void StudioLightOffNoMovement()
    {
        _entities.BinarySensor.StudioMotion.StateAllChangesWithCurrent()  
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.Studio.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2)
        )
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Studio Light off");
            _entities.Light.Studio.TurnOff();
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
                Light: {_entities.Light.DressingRoom.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.DressingRoom.IsOff()
            && _lightingStates.InMotionMode();
        })
        .Subscribe(_ => 
        {
            _logger.LogDebug("Motion detected, turning Dressing Room Light on");
            _entities.Light.DressingRoom.TurnOn();
        });
    }

    private void DressingRoomLightOffNoMovement()
    {
        _entities.BinarySensor.DressingRoomMotion.StateAllChangesWithCurrent()  
        .WhenStateIsFor(s => s.IsOff()
            && _entities.Light.DressingRoom.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2)
        )
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Dressing Room Light off");
            _entities.Light.DressingRoom.TurnOff();
        });
    }
#endregion
}