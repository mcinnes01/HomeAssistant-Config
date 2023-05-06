namespace Basement;

[NetDaemonApp]
public class BasementLights
{
    private readonly ILogger<BasementLights> _logger;
    private readonly Entities _entities;

    public BasementLights(IHaContext ha, ILogger<BasementLights> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        BasementHallLightOnMovement();
        BasementHallLightOffNoMovement();

        DiningRoomLightOnMovement();
        DiningRoomLightOffNoMovement();
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
        //.Merge(_entities.BinarySensor.ElectricCabinetDoorContact.StateChanges())      
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
        //.Merge(_entities.BinarySensor.ElectricCabinetDoorContact.StateAllChangesWithCurrent())    
        .WhenStateIsFor(s => s.IsOff()
            && !_entities.Light.BasementHall.IsOff()
            && _entities.InputSelect.LightControlMode.IsNotOption(LightControlModeOptions.Manual),
            TimeSpan.FromMinutes(2))
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
                Dining Room motion: Old: {e.Old?.State} - New: {e.New?.State}, 
                Light: {_entities.Light.DiningRoom.State}");
            return _entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Motion)
            && !(_entities.InputSelect.Brightness.IsOption(BrightnessOptions.Bright)
            && TimeOnly.FromDateTime(DateTime.Now) < Constants.BACK_IN_SHADOW)
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
            TimeSpan.FromMinutes(2))
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Dining Room Light off");
            _entities.Light.DiningRoom.TurnOff();
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
            return _entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Motion)
            && !(_entities.InputSelect.Brightness.IsOption(BrightnessOptions.Bright)
            && TimeOnly.FromDateTime(DateTime.Now) < Constants.BACK_IN_SHADOW)
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
            TimeSpan.FromMinutes(2))
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Utility Room Light off");
            _entities.Light.UtilityRoom.TurnOff();
        });
    }

    private void ToiletLightOnMovement()
    {
        _entities.BinarySensor.ToiletMotion.StateChanges()
        //.Merge(_entities.BinarySensor.ToiletDoor.StateChanges())
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
            TimeSpan.FromMinutes(2))
        .Subscribe(_ => 
        {
            _logger.LogDebug("No motion, turning Toilet Light off");
            _entities.Light.Toilet.TurnOff();
        });
    }
}