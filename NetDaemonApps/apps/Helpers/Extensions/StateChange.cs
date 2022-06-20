namespace Helpers.Extensions;

public static class StateChangeExtensions
{
    public static IObservable<StateChange<TEntity, TState>> StateAllChangesWithCurrent<TEntity, TState, TAttributes>(this TEntity entity) 
    where TEntity : Entity<TEntity, TState, TAttributes>
    where TState : EntityState<TAttributes>
    where TAttributes : class
    {
        return entity.StateAllChanges().Prepend(new StateChange<TEntity, TState>(entity, null, entity.EntityState));
    }

    public static IObservable<StateChange<AutomationEntity, EntityState<AutomationAttributes>>> StateAllChangesWithCurrent(this AutomationEntity entity)
    {
        return entity.StateAllChangesWithCurrent<AutomationEntity, EntityState<AutomationAttributes>, AutomationAttributes>();
    }

    public static IObservable<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> StateAllChangesWithCurrent(this BinarySensorEntity entity)
    {
        return entity.StateAllChangesWithCurrent<BinarySensorEntity, EntityState<BinarySensorAttributes>, BinarySensorAttributes>();
    }

    public static IObservable<StateChange<ButtonEntity, EntityState<ButtonAttributes>>> StateAllChangesWithCurrent(this ButtonEntity entity)
    {
        return entity.StateAllChangesWithCurrent<ButtonEntity, EntityState<ButtonAttributes>, ButtonAttributes>();
    }

    public static IObservable<StateChange<CalendarEntity, EntityState<CalendarAttributes>>> StateAllChangesWithCurrent(this CalendarEntity entity)
    {
        return entity.StateAllChangesWithCurrent<CalendarEntity, EntityState<CalendarAttributes>, CalendarAttributes>();
    }

    public static IObservable<StateChange<CameraEntity, EntityState<CameraAttributes>>> StateAllChangesWithCurrent(this CameraEntity entity)
    {
        return entity.StateAllChangesWithCurrent<CameraEntity, EntityState<CameraAttributes>, CameraAttributes>();
    }

    public static IObservable<StateChange<ClimateEntity, EntityState<ClimateAttributes>>> StateAllChangesWithCurrent(this ClimateEntity entity)
    {
        return entity.StateAllChangesWithCurrent<ClimateEntity, EntityState<ClimateAttributes>, ClimateAttributes>();
    }

    public static IObservable<StateChange<DeviceTrackerEntity, EntityState<DeviceTrackerAttributes>>> StateAllChangesWithCurrent(this DeviceTrackerEntity entity)
    {
        return entity.StateAllChangesWithCurrent<DeviceTrackerEntity, EntityState<DeviceTrackerAttributes>, DeviceTrackerAttributes>();
    }

    public static IObservable<StateChange<FanEntity, EntityState<FanAttributes>>> StateAllChangesWithCurrent(this FanEntity entity)
    {
        return entity.StateAllChangesWithCurrent<FanEntity, EntityState<FanAttributes>, FanAttributes>();
    }

    public static IObservable<StateChange<GroupEntity, EntityState<GroupAttributes>>> StateAllChangesWithCurrent(this GroupEntity entity)
    {
        return entity.StateAllChangesWithCurrent<GroupEntity, EntityState<GroupAttributes>, GroupAttributes>();
    }

    public static IObservable<StateChange<InputBooleanEntity, EntityState<InputBooleanAttributes>>> StateAllChangesWithCurrent(this InputBooleanEntity entity)
    {
        return entity.StateAllChangesWithCurrent<InputBooleanEntity, EntityState<InputBooleanAttributes>, InputBooleanAttributes>();
    }

    public static IObservable<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> StateAllChangesWithCurrent(this InputSelectEntity entity)
    {
        return entity.StateAllChangesWithCurrent<InputSelectEntity, EntityState<InputSelectAttributes>, InputSelectAttributes>();
    }

    public static IObservable<StateChange<LightEntity, EntityState<LightAttributes>>> StateAllChangesWithCurrent(this LightEntity entity)
    {
        return entity.StateAllChangesWithCurrent<LightEntity, EntityState<LightAttributes>, LightAttributes>();
    }

    public static IObservable<StateChange<MediaPlayerEntity, EntityState<MediaPlayerAttributes>>> StateAllChangesWithCurrent(this MediaPlayerEntity entity)
    {
        return entity.StateAllChangesWithCurrent<MediaPlayerEntity, EntityState<MediaPlayerAttributes>, MediaPlayerAttributes>();
    }

    public static IObservable<StateChange<NumberEntity, NumericEntityState<NumberAttributes>>> StateAllChangesWithCurrent(this NumberEntity entity)
    {
        return entity.StateAllChangesWithCurrent<NumberEntity, NumericEntityState<NumberAttributes>, NumberAttributes>();
    }

    public static IObservable<StateChange<NumericSensorEntity, NumericEntityState<NumericSensorAttributes>>> StateAllChangesWithCurrent(this NumericSensorEntity entity)
    {
        return entity.StateAllChangesWithCurrent<NumericSensorEntity, NumericEntityState<NumericSensorAttributes>, NumericSensorAttributes>();
    }

    public static IObservable<StateChange<PersonEntity, EntityState<PersonAttributes>>> StateAllChangesWithCurrent(this PersonEntity entity)
    {
        return entity.StateAllChangesWithCurrent<PersonEntity, EntityState<PersonAttributes>, PersonAttributes>();
    }

    public static IObservable<StateChange<RemoteEntity, EntityState<RemoteAttributes>>> StateAllChangesWithCurrent(this RemoteEntity entity)
    {
        return entity.StateAllChangesWithCurrent<RemoteEntity, EntityState<RemoteAttributes>, RemoteAttributes>();
    }

    public static IObservable<StateChange<SceneEntity, EntityState<SceneAttributes>>> StateAllChangesWithCurrent(this SceneEntity entity)
    {
        return entity.StateAllChangesWithCurrent<SceneEntity, EntityState<SceneAttributes>, SceneAttributes>();
    }

    public static IObservable<StateChange<ScriptEntity, EntityState<ScriptAttributes>>> StateAllChangesWithCurrent(this ScriptEntity entity)
    {
        return entity.StateAllChangesWithCurrent<ScriptEntity, EntityState<ScriptAttributes>, ScriptAttributes>();
    }

    public static IObservable<StateChange<SelectEntity, EntityState<SelectAttributes>>> StateAllChangesWithCurrent(this SelectEntity entity)
    {
        return entity.StateAllChangesWithCurrent<SelectEntity, EntityState<SelectAttributes>, SelectAttributes>();
    }

    public static IObservable<StateChange<SensorEntity, EntityState<SensorAttributes>>> StateAllChangesWithCurrent(this SensorEntity entity)
    {
        return entity.StateAllChangesWithCurrent<SensorEntity, EntityState<SensorAttributes>, SensorAttributes>();
    }

    public static IObservable<StateChange<SunEntity, EntityState<SunAttributes>>> StateAllChangesWithCurrent(this SunEntity entity)
    {
        return entity.StateAllChangesWithCurrent<SunEntity, EntityState<SunAttributes>, SunAttributes>();
    }

    public static IObservable<StateChange<SwitchEntity, EntityState<SwitchAttributes>>> StateAllChangesWithCurrent(this SwitchEntity entity)
    {
        return entity.StateAllChangesWithCurrent<SwitchEntity, EntityState<SwitchAttributes>, SwitchAttributes>();
    }

    public static IObservable<StateChange<UpdateEntity, EntityState<UpdateAttributes>>> StateAllChangesWithCurrent(this UpdateEntity entity)
    {
        return entity.StateAllChangesWithCurrent<UpdateEntity, EntityState<UpdateAttributes>, UpdateAttributes>();
    }

    public static IObservable<StateChange<VacuumEntity, EntityState<VacuumAttributes>>> StateAllChangesWithCurrent(this VacuumEntity entity)
    {
        return entity.StateAllChangesWithCurrent<VacuumEntity, EntityState<VacuumAttributes>, VacuumAttributes>();
    }

    public static IObservable<StateChange<WeatherEntity, EntityState<WeatherAttributes>>> StateAllChangesWithCurrent(this WeatherEntity entity)
    {
        return entity.StateAllChangesWithCurrent<WeatherEntity, EntityState<WeatherAttributes>, WeatherAttributes>();
    }

    public static IObservable<StateChange<ZoneEntity, EntityState<ZoneAttributes>>> StateAllChangesWithCurrent(this ZoneEntity entity)
    {
        return entity.StateAllChangesWithCurrent<ZoneEntity, EntityState<ZoneAttributes>, ZoneAttributes>();
    }   
}