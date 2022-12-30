
namespace NetDaemonApps.Extensions;

public static class StateChangeExtensions
{
    public static IObservable<StateChange<TEntity, TState>> StateAllChangesWithCurrent<TEntity, TState, TAttributes>(this TEntity entity)
        where TEntity : Entity<TEntity, TState, TAttributes>
        where TState : EntityState<TAttributes>
        where TAttributes : class
        
    => entity.StateAllChanges().Prepend(new StateChange<TEntity, TState>(entity, null, entity.EntityState));


    public static IObservable<StateChange<TEntity, TState>> StateChangesWithCurrent<TEntity, TState, TAttributes>(this TEntity entity)
        where TEntity : Entity<TEntity, TState, TAttributes>
        where TState : EntityState<TAttributes>
        where TAttributes : class

    => entity.StateChanges().Prepend(new StateChange<TEntity, TState>(entity, null, entity.EntityState));

}

