namespace Upstairs.Bedroom;

[NetDaemonApp]
public class BedroomLights
{
    private readonly ILogger<BedroomLights> _logger;
    private readonly Entities _entities;

    public BedroomLights(IHaContext ha, ILogger<BedroomLights> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        BedroomLightOnMovement();
        BedsideLampOnMovement();
        BedroomLightOffNoMovement();
        BedsideLampOffNoMovement();
    }

    private void BedroomLightOnMovement()
    {
        _entities.BinarySensor.BedroomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Bedroom Mode: {_entities.InputSelect.BedroomMode.State}, 
                    Bedroom Motion: Old: {e.Old?.State} - New: {e.New?.State}, 
                    Bedside Lamp: {_entities.Light.BedsideLamp.State}, 
                    Light: {_entities.Light.Bedroom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && _entities.InputSelect.BedroomMode.State == "Normal"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.Bedroom.IsOff()
                && _entities.Light.BedsideLamp.IsOff();
            })
            .Subscribe(_ => _entities.Light.Bedroom.TurnOn());
    }

    private void BedsideLampOnMovement()
    {
        _entities.BinarySensor.BedroomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Bedroom Mode: {_entities.InputSelect.BedroomMode.State}, 
                    Bedroom Motion: Old: {e.Old?.State} - New: {e.New?.State}, 
                    Bedside Lamp: {_entities.Light.BedsideLamp.State}, 
                    Light: {_entities.Light.Bedroom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && _entities.InputSelect.BedroomMode.State == "Relaxing"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.Bedroom.IsOff()
                && _entities.Light.BedsideLamp.IsOff();
            })
            .Subscribe(_ => _entities.Light.Bedroom.TurnOn());
    }

    private void BedroomLightOffNoMovement()
    {
        _entities.BinarySensor.BedroomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Bedroom Mode: {_entities.InputSelect.BedroomMode.State}, 
                    Bedroom Motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.Bedroom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && _entities.InputSelect.BedroomMode.State == "Normal"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.Bedroom.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => 
            {
                
                _entities.Light.Bedroom.TurnOff();
            });
    }

    private void BedsideLampOffNoMovement()
    {
        _entities.BinarySensor.BedroomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Bedroom Mode: {_entities.InputSelect.BedroomMode.State}, 
                    Bedroom Motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Bedside Lamp: {_entities.Light.Bedroom.State}");
                return InRelaxingOccupancyControlState()
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.BedsideLamp.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.BedsideLamp.TurnOff());
    }

    private bool InNormalOccupancyControlState()
    {
        return _entities.InputSelect.LightControlMode.State == "Motion"
            && _entities.InputSelect.BedroomMode.State == "Normal";
            // Either set light control mode to away if no one is home or manually handle occupancy of house.
    }

    private bool InRelaxingOccupancyControlState()
    {
        // Todo for turnoff actions think about light was in state i.e. normal to relaxing would need the light off and lamp on
        // but night to relaxing would be different
        // Trade off between turning things off when a mode changes potentially turning lights off
        // vs handling the transition of states more intelligently
        return _entities.InputSelect.LightControlMode.State == "Motion"
            && _entities.InputSelect.BedroomMode.State == "Normal";
            // Either set light control mode to away if no one is home or manually handle occupancy of house.
    }
}