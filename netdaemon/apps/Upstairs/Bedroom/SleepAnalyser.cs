namespace Upstairs.Bedroom;

[NetDaemonApp]
public class SleepAnalyser
{
    private readonly ILogger<SleepAnalyser> _logger;
    private readonly Entities _entities;

    public SleepAnalyser(IHaContext ha, ILogger<SleepAnalyser> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        ClaireThenAndyInBed();
        AndyThenClaireInBed();
        ClaireThenAndyOutOfBed();
        AndyThenClaireOutOfBed();
        OutOfBed();
    }

    private void ClaireThenAndyInBed()
    {
        _entities.BinarySensor.WithingsInBedAndy
            .StateChanges()
            .Select(e => e.New.IsOn() && e.Old.IsOff())
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Andy In Bed: {_entities.BinarySensor.WithingsInBedAndy.State},
                    Light: {_entities.Light.Bedroom.State},
                    Time: {DateTime.Now} >= {DateTime.Today.AddHours(20)}");
                return _entities.BinarySensor.WithingsInBedClaire.IsOn()
                && (DateTime.Now >= DateTime.Today.AddHours(20) || DateTime.Now < DateTime.Today.AddHours(4));
            })
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => 
            {
                _logger.LogDebug("Andy in bed, setting mode to Night");
                _entities.InputSelect.LightControlMode.SelectOption("Night");
            });
    }

    private void AndyThenClaireInBed()
    {
        _entities.BinarySensor.WithingsInBedClaire
            .StateChanges()
            .Select(e => e.New.IsOn() && e.Old.IsOff())
            .Where(e => 
            {
                _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
                    Claire In Bed: {_entities.BinarySensor.WithingsInBedClaire.State},
                    Light: {_entities.Light.Bedroom.State},
                    Time: {DateTime.Now}");
                return _entities.BinarySensor.WithingsInBedClaire.IsOn()
                && (DateTime.Now >= DateTime.Today.AddHours(20) || DateTime.Now < DateTime.Today.AddHours(4));
            })
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => 
            {
                _logger.LogDebug("Andy in bed, setting mode to Night");
                _entities.InputSelect.LightControlMode.SelectOption("Night");
            });
    }

    private void ClaireThenAndyOutOfBed()
    {
        _entities.BinarySensor.WithingsInBedAndy
            .StateChanges()
            .Select(e => e.New.IsOff() && e.Old.IsOn())
            .Where(e => DateTime.Now >= DateTime.Today.AddHours(9) && DateTime.Now >= DateTime.Today.AddHours(6))
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ => 
            {
                _logger.LogDebug("Andy out of bed, setting mode to Day");
                _entities.InputSelect.LightControlMode.SelectOption("Day");
            });
    }

    private void AndyThenClaireOutOfBed()
    {
        _entities.BinarySensor.WithingsInBedClaire
            .StateChanges()
            .Select(e => e.New.IsOff() && e.Old.IsOn())
            .Where(e => DateTime.Now <= DateTime.Today.AddHours(9) && DateTime.Now >= DateTime.Today.AddHours(6))
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                _logger.LogDebug("Claire out of bed, setting mode to Day");
                _entities.InputSelect.LightControlMode.SelectOption("Day");
            });
    }

    private void OutOfBed()
    {
        if ((_entities.BinarySensor.WithingsInBedAndy.IsOn() 
            || _entities.BinarySensor.WithingsInBedClaire.IsOn())
            && DateTime.Now > DateTime.Today.AddHours(9)
            && _entities.InputSelect.LightControlMode.State == "Night")
            {
                _entities.InputSelect.LightControlMode.SelectOption("Day");
            }
    }
}