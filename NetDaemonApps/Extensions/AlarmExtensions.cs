namespace NetDaemonApps.Extensions;


public static class AlarmExtensions
{
    public static bool IsArmedAway(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "armed_away", StringComparison.OrdinalIgnoreCase);

    public static bool IsArmedAway(this AlarmControlPanelEntity? entity) 
        => entity?.EntityState?.IsArmedAway() ?? false;

    public static IDisposable WhenArmedAway(this AlarmControlPanelEntity entity, 
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArmedAway() ?? false).Subscribe(action);

    public static bool IsArmedHome(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "armed_home", StringComparison.OrdinalIgnoreCase);

    public static bool IsArmedHome(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsArmedHome() ?? false;

    public static IDisposable WhenArmedHome(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArmedHome() ?? false).Subscribe(action);

    public static bool IsArmedNight(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "armed_night", StringComparison.OrdinalIgnoreCase);

    public static bool IsArmedNight(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsArmedNight() ?? false;

    public static IDisposable WhenArmedNight(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArmedNight() ?? false).Subscribe(action);

    public static bool IsArmedVacation(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "armed_vacation", StringComparison.OrdinalIgnoreCase);

    public static bool IsArmedVacation(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsArmedVacation() ?? false;

    public static IDisposable WhenArmedVacation(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArmedVacation() ?? false).Subscribe(action);

    public static bool IsArmedCustomBypass(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "armed_custom_bypass", StringComparison.OrdinalIgnoreCase);

    public static bool IsArmedCustomBypass(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsArmedCustomBypass() ?? false;

    public static IDisposable WhenArmedCustomBypass(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArmedCustomBypass() ?? false).Subscribe(action);

    public static bool IsDisarmed(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "disarmed", StringComparison.OrdinalIgnoreCase);

    public static bool IsDisarmed(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsDisarmed() ?? false;

    public static IDisposable WhenDisarmed(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsDisarmed() ?? false).Subscribe(action);

    public static bool IsPending(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "pending", StringComparison.OrdinalIgnoreCase);

    public static bool IsPending(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsPending() ?? false;

    public static IDisposable WhenPending(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsPending() ?? false).Subscribe(action);

    public static bool IsArming(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "arming", StringComparison.OrdinalIgnoreCase);

    public static bool IsArming(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsArming() ?? false;

    public static IDisposable WhenArming(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArming() ?? false).Subscribe(action);

    public static bool IsTriggered(this EntityState<AlarmControlPanelAttributes>? state)
        => string.Equals(state?.State, "triggered", StringComparison.OrdinalIgnoreCase);

    public static bool IsTriggered(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsTriggered() ?? false;

    public static IDisposable WhenTriggered(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsTriggered() ?? false).Subscribe(action);

    public static bool IsArmed(this EntityState<AlarmControlPanelAttributes>? state)
        => (state?.State ?? String.Empty).StartsWith("armed_", StringComparison.OrdinalIgnoreCase);

    public static bool IsArmed(this AlarmControlPanelEntity? entity)
        => entity?.EntityState?.IsArmed() ?? false;

    public static IDisposable WhenArmed(this AlarmControlPanelEntity entity,
        Action<StateChange<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsArmed() ?? false).Subscribe(action);

    
}

