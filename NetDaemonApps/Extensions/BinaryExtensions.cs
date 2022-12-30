
namespace NetDaemonApps.Extensions;


public static class BinaryExtensions
{
    public static bool IsLow(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsLow(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenLow(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsNormal(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsNormal(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenNormal(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsCharging(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsCharging(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenCharging(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsNotCharging(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsNotCharging(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenNotCharging(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsDetected(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOn();

    public static bool IsDetected(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenDetected(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsCleared(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsCleared(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenCleared(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsCold(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOn();

    public static bool IsCold(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenCold(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);


    public static bool IsConnected(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsConnected(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenConnected(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsDisconnected(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsDisconnected(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenDisconnected(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);

    public static bool IsOpen(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsOpen(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenOpen(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsClosed(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsClosed(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenClosed(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);



    public static bool IsNotDetected(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsNotDetected(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenNotDetected(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);

    public static bool IsHot(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsHot(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenHot(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsUnlocked(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOn();

    public static bool IsUnlocked(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenUnlocked(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsLocked(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsLocked(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenLocked(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);

    public static bool IsWet(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsWet(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenWet(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsDry(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsDry(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenDry(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);

    public static bool IsMoving(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsMoving(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenMoving(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsStopped(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsStopped(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenStopped(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);

    public static bool IsPluggedIn(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool IsPluggedIn(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenPluggedIn(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsUnplugged(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsUnplugged(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenUnplugged(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);

    public static bool IsNoPower(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsNoPower(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenNoPower(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsHome(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOn();

    public static bool IsHome(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenHome(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsAway(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsAway(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenAway(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsOk(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsOk(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenOk(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsRunning(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOn();

    public static bool IsRunning(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenRunning(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsNotRunning(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsNotRunning(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenNotRunning(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool UpdateAvailable(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOn();

    public static bool UpdateAvailable(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenUpdateAvailable(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsUpToDate(this EntityState<BinarySensorAttributes>? entityState)
        => entityState.IsOff();

    public static bool IsUpToDate(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenUpToDated(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


    public static bool IsSafe(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOn();

    public static bool IsSafe(this BinarySensorEntity? entity) => entity.IsOn();

    public static IDisposable WhenSafe(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOn(action);

    public static bool IsUnsafe(this EntityState<BinarySensorAttributes>? entityState)
       => entityState.IsOff();

    public static bool IsUnsafe(this BinarySensorEntity? entity) => entity.IsOff();

    public static IDisposable WhenUnsafe(this BinarySensorEntity entity,
        Action<StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>>> action)
    => entity.WhenOff(action);


}
