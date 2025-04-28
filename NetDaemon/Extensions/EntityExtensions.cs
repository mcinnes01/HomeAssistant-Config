using Humanizer;

namespace NetDaemon.Extensions;

public static class EntityExtensions
{
    public static readonly string[] OnStates = ["on", "playing"];
    public static readonly string[] BoolTypes = ["light", "switch", "scene", "input_boolean", "binary_sensor", "automation"];

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

    public static string? Name(this EntityState? entityState)
        => entityState?.EntityId.Split('.')[1];

    public static string? Name(this Entity? entity)
        => entity?.EntityId.Split('.')[1];

    public static string? TitleName(this EntityState? entityState)
        => entityState?.Name()?.Titleize();
    public static string? TitleName(this Entity? entity)
        => entity?.Name()?.Titleize();

    public static string? Domain(this EntityState? entityState)
        => entityState?.EntityId.Split('.')[0];

    public static string? Domain(this Entity? entity)
        => entity?.EntityId.Split('.')[0];

    public static bool BoolState(this Entity? entity)
    {
        return BoolTypes.ToList().Contains(entity?.Domain() ?? "") && entity?.State != null
            ? OnStates.Contains(entity?.State) : false;
    }
}