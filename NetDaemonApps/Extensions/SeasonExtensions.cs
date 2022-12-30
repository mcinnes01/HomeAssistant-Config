
namespace NetDaemonApps.Extensions;

public static class SeasonExtensions
{
    public static bool IsSummer(this EntityState<SensorAttributes>? state)
        => string.Equals(state?.State, "summer", StringComparison.OrdinalIgnoreCase);

    public static bool IsSummer(this SensorEntity? entity) 
        => entity?.EntityState?.IsSummer() ?? false;

    public static IDisposable WhenSummer(this SensorEntity entity, 
        Action<StateChange<SensorEntity, EntityState<SensorAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsSummer() ?? false).Subscribe(action);

    public static bool IsWinter(this EntityState<SensorAttributes>? state)
        => string.Equals(state?.State, "winter", StringComparison.OrdinalIgnoreCase);

    public static bool IsWinter(this SensorEntity? entity)
        => entity?.EntityState?.IsWinter() ?? false;

    public static IDisposable WhenWinter(this SensorEntity entity,
        Action<StateChange<SensorEntity, EntityState<SensorAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsWinter() ?? false).Subscribe(action);

    public static bool IsSpring(this EntityState<SensorAttributes>? state)
        => string.Equals(state?.State, "spring", StringComparison.OrdinalIgnoreCase);

    public static bool IsSpring(this SensorEntity? entity)
        => entity?.EntityState?.IsSpring() ?? false;

    public static IDisposable WhenSpring(this SensorEntity entity,
        Action<StateChange<SensorEntity, EntityState<SensorAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsSpring() ?? false).Subscribe(action);

    public static bool IsAutumn(this EntityState<SensorAttributes>? state)
        => string.Equals(state?.State, "autumn", StringComparison.OrdinalIgnoreCase);

    public static bool IsAutumn(this SensorEntity? entity)
        => entity?.EntityState?.IsAutumn() ?? false;

    public static IDisposable WhenAutumn(this SensorEntity entity,
        Action<StateChange<SensorEntity, EntityState<SensorAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsAutumn() ?? false).Subscribe(action);        
    
}
