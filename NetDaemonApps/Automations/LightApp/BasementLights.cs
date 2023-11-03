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
                Light: {_entities.Light.BasementHall.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.BasementHall.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Basement Hall Light on");
            _entities.Light.BasementHall.TurnOn();
        });
    }

    private void BasementHallLightOffNoMovement()
    {
        _entities.BinarySensor.BasementHallMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.BasementHallCameraMotion.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.BasementStairsMotion.StateAllChangesWithCurrent())
        .Merge(_entities.BinarySensor.ElectricCabinetDoorContact.StateAllChangesWithCurrent())
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.BasementHall.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Basement Hall Light off");
            _entities.Light.BasementHall.TurnOff();
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
                Light: {_entities.Light.Snug.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.DiningRoom.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Dining Room Light on");
            _entities.Light.DiningRoom.TurnOn();
        });
    }

    private void DiningRoomLightOffNoMovement()
    {
        _entities.BinarySensor.DiningRoomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.DiningRoom.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Dining Room Light off");
            _entities.Light.DiningRoom.TurnOff();
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
                Light: {_entities.Light.Snug.State},
                Lamp: {_entities.Light.SnugFloorLamp.State},
                Led Strip: {_entities.Light.SnugLedStrip.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && _entities.InputSelect.SnugMode.IsOption(SnugModeOptions.Normal)
            && e.New.IsOn()
            && _entities.Light.Snug.IsOff()
            && _entities.Light.SnugFloorLamp.IsOff()
            && _entities.Light.SnugLedStrip.IsOff();
        })
        .Subscribe(e =>
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Snug Motion: Old: {e.Old?.State} - New: {e.New?.State},
                Snug Light: {_entities.Light.Kitchen.State},
                Snug Floor Lamp: {_entities.Light.BreakfastBarLamp.State},
                Snug Led Strip: {_entities.Light.SnugLedStrip.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Snug Light On.");
                _entities.Light.Snug.TurnOn();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("Motion detected, turning Snug Floor Lamp and Led Strip On.");
                _entities.Light.SnugFloorLamp.TurnOn();
                _entities.Light.SnugLedStrip.TurnOn();
            }
        });
    }

    private void SnugLightsOffNoMovement()
    {
        _entities.BinarySensor.SnugMotion.StateAllChangesWithCurrent()
        .Merge(_entities.BinarySensor.SnugOccupancy.StateAllChangesWithCurrent())
        .Where(e => {
            _logger.LogTrace(@$"Snug combined motion: Old: {e.Old?.State} - New: {e.New?.State},
                Snug Motion: {_entities.BinarySensor.SnugMotion.State},
                Snug Occupancy: {_entities.BinarySensor.SnugOccupancy.State},
                Light: {_entities.Light.Snug.State},
                Lamp: {_entities.Light.SnugFloorLamp.State},
                Led Strip: {_entities.Light.SnugLedStrip.State}");
            return _entities.BinarySensor.SnugMotion.IsOff()
                && _entities.BinarySensor.SnugOccupancy.IsOff();
        })
        .WhenStateIsFor(s => s.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && _entities.InputSelect.SnugMode.IsOption(SnugModeOptions.Normal)
            && (!_entities.Light.Snug.IsOff()
             || !_entities.Light.SnugFloorLamp.IsOff()
             || !_entities.Light.SnugLedStrip.IsOff()),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(e =>
        {
            var lightMode = _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>();
            _logger.LogTrace(@$"Light Mode: {lightMode},
                Brightness: {_entities.InputSelect.Brightness.State},
                Snug motion: Old: {e.Old?.State} - New: {e.New?.State},
                Light: {_entities.Light.Snug.State},
                Lamp: {_entities.Light.SnugFloorLamp.State},
                Led Strip: {_entities.Light.SnugLedStrip.State}");

            if (Constants.NormalMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Snug Light Off");
                _entities.Light.Snug.TurnOff();
            }
            else if (Constants.LampMotionModes.Contains(lightMode))
            {
                _logger.LogDebug("No motion, turning Snug Floor Lamp and Led Strip Off");
                _entities.Light.SnugFloorLamp.TurnOff();
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
                Light: {_entities.Light.UtilityRoom.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Sleeping)
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.UtilityRoom.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Utility Room Light on");
            _entities.Light.UtilityRoom.TurnOn();
        });
    }

    private void UtilityRoomLightOffNoMovement()
    {
        _entities.BinarySensor.UtilityRoomMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.UtilityRoom.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Utility Room Light off");
            _entities.Light.UtilityRoom.TurnOff();
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
                Light: {_entities.Light.Toilet.State}");
            return _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual)
            && !e.Old.IsOn()
            && e.New.IsOn()
            && _entities.Light.Toilet.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Motion detected, turning Toilet Light on");
            _entities.Light.Toilet.TurnOn();
        });
    }

    private void ToiletLightOffNoMovement()
    {
        _entities.BinarySensor.ToiletMotion.StateAllChangesWithCurrent()
        .WhenStateIsFor(s => s.IsOff() &&
            !_entities.Light.Toilet.IsOff() &&
            _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Toilet Light off");
            _entities.Light.Toilet.TurnOff();
        });
    }
}