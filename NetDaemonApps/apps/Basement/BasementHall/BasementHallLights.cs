namespace Basement.BasementHall;

[NetDaemonApp]
public class BasementHallLights
{
    private readonly ILogger<BasementHallLights> _logger;
    private readonly Entities _entities;

    public BasementHallLights(IHaContext ha, ILogger<BasementHallLights> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        BasementHallLightOnMovement();
        BasementHallLightOffNoMovement();
    }

    private void BasementHallLightOnMovement()
    {
        _entities.BinarySensor.BasementHallMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    BasementHall motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.BasementHall.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.BasementHall.IsOff();
            })
            .Subscribe(_ => _entities.Light.BasementHall.TurnOn());
    }

    private void BasementHallLightOffNoMovement()
    {
        _entities.BinarySensor.BasementHallMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    BasementHall motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.BasementHall.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.BasementHall.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.BasementHall.TurnOff());
    }
}