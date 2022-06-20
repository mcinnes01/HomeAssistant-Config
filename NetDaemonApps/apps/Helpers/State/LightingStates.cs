namespace Helpers.State;

public interface ILightingStates
{
    bool InMotionMode(bool nightLight = false);
}

public class LightingStates : ILightingStates
{
    private readonly ILogger<LightingStates> _logger;
    private readonly Entities _entities;

    public LightingStates(IHaContext ha, ILogger<LightingStates> logger)
    {
        _logger = logger;
        _entities = new Entities(ha);
    }

    public bool InMotionMode(bool nightLight = false) =>
        _entities.InputSelect.LightControlMode.AsOption<LightControlModeOptions>() switch
    {
        LightControlModeOptions.Cleaning => true,
        LightControlModeOptions.Motion => _entities.InputSelect.Brightness.IsNotOption(BrightnessOptions.Bright),
        LightControlModeOptions.Relaxing => _entities.InputSelect.Brightness.IsNotOption(BrightnessOptions.Bright),
        LightControlModeOptions.Sleeping => nightLight,
        _ => false
    };
}