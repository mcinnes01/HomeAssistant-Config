namespace NetDaemon.Extensions;

public static class ClimateExtensions
{
    public static bool IsOnAuto(this EntityState<ClimateAttributes>? state)
        => string.Equals(state?.State, "auto", StringComparison.OrdinalIgnoreCase);

    public static bool IsOnAuto(this ClimateEntity? entity) 
        => entity?.EntityState?.IsOnAuto() ?? false;

    public static IDisposable WhenOnAuto(this ClimateEntity entity, 
        Action<StateChange<ClimateEntity, EntityState<ClimateAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsOnAuto() ?? false).Subscribe(action);

    public static bool IsOnCool(this EntityState<ClimateAttributes>? state)
        => string.Equals(state?.State, "cool", StringComparison.OrdinalIgnoreCase);

    public static bool IsOnCool(this ClimateEntity? entity)
        => entity?.EntityState?.IsOnCool() ?? false;

    public static IDisposable WhenOnCool(this ClimateEntity entity,
        Action<StateChange<ClimateEntity, EntityState<ClimateAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsOnCool() ?? false).Subscribe(action);

    public static bool IsOnDry(this EntityState<ClimateAttributes>? state)
        => string.Equals(state?.State, "dry", StringComparison.OrdinalIgnoreCase);

    public static bool IsOnDry(this ClimateEntity? entity)
        => entity?.EntityState?.IsOnDry() ?? false;

    public static IDisposable WhenOnDry(this ClimateEntity entity,
        Action<StateChange<ClimateEntity, EntityState<ClimateAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsOnDry() ?? false).Subscribe(action);

    public static bool IsOnFanOnly(this EntityState<ClimateAttributes>? state)
        => string.Equals(state?.State, "fan_only", StringComparison.OrdinalIgnoreCase);

    public static bool IsOnFanOnly(this ClimateEntity? entity)
        => entity?.EntityState?.IsOnFanOnly() ?? false;

    public static IDisposable WhenOnFanOnly(this ClimateEntity entity,
        Action<StateChange<ClimateEntity, EntityState<ClimateAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsOnFanOnly() ?? false).Subscribe(action);

    public static bool IsOnHeat(this EntityState<ClimateAttributes>? state)
        => string.Equals(state?.State, "heat", StringComparison.OrdinalIgnoreCase);

    public static bool IsOnHeat(this ClimateEntity? entity)
        => entity?.EntityState?.IsOnHeat() ?? false;

    public static IDisposable WhenOnHeat(this ClimateEntity entity,
        Action<StateChange<ClimateEntity, EntityState<ClimateAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsOnHeat() ?? false).Subscribe(action);


    public static double? GetCurrentTemperature(this EntityState<ClimateAttributes>? state)
        => state?.Attributes?.CurrentTemperature;

    public static double? GetCurrentTemperature(this ClimateEntity entity)
        => entity.EntityState.GetCurrentTemperature();

    public static double? GetTemperature(this EntityState<ClimateAttributes>? state)
        => state?.Attributes?.Temperature;

    public static double? GetTemperature(this ClimateEntity entity)
        => entity.EntityState.GetTemperature();


}

