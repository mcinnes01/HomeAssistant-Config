namespace Downstairs.Lounge;

[NetDaemonApp]
public class LoungeLights
{
    private readonly ILogger<LoungeLights> _logger;
    private readonly Entities _entities;

    public LoungeLights(IHaContext ha, ILogger<LoungeLights> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        LoungeLightOnMovement();
        LoungeFloorLampOnMovement();
        LoungeLightOffNoMovement();
        LoungeFloorLampOffNoMovement();
    }

    private void LoungeLightOnMovement()
    {
        _entities.BinarySensor.LoungeMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Lounge motion: Old: {e.Old?.State} - New: {e.New?.State}, 
                    Bedside Lamp: {_entities.Light.BedsideLamp.State}, 
                    Light: {_entities.Light.Lounge.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.BedsideLamp.IsOff()
                && _entities.Light.Lounge.IsOff();
            })
            .Subscribe(_ => _entities.Light.Lounge.TurnOn());
    }

    private void LoungeFloorLampOnMovement()
    {
        _entities.BinarySensor.LoungeMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Lounge motion: Old: {e.Old?.State} - New: {e.New?.State}, 
                    Bedside Lamp: {_entities.Light.LoungeFloorLamp.State}, 
                    Light: {_entities.Light.Lounge.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.LoungeFloorLamp.IsOff()
                && _entities.Light.Lounge.IsOff();
            })
            .Subscribe(_ => _entities.Light.LoungeFloorLamp.TurnOn());
    }

    private void LoungeLightOffNoMovement()
    {
        _entities.BinarySensor.LoungeMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.Lounge.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.Lounge.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.Lounge.TurnOff());
    }

    private void LoungeFloorLampOffNoMovement()
    {
        _entities.BinarySensor.LoungeMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Lounge motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Lounge Floor Lamp: {_entities.Light.Lounge.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.LoungeFloorLamp.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.LoungeFloorLamp.TurnOff());
    }
}