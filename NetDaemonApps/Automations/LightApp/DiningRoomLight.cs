namespace Basement;

[NetDaemonApp]
public class DiningRoomLight
{
    private readonly IScheduler _scheduler;
    private readonly ILogger<DiningRoomLight> _logger;
    private readonly Entities _entities;

    public DiningRoomLight(IHaContext ha, ILogger<DiningRoomLight> logger, IScheduler scheduler)
    {
        _scheduler = scheduler;
        _logger = logger;
        _entities = new Entities(ha);
        //DiningRoomLightOnMovement();
        //DiningRoomLightOffNoMovement();
    }

    private void DiningRoomLightOnMovement()
    {
        _entities.BinarySensor.DiningRoomMotion.StateAllChanges()
        //.Merge(_entities.Light.DiningRoom.StateAllChanges())

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
            TimeSpan.FromMinutes(2), _scheduler)
        .Subscribe(_ =>
        {
            _logger.LogDebug("No motion, turning Dining Room Light off");
            _entities.Light.DiningRoom.TurnOff();
        });
    }
}