namespace NetDaemon.Extensions;

public static class LocationModeExtensions
{
    public static bool IsVaccant(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Away);
    public static bool IsGuest(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Guest);
    public static bool IsHome(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Home);
    public static bool IsHouseSitter(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.HouseSitter);
    public static bool IsLeaving(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Leaving);
    public static bool IsOneAway(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.OneAway);
    public static bool IsReturning(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Returning);
    public static bool IsOneOrBothHome(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Home)
    || locationMode.IsOption(LocationModeOptions.OneAway);
    public static bool IsOccupied(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Home)
    || locationMode.IsOption(LocationModeOptions.OneAway)
    || locationMode.IsOption(LocationModeOptions.HouseSitter)
    || locationMode.IsOption(LocationModeOptions.Guest);
    public static void Away(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.Away);
    public static void Guest(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.Guest);
    public static void Home(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.Home);
    public static void HouseSitter(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.HouseSitter);
    public static void Leaving(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.Leaving);
    public static void OneAway(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.OneAway);
    public static void Returning(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LocationModeOptions.Returning);
}