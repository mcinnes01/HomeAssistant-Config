namespace NetDaemonApps.Extensions;

public static class ProximityExtensions
{
    public static bool IsTowards(this EntityState<ProximityAttributes>? entityState)
    => string.Equals(entityState?.Attributes?.DirOfTravel, "towards", StringComparison.OrdinalIgnoreCase);

    public static bool IsTowards(this ProximityEntity? entity)
        => entity?.EntityState?.IsTowards() ?? false;

    public static IDisposable WhenTowards(this ProximityEntity entity,
        Action<StateChange<ProximityEntity, NumericEntityState<ProximityAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsTowards() ?? false).Subscribe(action);

    public static bool IsArrived(this EntityState<ProximityAttributes>? entityState)
    => string.Equals(entityState?.Attributes?.DirOfTravel, "arrived", StringComparison.OrdinalIgnoreCase);

    public static bool IsArrived(this ProximityEntity? entity)
        => entity?.EntityState?.IsArrived() ?? false;

    public static IDisposable WhenArrived(this ProximityEntity entity,
        Action<StateChange<ProximityEntity, NumericEntityState<ProximityAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArrived() ?? false).Subscribe(action);

    public static bool IsNotSet(this EntityState<ProximityAttributes>? entityState)
    => string.Equals(entityState?.Attributes?.DirOfTravel, "not set", StringComparison.OrdinalIgnoreCase);

    public static bool IsNotSet(this ProximityEntity? entity)
        => entity?.EntityState?.IsNotSet() ?? false;

    public static IDisposable WhenNotSet(this ProximityEntity entity,
        Action<StateChange<ProximityEntity, NumericEntityState<ProximityAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsNotSet() ?? false).Subscribe(action);

    public static bool IsAwayFrom(this EntityState<ProximityAttributes>? entityState)
    => string.Equals(entityState?.Attributes?.DirOfTravel, "away_from", StringComparison.OrdinalIgnoreCase);

    public static bool IsAwayFrom(this ProximityEntity? entity)
        => entity?.EntityState?.IsAwayFrom() ?? false;

    public static IDisposable WhenAwayFrom(this ProximityEntity entity,
        Action<StateChange<ProximityEntity, NumericEntityState<ProximityAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsAwayFrom() ?? false).Subscribe(action);

    public static bool IsStationary(this EntityState<ProximityAttributes>? entityState)
    => string.Equals(entityState?.Attributes?.DirOfTravel, "stationary", StringComparison.OrdinalIgnoreCase);

    public static bool IsStationary(this ProximityEntity? entity)
        => entity?.EntityState?.IsStationary() ?? false;

    public static IDisposable WhenStationary(this ProximityEntity entity,
        Action<StateChange<ProximityEntity, NumericEntityState<ProximityAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsStationary() ?? false).Subscribe(action);
}