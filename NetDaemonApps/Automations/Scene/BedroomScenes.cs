using NetDaemonApps.Infrastructure.State;

namespace Scene;

[NetDaemonApp]
public class BedroomScenes
{
    private readonly ILogger<BedroomScenes> _logger;
    private readonly Entities _entities;
    private readonly IScheduler _scheduler;
    private readonly ILightingStates _lightingStates;
    
    public BedroomScenes(IHaContext ha, ILogger<BedroomScenes> logger,
        IScheduler scheduler, ILightingStates lightingStates)
    {
        _logger = logger;
        _entities = new Entities(ha);
        _scheduler = scheduler;
        _lightingStates = lightingStates;
    }

    private void GetReadyForBed()
    {
        _entities.InputSelect.BedroomMode.SetOptions(BedroomModeOptions.Relaxing);
        _entities.Light.BedsideLamp.TurnOn();
        _entities.Light.Bedroom.TurnOff();
    }

    private void Sleeping()
    {
        _entities.InputSelect.BedroomMode.SetOptions(BedroomModeOptions.Sleeping);
        _entities.Light.AllLights.TurnOff();
    }

    public void Waking()
    {
        _entities.InputSelect.BedroomMode.SetOptions(BedroomModeOptions.Relaxing);
        _entities.Light.BedsideLamp.TurnOn();
    }

    public void GetUp()
    {
        _entities.InputSelect.BedroomMode.SetOptions(BedroomModeOptions.Normal);
        _entities.Light.BedsideLamp.TurnOn();
    }

    public void Awake()
    {
        _entities.InputSelect.BedroomMode.SetOptions(BedroomModeOptions.Normal);
        _entities.Light.BedsideLamp.TurnOff();
        _entities.Light.Bedroom.TurnOff();
    }
}