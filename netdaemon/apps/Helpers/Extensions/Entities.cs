namespace Helpers.Extensions;

public static class EntityExtensions
{
    public static Entities MyEntities(this IHaContext ha) => new (ha);
    public static Services Services(this IHaContext ha) => new (ha);
  
    public static void SwitchTo(this SwitchEntity? heaterSwitch, string? newState)
    {
        if (heaterSwitch?.State != newState)
        {
            if (newState == "on")
            {
                heaterSwitch?.TurnOn();
            }
            else
            {
                heaterSwitch?.TurnOff();
            }
        }
    }

    public static IDisposable WhenTurnsOn<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
        => entity.StateChanges().Where(c => (c.Old?.IsOff() ?? false) && (c.New?.IsOn() ?? false)).Subscribe(action);

    public static IDisposable WhenTurnsOff<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
        => entity.StateChanges().Where(c => (c.Old?.IsOn() ?? false) && (c.New?.IsOff() ?? false)).Subscribe(action);
}