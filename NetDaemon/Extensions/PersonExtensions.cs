
namespace NetDaemon.Extensions;

public static class PersonExtensions
{
    public static bool IsHome(this EntityState<PersonAttributes>? state)
        => string.Equals(state?.State, "home", StringComparison.OrdinalIgnoreCase);

    public static bool IsHome(this PersonEntity? entity)
        => entity?.EntityState?.IsHome() ?? false;

    public static IDisposable WhenHome(this PersonEntity entity,
        Action<StateChange<PersonEntity, EntityState<PersonAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsHome() ?? false).Subscribe(action);

    public static bool IsNotHome(this EntityState<PersonAttributes>? state)
        => string.Equals(state?.State, "not_home", StringComparison.OrdinalIgnoreCase);

    public static bool IsNotHome(this PersonEntity? entity)
        => entity?.EntityState?.IsNotHome() ?? false;

    public static IDisposable WhenNotHome(this PersonEntity entity,
        Action<StateChange<PersonEntity, EntityState<PersonAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsNotHome() ?? false).Subscribe(action);

}

