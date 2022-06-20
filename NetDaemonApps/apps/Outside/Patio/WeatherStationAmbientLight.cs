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

        SetBrightness();
    }
   
    private void SetBrightness()
    {
        _entities.Sensor.WeatherStationAmbientLight
        .StateAllChangesWithCurrent()
        .Where(e => MapBrightness(e.Old) != MapBrightness(e.New))
        .Throttle(TimeSpan.FromMinutes(3))
        .Select(e => (Lux: e.New?.State, Option: MapBrightness(e.New)))
        .Subscribe(e => 
        {
            _logger.LogDebug($"Transitioning  Brightness to: {e.Option} - Ambient Light {e.Lux}lx");
            _entities.InputSelect.Brightness.SelectOption(e.Option);
        });
    }

    private  BrightnessOptions MapBrightness(NumericEntityState<HomeAssistantGenerated.NumericSensorAttributes>? entityState) =>
    entityState?.State switch
    {
        <= Constants.DARK_THRESHOLD =>  BrightnessOptions.Dark,
        >= Constants.BRIGHT_THRESHOLD =>  BrightnessOptions.Bright,
        null =>  BrightnessOptions.Bright,
        _ =>  BrightnessOptions.Dim
    };
}