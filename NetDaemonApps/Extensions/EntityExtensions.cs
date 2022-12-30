
namespace NetDaemonApps.Extensions;


public static class EntityExtensions
{
    public static IDisposable WhenOn<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
    => entity.StateChanges().Where(c => c.New?.IsOn() ?? false).Subscribe(action);

    public static IDisposable WhenOff<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
    => entity.StateChanges().Where(c => c.New?.IsOff() ?? false).Subscribe(action);


    public static bool IsUnknown(this EntityState? entityState) 
        => string.Equals(entityState?.State, "unknown", StringComparison.OrdinalIgnoreCase);

    public static bool IsUnknown(this Entity? entity) => entity?.EntityState?.IsUnknown() ?? false;

    public static IDisposable WhenUnknown<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
    => entity.StateChanges().Where(c => c.New?.IsUnknown() ?? false).Subscribe(action);

    public static bool IsUnavailable(this EntityState? entityState)
        => string.Equals(entityState?.State, "unavailable", StringComparison.OrdinalIgnoreCase);

    public static bool IsUnavailable(this Entity? entity) => entity?.EntityState?.IsUnavailable() ?? false;

    public static IDisposable WhenUnavailable<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
    => entity.StateChanges().Where(c => c.New?.IsUnavailable() ?? false).Subscribe(action);

    public static double? NumericState(this EntityState? entityState)
    {
        double result;
        if (double.TryParse(entityState?.State, out result))
            return result;
        return null;
    }


}

