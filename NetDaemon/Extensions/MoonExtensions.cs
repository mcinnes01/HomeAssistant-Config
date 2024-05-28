namespace NetDaemon.Extensions;

//public static class MoonExtensions
//{
//    public static bool IsNewMoon(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "new_moon", StringComparison.OrdinalIgnoreCase);

//    public static bool IsNewMoon(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenNewMoon(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);


//    public static bool IsWaxingCrescent(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "waxing_crescent", StringComparison.OrdinalIgnoreCase);

//    public static bool IsWaxingCrescent(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenWaxingCrescent(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);


//    public static bool IsFirstQuarter(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "first_quarter", StringComparison.OrdinalIgnoreCase);

//    public static bool IsFirstQuarter(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenFirstQuarter(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);

//    public static bool IsWaxingGibbous(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "waxing_gibbous", StringComparison.OrdinalIgnoreCase);

//    public static bool IsWaxingGibbous(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenWaxingGibbous(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);

//    public static bool IsFullMoon(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "full_moon", StringComparison.OrdinalIgnoreCase);

//    public static bool IsFullMoon(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenFullMoon(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);

//    public static bool IsWaningGibbous(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "waning_gibbous", StringComparison.OrdinalIgnoreCase);

//    public static bool IsWaningGibbous(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenWaningGibbous(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);

//    public static bool IsLastQuarter(this EntityState<MoonAttributes>? state)
//       => string.Equals(state?.State, "last_quarter", StringComparison.OrdinalIgnoreCase);

//    public static bool IsLastQuarter(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenLastQuarter(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);

//    public static bool IsWaningCrescent(this EntityState<MoonAttributes>? state)
//        => string.Equals(state?.State, "waning_crescent", StringComparison.OrdinalIgnoreCase);

//    public static bool IsWaningCrescent(this MoonEntity? entity)
//        => entity?.EntityState?.IsNewMoon() ?? false;

//    public static IDisposable WhenWaningCrescent(this MoonEntity entity,
//        Action<StateChange<MoonEntity, EntityState<MoonAttributes>>> action)
//        => entity.StateChanges().Where(e => e.New?.IsNewMoon() ?? false).Subscribe(action);
//}

