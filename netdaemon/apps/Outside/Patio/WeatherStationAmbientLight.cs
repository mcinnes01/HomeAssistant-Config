namespace Outside.Patio;

[NetDaemonApp]
public class WeatherStationAmbientLight
{
    private readonly ILogger<WeatherStationAmbientLight> _logger;
    private readonly Entities _entities;

    public WeatherStationAmbientLight(IHaContext ha, ILogger<WeatherStationAmbientLight> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        LowAmbientLight();
        HighAmbientLight();
    }

    private void LowAmbientLight()
    {
        double darkThreshold = 30.0;
        _entities.Sensor.WeatherStationAmbientLight
            .AsNumeric()
            .StateChanges()
            // Check the new event is below the dark threshold and that the previous state was above this threshold
            .Select(e => e.New?.State < darkThreshold && e.Old?.State >= darkThreshold)
            .Where(e => _entities.InputSelect.LightControlMode.State == "Day")
            .Throttle(TimeSpan.FromMinutes(3))
            .Subscribe(_ => 
            {
                _logger.LogDebug("Transitioning light control mode from: Day to: Motion");
                _entities.InputSelect.LightControlMode.SelectOption("Motion");
            });
    }

    private void HighAmbientLight()
    {
        double darkThreshold = 30.0;     
        _entities.Sensor.WeatherStationAmbientLight
            .AsNumeric()
            .StateChanges()
            // Check the new event is above the dark threshold and that the previous state was below this threshold
            .Select(e => e.New?.State >= darkThreshold && e.Old?.State < darkThreshold)
            .Where(e => _entities.InputSelect.LightControlMode.State == "Motion")
            .Throttle(TimeSpan.FromMinutes(3))
            .Subscribe(_ => 
            {
                _logger.LogDebug("Transitioning light control mode from: Motion to: Day");
                _entities.InputSelect.LightControlMode.SelectOption("Day");
            });
    }
}