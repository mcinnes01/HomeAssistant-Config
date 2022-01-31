namespace Basement.DiningRoom;

[NetDaemonApp]
public class DiningRoomLights
{
    private readonly ILogger<DiningRoomLights> _logger;
    private readonly Entities _entities;

    public DiningRoomLights(IHaContext ha, ILogger<DiningRoomLights> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        DiningRoomLightOnMovement();
        DiningRoomLightOffNoMovement();
    }

    private void DiningRoomLightOnMovement()
    {
        _entities.BinarySensor.DiningRoomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    DiningRoom motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.DiningRoom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.DiningRoom.IsOff();
            })
            .Subscribe(_ => _entities.Light.DiningRoom.TurnOn());
    }

    private void DiningRoomLightOffNoMovement()
    {
        _entities.BinarySensor.DiningRoomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    DiningRoom motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.DiningRoom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.DiningRoom.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.DiningRoom.TurnOff());
    }
}