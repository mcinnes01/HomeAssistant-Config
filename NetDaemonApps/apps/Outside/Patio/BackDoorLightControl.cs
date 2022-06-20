using NetDaemon.Extensions.Tts;

namespace Outside.Patio;

[NetDaemonApp]
public class BackDoorLightControl
{
    private readonly string[] _smartDetections = new[] {"person", "vehicle"};
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
        PatioCameraPersonDetected();
        PatioCameraCarDetected();
        PatioDoorIsOpened();
        PatioNoMotionAndDoorClosed();
        PatioDoorClosed();
    }

    private void PatioCameraPersonDetected()
    {
        _entities.Sensor.PatioCameraDetectedObject
            .StateChanges()
            .Where(e => 
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State}, 
                    Object Detection: Old: {e.Old?.State} - New: {e.New?.State}, 
                    Back Door Light: {_entities.Light.BackDoor.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New?.State == "person"
                && _entities.Light.Patio.IsOff() && _entities.Light.BackDoor.IsOff();
            })
            .Subscribe(_ => 
            {
                _logger.LogDebug("Person detected in the garden");
                _entities.Light.BackDoor.TurnOn();

                if (_entities.InputSelect.LightControlMode.IsOption(LightControlModeOptions.Sleeping))
                {
                    _logger.LogDebug("Intruder detected in the garden whilst you are sleeping");
                    //_tts.Speak("media_player.all_speakers", "Alert! There is an intruder in the back garden.", "alexa");
                }
            });
    }

    private void PatioCameraCarDetected()
    {
        _entities.Sensor.PatioCameraDetectedObject
            .StateChanges()
            .Where(e => 
            {
                _logger.LogTrace(@$"Brightness: {_entities.InputSelect.Brightness.State}, 
                    Object Detection: Old: {e.Old?.State} - New: {e.New?.State}, 
                    Patio Light: {_entities.Light.Patio.State}, 
                    Back Door Light: {_entities.Light.BackDoor.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New?.State == "vehicle"
                && _entities.Light.Patio.IsOff() && _entities.Light.BackDoor.IsOff();
            })
            .Subscribe(_ => 
            {
                _logger.LogDebug("Car detected in the garden");
                _entities.Light.BackDoor.TurnOn();
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
                    Back Door Light: {_entities.Light.BackDoor.State}");
                return _entities.InputSelect.Brightness.IsOption(BrightnessOptions.Dark)
                && e.New.IsOpen()
                && _entities.Light.Patio.IsOff() && _entities.Light.BackDoor.IsOff();
            })
            .Subscribe(_ => 
            {
                _logger.LogDebug("Patio door is open");
                _entities.Light.BackDoor.TurnOn();
            });
    }

    private void PatioNoMotionAndDoorClosed()
    {
        _entities.Sensor.PatioCameraDetectedObject
            .StateChanges()
            .Where(e => 
            {
                _logger.LogTrace(@$"Patio motion: Old: {e.Old?.State} - New: {e.New?.State},
                    BackDoor Light: {_entities.Light.BackDoor.State},
                    Patio Light: {_entities.Light.Patio.State}");

                return !_smartDetections.Contains(e.New?.State)
                && (_entities.Light.Patio.IsOn() || _entities.Light.BackDoor.IsOn())
                && _entities.BinarySensor.PatioDoor.IsClosed();
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => 
            {
                _logger.LogDebug("No motion in the garden.");
                if (_entities.Light.BackDoor.IsOn())
                    _entities.Light.BackDoor.TurnOff();

                if (_entities.Light.Patio.IsOn())
                    _entities.Light.Patio.TurnOff();
            });
    }

    private void PatioDoorClosed()
    {
        _entities.BinarySensor.PatioDoor
            .StateChanges()
            .Where(e => 
            {
                _logger.LogTrace(@$"Door open: Old: {e.Old?.State} - New: {e.New?.State},
                    BackDoor Light: {_entities.Light.BackDoor.State},
                    Patio Light: {_entities.Light.Patio.State}");

                return e.New.IsClosed()
                && (_entities.Light.Patio.IsOn() || _entities.Light.BackDoor.IsOn());
            })
            .Throttle(TimeSpan.FromMinutes(2))
            .Subscribe(_ => 
            {
                _logger.LogDebug("Patio door is closed");
                if (_entities.Light.BackDoor.IsOn())
                    _entities.Light.BackDoor.TurnOff();

                if (_entities.Light.Patio.IsOn())
                    _entities.Light.Patio.TurnOff();
            });
    }
}