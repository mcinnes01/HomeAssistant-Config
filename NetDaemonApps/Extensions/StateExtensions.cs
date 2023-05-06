
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

    public static IObservable<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> StateAllChangesWithCurrent(this BinarySensorEntity entity)
    => entity.StateAllChangesWithCurrent<BinarySensorEntity, EntityState<BinarySensorAttributes>, BinarySensorAttributes>();

    public static IObservable<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> StateAllChangesWithCurrent(this InputSelectEntity entity)
    => entity.StateAllChangesWithCurrent<InputSelectEntity, EntityState<InputSelectAttributes>, InputSelectAttributes>();

    public static IObservable<StateChange<NumericSensorEntity, NumericEntityState<NumericSensorAttributes>>> StateAllChangesWithCurrent(this NumericSensorEntity entity)
    => entity.StateAllChangesWithCurrent<NumericSensorEntity, NumericEntityState<NumericSensorAttributes>, NumericSensorAttributes>();
}