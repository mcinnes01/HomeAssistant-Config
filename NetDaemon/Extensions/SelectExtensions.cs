namespace NetDaemon.Extensions;

public static class SelectExtensions
{
    // Helper extension to check presence within a time window
    private static bool PresenceDetectedWithin(this SelectEntity entity, TimeSpan timeSpan)
    {
        return entity.EntityState?.LastChanged != null && 
            (DateTime.UtcNow - entity.EntityState.LastChanged.Value) <= timeSpan;
    }

    public static void SelectOption<T>(this SelectEntity target, T @option)
        where T : Enum
    {
        if(string.IsNullOrEmpty(option.ToString()))
            throw new NullReferenceException();

        // if (!nameof(T).Contains(nameof(target)))
        //     throw new ArrayTypeMismatchException();

        target.SelectOption(option.ToString());
    }

    public static T AsOption<T>(this SelectEntity? target)
        where T : struct
    {
        try
        {
            if(string.IsNullOrEmpty(target?.State))
                throw new NullReferenceException();

            T option = (T)Enum.Parse(typeof(T), target.State);
            if (!Enum.IsDefined(typeof(T), option))
                throw new ArgumentOutOfRangeException($"Value: {target.State} not found for type: {nameof(T)}");

            return option;
        }
        catch
        {
            throw;
        }
    }

    public static T AsOption<T>(this EntityState<SelectAttributes> target)
        where T : struct
    {
        try
        {
            if(string.IsNullOrEmpty(target?.State))
                throw new NullReferenceException();

            T option = (T)Enum.Parse(typeof(T), target.State);
            if (!Enum.IsDefined(typeof(T), option))
                throw new ArgumentOutOfRangeException($"Value: {target.State} not found for type: {nameof(T)}");

            return option;
        }
        catch
        {
            throw;
        }
    }
    public static bool IsOption(this SelectEntity target, Enum @option)
    =>target.State == @option.ToString();

    public static bool IsOption(this EntityState<SelectAttributes>? target, Enum @option)
    => target?.State == @option.ToString();

    public static bool IsNotOption(this SelectEntity target, Enum @option)
    => target.State != @option.ToString();

    public static bool IsNotOption(this EntityState<SelectAttributes>? target, Enum @option)
    => target?.State != @option.ToString();

    public static SelectSelectOptionParameters ToOptions<T>() where T : Enum => 
    new SelectSelectOptionParameters()
    {
        Option = "" //Enum.GetNames(typeof(T)).Join(","),
    };

    public static bool Bright(this SelectEntity entity)
    => entity.IsOption(RoomModeOptions.Bright);
    public static bool Movie(this SelectEntity entity)
    => entity.IsOption(SnugModeOptions.Movie);
    public static void Normal(this SelectEntity entity)
    => entity.SelectOption(RoomModeOptions.Normal);
    public static bool Relaxing(this SelectEntity entity)
    => entity.IsOption(RoomModeOptions.Relaxing);
    public static bool Showering(this SelectEntity entity)
    => entity.IsOption(BathroomModeOptions.Showering);
    public static bool Sleeping(this SelectEntity entity)
    => entity.IsOption(RoomModeOptions.Sleeping);
    public static void Television(this SelectEntity entity)
    => entity.SelectOption(LoungeModeOptions.Television);
    public static bool IsManual(this EntityState<SelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Manual) ?? false;
    public static bool IsManual(this SelectEntity? entity)
    => entity?.EntityState?.IsMotion() ?? false;
    public static bool IsMotion(this EntityState<SelectAttributes>? state)
    => state?.IsOption(SnugModeOptions.Movie) ?? false;
    public static bool IsMotion(this SelectEntity? entity)
    => entity?.EntityState?.IsMotion() ?? false;
    public static bool IsMovie(this EntityState<SelectAttributes>? state)
    => state?.IsOption(SnugModeOptions.Movie) ?? false;
    public static bool IsMovie(this SelectEntity? entity)
    => entity?.EntityState?.IsMovie() ?? false;
    public static bool IsNormal(this EntityState<SelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Normal) ?? false;
    public static bool IsNormal(this SelectEntity? entity)
    => entity?.EntityState?.IsNormal() ?? false;
    public static bool IsRelaxing(this EntityState<SelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Relaxing) ?? false;
    public static bool IsRelaxing(this SelectEntity? entity)
    => entity?.EntityState?.IsRelaxing() ?? false;
    public static bool IsShowering(this EntityState<SelectAttributes>? state)
    => state?.IsOption(BathroomModeOptions.Showering) ?? false;
    public static bool IsShowering(this SelectEntity? entity)
    => entity?.EntityState?.IsShowering() ?? false;
    public static bool IsSleeping(this EntityState<SelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Sleeping) ?? false;
    public static bool IsSleeping(this SelectEntity? entity)
    => entity?.EntityState?.IsSleeping() ?? false;
    public static bool IsTelevision(this EntityState<SelectAttributes>? state)
    => state?.IsOption(LoungeModeOptions.Television) ?? false;
    public static bool IsTelevision(this SelectEntity? entity)
    => entity?.EntityState?.IsTelevision() ?? false;
    public static bool IsBright(this EntityState<SelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Bright) ?? false;
    public static bool IsBright(this SelectEntity? entity)
    => entity?.EntityState?.IsBright() ?? false;
    public static bool IsPartying(this EntityState<SelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Partying) ?? false;
    public static bool IsPartying(this SelectEntity? entity)
    => entity?.EntityState?.IsPartying() ?? false;
}