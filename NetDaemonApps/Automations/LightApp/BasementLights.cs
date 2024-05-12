namespace Basement;

[NetDaemonApp]
public class BasementLights
{
    private readonly IScheduler _scheduler;
    private readonly ILogger<BasementLights> _logger;
    private readonly Entities _entities;

    public BasementLights(IHaContext ha, ILogger<BasementLights> logger,
        IScheduler scheduler)
    {
        _logger = logger;
        _entities = new Entities(ha);
        _scheduler = scheduler;

        ElectricCabinetLightOnMovement();
        ElectricCabinetLightOffNoMovement();
        BasementHallLightOnMovement();
        BasementHallLightOffNoMovement();
        DiningRoomLightOnMovement();
        DiningRoomLightOffNoMovement();
        SnugLightsOnMovement();
        SnugLightsOffNoMovement();
        UtilityRoomLightOnMovement();
        UtilityRoomLightOffNoMovement();
        ToiletLightOnMovement();
        ToiletLightOffNoMovement();
    }

    private void ElectricCabinetLightOnMovement()
    {
        _entities.BinarySensor.ElectricCabinetDoorContact.StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Light: {_entities.Light.ElectricCabinetLight.State}");
            return e.New.IsOpen()
                && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual);
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Electric Cabinet door open, turning Electric Cabinet Light on");
            _entities.Light.ElectricCabinetLight.TurnOn();
        });
    }

    private void ElectricCabinetLightOffNoMovement()
    {
        _entities.BinarySensor.ElectricCabinetDoorContact.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsClosed()
            && _entities.Light.ElectricCabinetLight.IsOn()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromSeconds(30), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("Electric Cabinet Door closed, turning Basement Hall Light off");
            _entities.Light.ElectricCabinetLight.TurnOff();
        });
    }

    private void BasementHallLightOnMovement()
    {
        _entities.BinarySensor.BasementHallMotion.StateChanges()
        .Merge(_entities.BinarySensor.BasementHallCameraMotion.StateChanges())
        .Merge(_entities.BinarySensor.BasementStairsMotion.StateChanges())
        .Merge(_entities.BinarySensor.ElectricCabinetDoorContact.StateChanges())
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Basement Hall motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.BasementHallLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.BasementHallLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Basement Hall Light on");
            _entities.Light.BasementHallLight.TurnOn();
        });
    }

    private void BasementHallLightOffNoMovement()
    {
        _entities.BinarySensor.BasementHallMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.BasementHallCameraMotion.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.BasementStairsMotion.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.ElectricCabinetDoorContact.StateAllChangesWithCurrent())
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.BasementHallLight.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Basement Hall Light off");
            _entities.Light.BasementHallLight.TurnOff();
        });
    }

    private void DiningRoomLightOnMovement()
    {
        _entities.BinarySensor.DiningRoomMotion
        .StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Dining room motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.SnugLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.DiningRoomLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Dining Room Light on");
            _entities.Light.DiningRoomLight.TurnOn();
        });
    }

    private void DiningRoomLightOffNoMovement()
    {
        _entities.BinarySensor.DiningRoomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.DiningRoomLight.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Dining Room Light off");
            _entities.Light.DiningRoomLight.TurnOff();
        });
    }

    private void SnugLightsOnMovement()
    {
        _entities.BinarySensor.SnugMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.SnugOccupancy.StateAllChangesWithCurrent())
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Snug motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.SnugLight.State},
                Lamp: {_entities.Light.SnugLamp.State},
                Led Strip: {_entities.Light.SnugLedStrip.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && _entities.InputSelect.SnugMode.IsOption(SnugModeOptions.Normal)
            && (_entities.BinarySensor.SnugMotion.IsDetected() || _entities.BinarySensor.SnugOccupancy.IsDetected())
            && !_entities.Light.SnugLight.IsOn()
            && !_entities.Light.SnugLamp.IsOn()
            && !_entities.Light.SnugLedStrip.IsOn();
        })
        .Subscribe(e =>
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Snug Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Snug Light: {_entities.Light.KitchenLight.State},
                Snug Floor Lamp: {_entities.Light.BreakfastBarLamp.State},
                Snug Led Strip: {_entities.Light.SnugLedStrip.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Snug Light On.");
                _entities.Light.SnugLight.TurnOn();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Snug Floor Lamp and Led Strip On.");
                _entities.Light.SnugLamp.TurnOn();
                _entities.Light.SnugLedStrip.TurnOn();
            }
        });
    }

    private void SnugLightsOffNoMovement()
    {
        _entities.BinarySensor.SnugOccupancy.StateAllChangesWithCurrent()
        .WhenStateIsFor(s =>
        {
            _logger.LogTrace(@$"Snug Occupancy: {s?.State},
                Light: {_entities.Light.SnugLight.State},
                Lamp: {_entities.Light.SnugLamp.State},
                Led Strip: {_entities.Light.SnugLedStrip.State}");
            return s.IsOff()
            && _entities.BinarySensor.SnugOccupancy.IsNotDetected()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && _entities.InputSelect.SnugMode.IsOption(SnugModeOptions.Normal)
            && (!_entities.Light.SnugLight.IsOff()
             || !_entities.Light.SnugLamp.IsOff()
             || !_entities.Light.SnugLedStrip.IsOff());
        },
            TimeSpan.FromMinutes(1), _scheduler)
        .Subscribe(e =>
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Snug Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.SnugLight.State},
                Lamp: {_entities.Light.SnugLamp.State},
                Led Strip: {_entities.Light.SnugLedStrip.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Snug Light Off");
                _entities.Light.SnugLight.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Snug Floor Lamp and Led Strip Off");
                _entities.Light.SnugLamp.TurnOff();
                _entities.Light.SnugLedStrip.TurnOff();
            }
        });
    }

    private void UtilityRoomLightOnMovement()
    {
        _entities.BinarySensor.UtilityRoomMotion.StateChanges()
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Utility room motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.UtilityRoomLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.UtilityRoomLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Utility Room Light on");
            _entities.Light.UtilityRoomLight.TurnOn();
        });
    }

    private void UtilityRoomLightOffNoMovement()
    {
        _entities.BinarySensor.UtilityRoomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.UtilityRoomLight.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Utility Room Light off");
            _entities.Light.UtilityRoomLight.TurnOff();
        });
    }

    private void ToiletLightOnMovement()
    {
        _entities.BinarySensor.ToiletMotion.StateChanges()
        .Merge(_entities.BinarySensor.ToiletDoor.StateChanges())
        .Where(e =>
        {
            _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                Toilet motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.ToiletLight.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.ToiletLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Toilet Light on");
            _entities.Light.ToiletLight.TurnOn();
        });
    }

    private void ToiletLightOffNoMovement()
    {
        _entities.BinarySensor.ToiletMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff() &&
            !_entities.Light.ToiletLight.IsOff() &&
            _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Toilet Light off");
            _entities.Light.ToiletLight.TurnOff();
        });
    }
}