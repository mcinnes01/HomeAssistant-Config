namespace Outside.Patio;

[NetDaemonApp]
public class BackDoorLightControl
{
    private readonly ITextToSpeechService _tts;
    private readonly ILogger<BackDoorLightControl> _logger;
    private readonly Entities _entities;

    public BackDoorLightControl(IHaContext ha, ITextToSpeechService tts, ILogger<BackDoorLightControl> logger)
    {
        _tts = tts;
        _logger = logger;
        _entities = new Entities(ha);
        //var t = new Services(ha);
        //ha.Services.Tts.Say.
        ShedCameraPersonDetected();
        ShedCameraCarDetected();
        PatioCameraPersonDetected();
        PatioCameraCarDetected();
        PatioDoorIsOpened();
        PatioNoMotionAndDoorClosed();
    }

    private void ShedCameraPersonDetected()
    {
        _entities.BinarySensor.ShedCameraPersonDetected
            .StateChanges()
            .Where(e =>
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State},
                    Person Detection: Old: {e.Old?.State} - New: {e.New?.State},
                    Shed Light: {_entities.Light.Shed.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New.IsDetected()
                && _entities.Light.Shed.IsOff() && _entities.Light.FenceLights.IsOff();
            })
            .Subscribe(_ =>
            {
                _logger.LogDebug("Person detected in the garden");
                _entities.Light.Shed.TurnOn();

                if (_entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Sleeping))
                {
                    _logger.LogDebug("Intruder detected in the garden whilst you are sleeping");
                    //_tts.Speak("media_player.all_speakers", "Alert! There is an intruder in the back garden.", "alexa");
                }
            });
    }

    private void ShedCameraCarDetected()
    {
        _entities.BinarySensor.ShedCameraVehicleDetected
            .StateChanges()
            .Where(e =>
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State},
                    Vehicle Detection: Old: {e.Old?.State} - New: {e.New?.State},
                    Shed Light: {_entities.Light.Shed.State},
                    Fence Lights: {_entities.Light.FenceLights.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New.IsDetected()
                && _entities.Light.Shed.IsOff() && _entities.Light.FenceLights.IsOff();
            })
            .Subscribe(_ =>
            {
                _logger.LogDebug("Car detected in the garden");
                _entities.Light.Shed.TurnOn();
                _entities.Light.FenceLights.TurnOn();
            });
    }

    private void PatioCameraPersonDetected()
    {
        _entities.BinarySensor.PatioCameraPersonDetected
            .StateChanges()
            .Where(e =>
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State},
                    Person Detection: Old: {e.Old?.State} - New: {e.New?.State},
                    Back Door Light: {_entities.Light.BackDoor.State},
                    Decking Wall Light: {_entities.Light.DeckingWall.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New.IsDetected()
                && _entities.Light.Patio.IsOff()
                && _entities.Light.BackDoor.IsOff()
                && _entities.Light.DeckingWall.IsOff();
            })
            .Subscribe(_ =>
            {
                _logger.LogDebug("Person detected in the garden");
                _entities.Light.BackDoor.TurnOn();
                _entities.Light.DeckingWall.TurnOn();

                if (_entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Sleeping))
                {
                    _logger.LogDebug("Intruder detected in the garden whilst you are sleeping");
                    //_tts.Speak("media_player.all_speakers", "Alert! There is an intruder in the back garden.", "alexa");
                }
            });
    }

    private void PatioCameraCarDetected()
    {
        _entities.BinarySensor.PatioCameraVehicleDetected
            .StateChanges()
            .Where(e =>
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State},
                    Vehicle Detection: Old: {e.Old?.State} - New: {e.New?.State},
                    Patio Light: {_entities.Light.Patio.State},
                    Back Door Light: {_entities.Light.BackDoor.State},
                    Decking Wall Light: {_entities.Light.DeckingWall.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New.IsDetected()
                && _entities.Light.Patio.IsOff()
                && _entities.Light.BackDoor.IsOff()
                && _entities.Light.DeckingWall.IsOff();
            })
            .Subscribe(_ =>
            {
                _logger.LogDebug("Car detected in the garden");
                _entities.Light.BackDoor.TurnOn();
                _entities.Light.DeckingWall.TurnOn();
                _entities.Light.Patio.TurnOn();
            });
    }

    private void PatioDoorIsOpened()
    {
        _entities.BinarySensor.PatioDoor
            .StateChanges()
            .Where(e =>
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State},
                    Patio Door: Old: {e.Old?.State} - New: {e.New?.State},
                    Patio Light: {_entities.Light.Patio.State},
                    Back Door Light: {_entities.Light.BackDoor.State},
                    Decking Wall Light: {_entities.Light.DeckingWall.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New.IsOpen()
                && _entities.Light.Patio.IsOff()
                && _entities.Light.BackDoor.IsOff()
                && _entities.Light.DeckingWall.IsOff();
            })
            .Subscribe(_ =>
            {
                _logger.LogDebug("Patio door is open");
                _entities.Light.BackDoor.TurnOn();
                _entities.Light.DeckingWall.TurnOn();
            });
    }

    private void PatioNoMotionAndDoorClosed()
    {
        _entities.BinarySensor.PatioDoor.StateChanges()
        .Merge(_entities.BinarySensor.PatioCameraMotion.StateChanges())
        .Merge(_entities.BinarySensor.PatioCameraObjectDetected.StateChanges())
        .Merge(_entities.BinarySensor.PatioCameraPersonDetected.StateChanges())
        .Merge(_entities.BinarySensor.PatioCameraVehicleDetected.StateChanges())
        .Merge(_entities.BinarySensor.ShedCameraObjectDetected.StateChanges())
        .Merge(_entities.BinarySensor.ShedCameraPersonDetected.StateChanges())
        .Merge(_entities.BinarySensor.ShedCameraVehicleDetected.StateChanges())
            .Where(e =>
            {
                _logger.LogTrace(@$"Patio motion: Old: {e.Old?.State} - New: {e.New?.State},
                    BackDoor Light: {_entities.Light.BackDoor.State},
                    Decking Wall Light: {_entities.Light.DeckingWall.State},
                    Patio Light: {_entities.Light.Patio.State},
                    Shed Light: {_entities.Light.Shed.State},
                    Fence Lights: {_entities.Light.FenceLights.State}");

                return (_entities.Light.Patio.IsOn() || _entities.Light.BackDoor.IsOn())
                && _entities.BinarySensor.PatioCameraMotion.IsNotDetected()
                && _entities.BinarySensor.PatioCameraObjectDetected.IsNotDetected()
                && _entities.BinarySensor.PatioCameraPersonDetected.IsNotDetected()
                && _entities.BinarySensor.PatioCameraVehicleDetected.IsNotDetected()
                && _entities.BinarySensor.ShedCameraObjectDetected.IsNotDetected()
                && _entities.BinarySensor.ShedCameraPersonDetected.IsNotDetected()
                && _entities.BinarySensor.ShedCameraVehicleDetected.IsNotDetected()
                && _entities.BinarySensor.PatioDoor.IsClosed();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ =>
            {
                _logger.LogDebug("No motion in the garden.");
                if (_entities.Light.BackDoor.IsOn())
                    _entities.Light.BackDoor.TurnOff();

                if (_entities.Light.DeckingWall.IsOn())
                    _entities.Light.DeckingWall.TurnOff();

                if (_entities.Light.Patio.IsOn())
                    _entities.Light.Patio.TurnOff();

                if (_entities.Light.Shed.IsOn())
                    _entities.Light.Shed.TurnOff();

                if (_entities.Light.FenceLights.IsOn())
                    _entities.Light.FenceLights.TurnOff();
            });
    }
}