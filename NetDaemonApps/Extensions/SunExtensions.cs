namespace NetDaemonApps.Extensions;

public static class SunExtensions
{
    public static bool IsAboveHorizon(this EntityState<SunAttributes>? state)
        => string.Equals(state?.State, "above_horizon", StringComparison.OrdinalIgnoreCase);

    public static bool IsAboveHorizon(this SunEntity? entity) 
        => entity?.EntityState?.IsAboveHorizon() ?? false;

    public static IDisposable WhenAboveHorizon(this SunEntity entity, 
        Action<StateChange<SunEntity, EntityState<SunAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsAboveHorizon() ?? false).Subscribe(action);

    public static bool IsBelowHorizon(this EntityState<SunAttributes>? state)
        => string.Equals(state?.State, "below_horizon", StringComparison.OrdinalIgnoreCase);

    public static bool IsBelowHorizon(this SunEntity? entity)
        => entity?.EntityState?.IsBelowHorizon() ?? false;

    public static IDisposable WhenBelowHorizon(this SunEntity entity,
        Action<StateChange<SunEntity, EntityState<SunAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsBelowHorizon() ?? false).Subscribe(action);



}

