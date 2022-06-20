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
            //     _logger.LogTrace(@$"Light Mode: {_entities.InputSelect.LightControlMode.State}, 
            //         Bedroom Mode: {_entities.InputSelect.BedroomMode.State}");
            //     return e.Old?.State != "Relaxing"
            //     && e.New?.State == "Relaxing";
            // })
            .Subscribe(s =>
            {
                Enum.TryParse<BedroomModeOptions>(s.Old?.State, out var oldMode);
                Enum.TryParse<BedroomModeOptions>(s.New?.State, out var newMode);
                
                // State machine
                switch (oldMode, newMode)
                {
                    case (_,BedroomModeOptions.Sleeping):
                        _entities.Light.BedroomLights.TurnOff();
                        break;
                    case (BedroomModeOptions.Sleeping, BedroomModeOptions.Relaxing):
                    case (BedroomModeOptions.Normal, BedroomModeOptions.Relaxing):
                        _entities.Light.Bedroom.TurnOff();
                        break;
                    case (BedroomModeOptions.Sleeping, BedroomModeOptions.Normal):
                    case (BedroomModeOptions.Relaxing, BedroomModeOptions.Normal):
                        _entities.Light.BedsideLamp.TurnOff();
                        break;
                    default:
                        break;
                }
            });
    }
}