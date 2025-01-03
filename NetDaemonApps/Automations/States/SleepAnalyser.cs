namespace Upstairs.Bedroom;

//[NetDaemonApp]
public class SleepAnalyser
{
    private readonly ILogger<SleepAnalyser> _logger;
    private readonly Entities _entities;

    public SleepAnalyser(IHaContext ha, ILogger<SleepAnalyser> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        // TODO: Handle only one getting in or out of bed i.e. one is away
        // Possibly check if other sensor has been in off state > 30 mins
        // OR better still one is away
        ClaireThenAndyInBed();
        AndyThenClaireInBed();
        ClaireThenAndyOutOfBed();
        AndyThenClaireOutOfBed();
    }

    private void ClaireThenAndyInBed()
    {
        _entities.BinarySensor.AndyInBed
            .StateAllChangesWithCurrent()
            .Where(e =>
            {
                _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                    Andy In Bed: {_entities.BinarySensor.AndyInBed.State},
                    Light: {_entities.Light.BedroomLight.State},
                    Time: {TimeOnly.FromDateTime(DateTime.Now)} >= {Constants.NIGHT_START}");
                return e.New.IsOn()
                && (_entities.BinarySensor.ClaireInBed.IsOn()
                || !_entities.Person.Claire.IsHome())
                && (TimeOnly.FromDateTime(DateTime.Now) >= Constants.NIGHT_START
                || TimeOnly.FromDateTime(DateTime.Now) <= Constants.NIGHT_END);
            })
            .Throttle(TimeSpan.FromMinutes(15))
            .Subscribe(_ =>
            {
                _logger.LogDebug("Andy in bed, setting mode to Night");
                _entities.InputSelect.LightControlMode.SelectOption(LightControlModeOptions.Sleeping);
                _entities.InputSelect.BedroomMode.SelectOption(RoomModeOptions.Sleeping);
                _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Night);
            });
    }

    private void AndyThenClaireInBed()
    {
        _entities.BinarySensor.ClaireInBed
            .StateAllChangesWithCurrent()
            .Where(e =>
            {
                _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State},
                    Claire In Bed: {_entities.BinarySensor.ClaireInBed.State},
                    Light: {_entities.Light.BedroomLight.State},
                    Time: {TimeOnly.FromDateTime(DateTime.Now)} >= {Constants.NIGHT_START}");
                return e.New.IsOn()
                && (_entities.BinarySensor.AndyInBed.IsOn()
                || !_entities.Person.Andy.IsHome())
                && (TimeOnly.FromDateTime(DateTime.Now) >= Constants.NIGHT_START
                || TimeOnly.FromDateTime(DateTime.Now) <= Constants.NIGHT_END);
            })
            .Throttle(TimeSpan.FromMinutes(15))
            .Subscribe(_ =>
            {
                _logger.LogDebug("Claire in bed, setting mode to Night");
                _entities.InputSelect.LightControlMode.SelectOption(LightControlModeOptions.Sleeping);
                _entities.InputSelect.BedroomMode.SelectOption(RoomModeOptions.Sleeping);
                _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Night);
            });
    }

    private void ClaireThenAndyOutOfBed()
    {
        _entities.BinarySensor.AndyInBed
            .StateAllChangesWithCurrent()
            .Where(e =>
            {
                return !e.New.IsOn()
                && (!_entities.BinarySensor.ClaireInBed.IsOn()
                || !_entities.Person.Andy.IsHome())
                && TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.MORNING_START, Constants.MORNING_END);
            })
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                _logger.LogDebug("Andy out of bed, setting mode to Day");
                _entities.InputSelect.LightControlMode.SelectOption(LightControlModeOptions.Motion);
                _entities.InputSelect.BedroomMode.SelectOption(RoomModeOptions.Normal);
                _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Day);
            });
    }

    private void AndyThenClaireOutOfBed()
    {
        _entities.BinarySensor.ClaireInBed
            .StateAllChangesWithCurrent()
            .Where(e =>
            {
                return !e.New.IsOn()
                && (!_entities.BinarySensor.AndyInBed.IsOn()
                || !_entities.Person.Andy.IsHome())
                && TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.MORNING_START, Constants.MORNING_END);
            })
            .Throttle(TimeSpan.FromMinutes(5))
            .Subscribe(_ =>
            {
                _logger.LogDebug("Claire out of bed, setting mode to Day");
                _entities.InputSelect.LightControlMode.SelectOption(LightControlModeOptions.Motion);
                _entities.InputSelect.BedroomMode.SelectOption(RoomModeOptions.Normal);
                _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Day);
            });
    }
}