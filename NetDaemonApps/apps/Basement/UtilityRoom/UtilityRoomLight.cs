namespace Basement.UtilityRoom;

[NetDaemonApp]
public class UtilityRoomLight
{
    private readonly ILogger<UtilityRoomLight> _logger;
    private readonly Entities _entities;

    public UtilityRoomLight(IHaContext ha, ILogger<UtilityRoomLight> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        UtilityRoomLightOnMovement();
        UtilityRoomLightOffNoMovement();
    }

    private void UtilityRoomLightOnMovement()
    {
        _entities.BinarySensor.UtilityRoomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    UtilityRoom motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.UtilityRoom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.UtilityRoom.IsOff();
            })
            .Subscribe(_ => _entities.Light.UtilityRoom.TurnOn());
    }

    private void UtilityRoomLightOffNoMovement()
    {
        _entities.BinarySensor.UtilityRoomMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    UtilityRoom motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.UtilityRoom.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.UtilityRoom.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.UtilityRoom.TurnOff());
    }
}