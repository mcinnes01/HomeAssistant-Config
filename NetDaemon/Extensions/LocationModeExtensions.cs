namespace NetDaemon.Extensions;

public static class LocationModeExtensions
{
    public static bool Home(this EntityState<InputSelectAttributes>? state)
    => state.IsOption(LocationModeOptions.Home);
    public static bool Home(this InputSelectEntity? entity)
    => entity?.EntityState.Home() ?? false;
    public static bool Away(this EntityState<InputSelectAttributes>? state)
    => state.IsOption(LocationModeOptions.Away);
    public static bool Away(this InputSelectEntity? entity)
    => entity?.EntityState.Away() ?? false;
    public static bool OneAway(this EntityState<InputSelectAttributes>? state)
    => state.IsOption(LocationModeOptions.OneAway);
    public static bool OneAway(this InputSelectEntity? entity)
    => entity?.EntityState.OneAway() ?? false;
    public static bool HouseSitter(this EntityState<InputSelectAttributes>? state)
    => state.IsOption(LocationModeOptions.HouseSitter);
    public static bool HouseSitter(this InputSelectEntity? entity)
    => entity?.EntityState.HouseSitter() ?? false;
    public static bool Guest(this EntityState<InputSelectAttributes>? state)
    => state.IsOption(LocationModeOptions.Guest);
    public static bool Guest(this InputSelectEntity? entity)
    => entity?.EntityState.Guest() ?? false;
    public static bool OneOrBothHome(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Home)
    || locationMode.IsOption(LocationModeOptions.OneAway);
    public static bool Occupied(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.Home)
    || locationMode.IsOption(LocationModeOptions.OneAway)
    || locationMode.IsOption(LocationModeOptions.HouseSitter)
    || locationMode.IsOption(LocationModeOptions.Guest);
    public static bool PeopleStaying(this InputSelectEntity locationMode)
    => locationMode.IsOption(LocationModeOptions.HouseSitter)
    || locationMode.IsOption(LocationModeOptions.Guest);
}