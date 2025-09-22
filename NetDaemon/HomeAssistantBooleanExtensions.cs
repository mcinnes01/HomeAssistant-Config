using NetDaemon.HassModel.Entities;

public static class HomeAssistantBooleanExtensions
{
    /// <summary>
    /// Gets the boolean state for an InputBooleanEntity ("on" = true, "off" = false, else null)
    /// </summary>
    public static bool? GetBooleanState(this InputBooleanEntity entity)
        => entity?.State switch
        {
            "on" => true,
            "off" => false,
            _ => null
        };

    /// <summary>
    /// Gets the boolean state for a BinarySensorEntity ("on" = true, "off" = false, else null)
    /// </summary>
    public static bool? GetBooleanState(this BinarySensorEntity entity)
        => entity?.State switch
        {
            "on" => true,
            "off" => false,
            _ => null
        };
}
