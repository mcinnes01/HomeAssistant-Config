using static HomeAssistantGenerated.InputSelectEntities;

namespace Upstairs.Bedroom;

[NetDaemonApp]
public class BedroomMode
{
    private readonly ILogger<BedroomMode> _logger;
    private readonly Entities _entities;

    public BedroomMode(IHaContext ha, ILogger<BedroomMode> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);

        BedroomModeRelaxing();
    }

    private void BedroomModeRelaxing()
    {
        _entities.InputSelect.BedroomMode
            .StateChanges()
            // .Where(e => 
            // {
            //     _logger.LogDebug(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
            //         Bedroom Mode: {_entities.InputSelect.BedroomMode.State}");
            //     return e.Old?.State != "Relaxing"
            //     && e.New?.State == "Relaxing";
            // })
            .Subscribe(s =>
            {
                // State machine
                switch (s.Old?.State, s.New?.State)
                {
                    case (_,"Night"):
                        _entities.Light.BedroomLights.TurnOff();
                        break;
                    case ("Night", "Relaxing"):
                    case ("Normal", "Relaxing"):
                        _entities.Light.Bedroom.TurnOff();
                        break;
                    case ("Night", "Normal"):
                    case ("Relaxing", "Normal"):
                        _entities.Light.BedsideLamp.TurnOff();
                        break;
                    default:
                        break;
                }
            });
    }
}