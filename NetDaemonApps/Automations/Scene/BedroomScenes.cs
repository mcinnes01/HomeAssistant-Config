using NetDaemonApps.Infrastructure.State;

namespace Scene;

[NetDaemonApp]
public class BedroomScenes
{
    private readonly ILogger<BedroomScenes> _logger;
    private readonly Entities _entities;
    private readonly IScheduler _scheduler;
    private readonly ILightingStates _lightingStates;
    private readonly IAlexa _alexa;

    public BedroomScenes(IHaContext ha, ILogger<BedroomScenes> logger,
        IScheduler scheduler, ILightingStates lightingStates, IAlexa alexa)
    {
        _logger = logger;
        _entities = new Entities(ha);
        _scheduler = scheduler;
        _lightingStates = lightingStates;
        _alexa = alexa;

        _entities.Scene.GetReadyForBed.StateChanges()
            .Subscribe(_ => GetReadyForBed());
        _entities.Scene.Sleeping.StateChanges()
            .Subscribe(_ => Sleeping());
        _entities.Scene.Waking.StateChanges()
            .Subscribe(_ => Waking());
        _entities.Scene.GetUp.StateChanges()
            .Subscribe(_ => GetUp());
        _entities.Scene.Awake.StateChanges()
            .Subscribe(_ => Awake());
    }

    private void GetReadyForBed()
    {
        _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Relaxing);
        _entities.Light.BedsideLamp.TurnOn();
        _entities.Light.Bedroom.TurnOff();
    }

    private void Sleeping()
    {
        _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Sleeping);
        _entities.Light.AllLights.TurnOff();
        _alexa.TurnScreenOff(_entities.MediaPlayer.BedroomEchoShow.EntityId);
        _alexa.TurnScreenOff(_entities.MediaPlayer.GuestRoomEchoShow.EntityId);
        _alexa.TurnScreenOff(_entities.MediaPlayer.KitchenCameraSpeaker.EntityId);
        _alexa.TurnScreenOff(_entities.MediaPlayer.SnugEchoShow.EntityId);
    }

    public void Waking()
    {
        _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Relaxing);
        _entities.Light.BedsideLamp.TurnOn();
        _alexa.TurnScreenOn(_entities.MediaPlayer.BedroomEchoShow.EntityId);
    }

    public void GetUp()
    {
        _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Normal);
        _entities.Light.BedsideLamp.TurnOn();
        _alexa.TurnScreenOn(_entities.MediaPlayer.BedroomEchoShow.EntityId);
    }

    public void Awake()
    {
        _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Normal);
        _entities.Light.BedsideLamp.TurnOff();
        _entities.Light.Bedroom.TurnOff();
        _alexa.TurnScreenOn(_entities.MediaPlayer.BedroomEchoShow.EntityId);
        _alexa.TurnScreenOn(_entities.MediaPlayer.GuestRoomEchoShow.EntityId);
        _alexa.TurnScreenOn(_entities.MediaPlayer.KitchenCameraSpeaker.EntityId);
        _alexa.TurnScreenOn(_entities.MediaPlayer.SnugEchoShow.EntityId);
    }
}