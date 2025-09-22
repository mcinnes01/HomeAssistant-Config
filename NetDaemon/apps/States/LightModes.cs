namespace NetDaemon.apps.States;

[NetDaemonApp]
public class LightModes
{
    private readonly ILogger<LightModes> _logger;
    private readonly Entities _entities;
    private readonly LightEntity[] _bedroomLights;
    private readonly LightEntity[] _brightLightsNoRoomControl;
    private readonly LightEntity[] _loungeLights;
    private readonly LightEntity[] _insideNoRoomControlNotBasement;


    public LightModes(IHaContext ha, ILogger<LightModes> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        _insideNoRoomControlNotBasement =
        [
            _entities.Light.LandingLight,
            _entities.Light.StudioLight,
            _entities.Light.BathroomLight,
            _entities.Light.MirrorLight,
            _entities.Light.GuestRoomLight,
            _entities.Light.DressingRoomLight,
            _entities.Light.DrawingRoomLight,
            _entities.Light.BookshelfLight,
            _entities.Light.HallwayLight,
            _entities.Light.HallwayLamp,
            _entities.Light.KitchenLight,
            _entities.Light.BreakfastBarLamp,
        ];

        _bedroomLights =
        [
            _entities.Light.BedroomLight,
            _entities.Light.BedroomLamp
        ];

        _brightLightsNoRoomControl =
        [
            _entities.Light.BathroomLight,
            _entities.Light.HallwayLight,
            _entities.Light.DrawingRoomLight,
            _entities.Light.KitchenLight
        ];

        _loungeLights =
        [
            _entities.Light.LoungeLight,
            _entities.Light.LoungeLamp,
            _entities.Light.LoungeFloorLamp
        ];

        LightControlModeChanged();
    }

    private void LightControlModeChanged()
    {
        _entities.InputSelect.LightControlMode.StateAllChangesWithCurrent()
        .Subscribe(e =>
        {
            var oldMode = e.Old?.AsOption<LightControlModeOptions>();
            var newMode = e.New?.AsOption<LightControlModeOptions>();
            switch (oldMode, newMode)
            {
                case (LightControlModeOptions.Sleeping, LightControlModeOptions.Motion):
                    if (_entities.Select.BedroomMode.IsOption(RoomModeOptions.Sleeping))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} setting Bedroom Mode to Normal.");
                        _entities.Select.BedroomMode.SelectOption(RoomModeOptions.Normal);
                        _entities.Scene.Awake.TurnOn();
                    }
                    break;
                case (LightControlModeOptions.Cleaning, LightControlModeOptions.Motion):
                case (LightControlModeOptions.Cleaning, LightControlModeOptions.Relaxing):
                case (LightControlModeOptions.Manual, LightControlModeOptions.Relaxing):
                case (LightControlModeOptions.Motion, LightControlModeOptions.Relaxing):
                case (_, LightControlModeOptions.Motion):
                case (_, LightControlModeOptions.Relaxing):
                    _logger.LogDebug($"Old: {oldMode} to New: {newMode} turn bright lights off.");
                    _brightLightsNoRoomControl.TurnOff();
                    if (!Constants.BedroomMotionModes.Contains(_entities.Select.BedroomMode.AsOption<RoomModeOptions>()))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} Bedroom not in a motion mode, turning off Bedroom light.");
                        _entities.Light.BedroomLight.TurnOff();
                    }
                    if (_entities.Select.LoungeMode.IsNotOption(LoungeModeOptions.Bright))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} Lounge not in a motion mode, turning off Lounge light.");
                        _entities.Light.LoungeLight.TurnOff();
                    }
                    if (_entities.Select.SnugMode.IsNotOption(SnugModeOptions.Movie))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} Snug not in a Movie mode, turning off Snug light.");
                        _entities.Light.SnugLight.TurnOff();
                    }
                    break;
                case (LightControlModeOptions.Cleaning, LightControlModeOptions.Sleeping):
                case (LightControlModeOptions.Manual, LightControlModeOptions.Sleeping):
                case (LightControlModeOptions.Motion, LightControlModeOptions.Sleeping):
                case (LightControlModeOptions.Relaxing, LightControlModeOptions.Sleeping):
                case (_, LightControlModeOptions.Sleeping):
                    _logger.LogDebug($"Old: {oldMode} to New: {newMode} turning all lights off.");
                    _entities.Light.AllLights.TurnOff();
                    if (_entities.Select.LoungeMode.IsNotOption(LoungeModeOptions.Normal))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} setting Lounge Mode to Normal.");
                        _entities.Select.LoungeMode.SelectOption(LoungeModeOptions.Normal);
                    }
                    if (_entities.Select.SnugMode.IsNotOption(SnugModeOptions.Normal))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} setting Snug Mode to Normal.");
                        _entities.Select.SnugMode.SelectOption(SnugModeOptions.Normal);
                    }
                    if (_entities.Select.BedroomMode.IsNotOption(RoomModeOptions.Sleeping))
                    {
                        _logger.LogDebug($"Old: {oldMode} to New: {newMode} setting Bedroom Mode to Sleeping.");
                        _entities.Select.BedroomMode.SelectOption(RoomModeOptions.Sleeping);
                        _entities.Scene.Sleeping.TurnOn();
                    }
                    break;
                default:
                    _logger.LogDebug($"Old: {oldMode} to New: {newMode} not a valid transition.");
                    break;
            }
        });
    }
}