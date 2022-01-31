namespace Basement.Toilet;

[NetDaemonApp]
public class ToiletLight
{
    private readonly ILogger<ToiletLight> _logger;
    private readonly Entities _entities;

    public ToiletLight(IHaContext ha, ILogger<ToiletLight> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        ToiletLightOnMovement();
        ToiletLightOffNoMovement();
    }

    private void ToiletLightOnMovement()
    {
        _entities.BinarySensor.ToiletMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Toilet motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.Toilet.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOff()
                && e.New.IsOn()
                && _entities.Light.Toilet.IsOff();
            })
            .Subscribe(_ => _entities.Light.Toilet.TurnOn());
    }

    private void ToiletLightOffNoMovement()
    {
        _entities.BinarySensor.ToiletMotion
            .StateChanges()
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Toilet motion: Old: {e.Old?.State} - New: {e.New?.State},
                    Light: {_entities.Light.Toilet.State}");
                return _entities.InputSelect.LightControlMode.State == "Motion"
                && e.Old.IsOn()
                && e.New.IsOff()
                && _entities.Light.Toilet.IsOn();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => _entities.Light.Toilet.TurnOff());
    }
}