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
                Shed Light: {_entities.Light.ShedLight.State}");
            return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
            && e.New.IsDetected()
            && _entities.Light.ShedLight.IsOff() && _entities.Light.FenceLights.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Person detected in the garden");
            _entities.Light.ShedLight.TurnOn();
            _entities.Light.FenceLights.TurnOn();

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
                Shed Light: {_entities.Light.ShedLight.State},
                Fence Lights: {_entities.Light.FenceLights.State}");
            return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
            && e.New.IsDetected()
            && _entities.Light.ShedLight.IsOff() && _entities.Light.FenceLights.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Car detected in the garden");
            _entities.Light.ShedLight.TurnOn();
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
                Back Door Light: {_entities.Light.BackDoorLight.State},
                Decking Wall Light: {_entities.Light.DeckingWallLight.State}");
            return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
            && e.New.IsDetected()
            && _entities.Light.FenceLights.IsOff()
            && _entities.Light.PatioLight.IsOff()
            && _entities.Light.BackDoorLight.IsOff()
            && _entities.Light.DeckingWallLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Person detected in the garden");
            _entities.Light.BackDoorLight.TurnOn();
            _entities.Light.DeckingWallLight.TurnOn();

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
                Patio Light: {_entities.Light.PatioLight.State},
                Back Door Light: {_entities.Light.BackDoorLight.State},
                Decking Wall Light: {_entities.Light.DeckingWallLight.State}");
            return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
            && e.New.IsDetected()
            && _entities.Light.FenceLights.IsOff()
            && _entities.Light.PatioLight.IsOff()
            && _entities.Light.BackDoorLight.IsOff()
            && _entities.Light.DeckingWallLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Car detected in the garden");
            _entities.Light.BackDoorLight.TurnOn();
            _entities.Light.DeckingWallLight.TurnOn();
            _entities.Light.PatioLight.TurnOn();
            _entities.Light.FenceLights.TurnOn();
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
                Patio Light: {_entities.Light.PatioLight.State},
                Back Door Light: {_entities.Light.BackDoorLight.State},
                Decking Wall Light: {_entities.Light.DeckingWallLight.State}");
            return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
            && e.New.IsOpen()
            && _entities.Light.PatioLight.IsOff()
            && _entities.Light.BackDoorLight.IsOff()
            && _entities.Light.DeckingWallLight.IsOff();
        })
        .Subscribe(_ =>
        {
            _logger.LogDebug("Patio door is open");
            _entities.Light.BackDoorLight.TurnOn();
            _entities.Light.DeckingWallLight.TurnOn();
        });
    }

    private void PatioNoMotionAndDoorClosed()
    {
        _entities.BinarySensor.PatioDoor.StateChanges()
        .Merge(_entities.BinarySensor.ShedDoor.StateChanges())
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
                    BackDoor Light: {_entities.Light.BackDoorLight.State},
                    Decking Wall Light: {_entities.Light.DeckingWallLight.State},
                    Patio Light: {_entities.Light.PatioLight.State},
                    Shed Light: {_entities.Light.ShedLight.State},
                    Fence Lights: {_entities.Light.FenceLights.State}");

                return (_entities.Light.PatioLight.IsOn() || _entities.Light.BackDoorLight.IsOn())
                && _entities.BinarySensor.PatioDoor.IsClosed()
                && _entities.BinarySensor.ShedDoor.IsClosed()
                && _entities.BinarySensor.PatioCameraMotion.IsNotDetected()
                && _entities.BinarySensor.PatioCameraObjectDetected.IsNotDetected()
                && _entities.BinarySensor.PatioCameraPersonDetected.IsNotDetected()
                && _entities.BinarySensor.PatioCameraVehicleDetected.IsNotDetected()
                && _entities.BinarySensor.ShedCameraObjectDetected.IsNotDetected()
                && _entities.BinarySensor.ShedCameraPersonDetected.IsNotDetected()
                && _entities.BinarySensor.ShedCameraVehicleDetected.IsNotDetected();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ =>
            {
                _logger.LogDebug("No motion in the garden.");
                if (_entities.Light.BackDoorLight.IsOn())
                    _entities.Light.BackDoorLight.TurnOff();

                if (_entities.Light.DeckingWallLight.IsOn())
                    _entities.Light.DeckingWallLight.TurnOff();

                if (_entities.Light.PatioLight.IsOn())
                    _entities.Light.PatioLight.TurnOff();

                if (_entities.Light.ShedLight.IsOn())
                    _entities.Light.ShedLight.TurnOff();

                if (_entities.Light.FenceLights.IsOn())
                    _entities.Light.FenceLights.TurnOff();
            });
    }
}