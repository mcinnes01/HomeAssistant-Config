namespace NetDaemon.Extensions;

public static class SunExtensions
{
    public static bool IsAboveHorizon(this EntityState<SunAttributes>? state)
        => string.Equals(state?.State, "above_horizon", StringComparison.OrdinalIgnoreCase);

    public static bool IsAboveHorizon(this SunEntity? entity)
        => entity?.EntityState?.IsAboveHorizon() ?? false;

    public static bool IsRising(this SunEntity? entity)
        => entity?.EntityState?.Attributes?.Rising ?? false;

    public static bool IsSetting(this SunEntity? entity)
        => !IsRising(entity);

    public static IDisposable WhenAboveHorizon(this SunEntity entity,
        Action<StateChange<SunEntity, EntityState<SunAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsAboveHorizon() ?? false).Subscribe(action);

    public static bool IsBelowHorizon(this EntityState<SunAttributes>? state)
        => string.Equals(state?.State, "below_horizon", StringComparison.OrdinalIgnoreCase);

    public static bool IsBelowHorizon(this SunEntity? entity)
        => entity?.EntityState?.IsBelowHorizon() ?? false;

    public static IDisposable WhenBelowHorizon(this SunEntity entity,
        Action<StateChange<SunEntity, EntityState<SunAttributes>>> action)
        => entity.StateChanges().Where(e => e.New?.IsBelowHorizon() ?? false).Subscribe(action);

    public static TimeSpan NextMorning(this SunEntity? entity)
    {
        //TODO: Just make sure the retrigger doesn't do the same day
        if (DateTime.TryParse(entity?.Attributes?.NextDawn, out DateTime nextDawn)
            && nextDawn >= DateTime.Now
            && TimeOnly.FromDateTime(nextDawn) < Constants.MORNING_END
            && TimeOnly.FromDateTime(nextDawn) > Constants.MORNING_START)
        {
            return TimeOnly.FromDateTime(nextDawn).ToTimeSpan();
        }
        return Constants.WeekendNightDays.Contains(DateTime.Now.DayOfWeek) ?
            Constants.MORNINGTIME_WEEKENDS.ToTimeSpan() :
            Constants.MORNINGTIME_WEEKDAYS.ToTimeSpan();
    }

    public static TimeSpan NextNoon(this SunEntity? entity)
    {
        if (DateTime.TryParse(entity?.Attributes?.NextNoon, out DateTime nextNoon)
            && nextNoon >= DateTime.Now)
        {
            return TimeOnly.FromDateTime(nextNoon).ToTimeSpan();
        }
        return Constants.AFTERNOONTIME.ToTimeSpan();
    }

    public static TimeSpan NextEvening(this SunEntity? entity)
    {
        if (DateTime.TryParse(entity?.Attributes?.NextSetting, out DateTime nextSetting)
            && nextSetting >= DateTime.Now)
        {
            var nextSettingTime = TimeOnly.FromDateTime(nextSetting);
            return nextSettingTime < Constants.EVENING_END ?
                nextSettingTime > Constants.EVENING_START ?
                    nextSettingTime.ToTimeSpan() :
                    Constants.EVENING_START.ToTimeSpan() :
                Constants.EVENING_END.ToTimeSpan();
        }
        return Constants.EVENINGTIME.ToTimeSpan();
    }

    public static TimeSpan NextNight(this SunEntity? entity)
    {
        //TODO: Just make sure the retrigger doesn't do the same day
        if (DateTime.TryParse(entity?.Attributes?.NextDusk, out DateTime nextDusk)
            && nextDusk >= DateTime.Now
            && TimeOnly.FromDateTime(nextDusk) < Constants.NIGHT_END
            && TimeOnly.FromDateTime(nextDusk) > Constants.NIGHT_START)
        {
            return TimeOnly.FromDateTime(nextDusk).ToTimeSpan();
        }
        return Constants.WeekendNightDays.Contains(DateTime.Now.DayOfWeek) ?
            Constants.NIGHTTIME_WEEKENDS.ToTimeSpan() :
            Constants.NIGHTTIME_WEEKDAYS.ToTimeSpan();
    }

    public static bool IsToday(this DateTime sunEvent)
    {
        return sunEvent.Day == DateTime.Today.Day;
    }
}