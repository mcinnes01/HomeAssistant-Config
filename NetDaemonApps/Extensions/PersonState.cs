namespace NetDaemonApps.PersonState
{

    public static class PersonStateExtensions
    {
        public static bool IsHome(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "home", StringComparison.OrdinalIgnoreCase);

        public static bool IsHome(this InputSelectEntity? entity)
                => entity?.EntityState?.IsHome() ?? false;

        public static IDisposable WhenHome(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsHome() ?? false).Subscribe(action);

        public static bool IsAway(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "away", StringComparison.OrdinalIgnoreCase);

        public static bool IsAway(this InputSelectEntity? entity)
                => entity?.EntityState?.IsAway() ?? false;

        public static IDisposable WhenAway(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsAway() ?? false).Subscribe(action);

        public static bool IsAtWork(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "at_work", StringComparison.OrdinalIgnoreCase);

        public static bool IsAtWork(this InputSelectEntity? entity)
                => entity?.EntityState?.IsAtWork() ?? false;


        public static IDisposable WhenAtWork(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsAtWork() ?? false).Subscribe(action);

        public static bool IsAtSchool(this EntityState<InputSelectAttributes>? state)
               => string.Equals(state?.State, "at_school", StringComparison.OrdinalIgnoreCase);

        public static bool IsAtSchool(this InputSelectEntity? entity)
                => entity?.EntityState?.IsAtSchool() ?? false;


        public static IDisposable WhenAtSchool(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsAtSchool() ?? false).Subscribe(action);

        public static bool IsAsleep(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "asleep", StringComparison.OrdinalIgnoreCase);

        public static bool IsAsleep(this InputSelectEntity? entity)
                => entity?.EntityState?.IsAsleep() ?? false;

        public static IDisposable WhenAsleep(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsAsleep() ?? false).Subscribe(action);

        public static bool IsJustArrived(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "just_arrived", StringComparison.OrdinalIgnoreCase);

        public static bool IsJustArrived(this InputSelectEntity? entity)
                => entity?.EntityState?.IsJustArrived() ?? false;

        public static IDisposable WhenJustArrived(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsJustArrived() ?? false).Subscribe(action);

        public static bool IsJustLeft(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "just_left", StringComparison.OrdinalIgnoreCase);

        public static bool IsJustLeft(this InputSelectEntity? entity)
                => entity?.EntityState?.IsJustLeft() ?? false;

        public static IDisposable WhenIsJustLeft(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsJustLeft() ?? false).Subscribe(action);

        public static bool IsOnVacation(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "on_vacation", StringComparison.OrdinalIgnoreCase);

        public static bool IsOnVacation(this InputSelectEntity? entity)
                => entity?.EntityState?.IsOnVacation() ?? false;

        public static IDisposable WhenOnVacation(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsOnVacation() ?? false).Subscribe(action);


        public static bool IsComing(this EntityState<InputSelectAttributes>? state)
                => string.Equals(state?.State, "coming", StringComparison.OrdinalIgnoreCase);

        public static bool IsComing(this InputSelectEntity? entity)
                => entity?.EntityState?.IsComing() ?? false;

        public static IDisposable WhenComing(this InputSelectEntity entity,
            Action<StateChange<InputSelectEntity, EntityState<InputSelectAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsComing() ?? false).Subscribe(action);


    }
}

