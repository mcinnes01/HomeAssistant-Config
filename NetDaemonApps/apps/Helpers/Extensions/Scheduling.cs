namespace Helpers.Extensions;
public static class SchedulerExtensions
{
    public static void RunDaily(this INetDaemonScheduler scheduler, TimeOnly timeOfDay, Action action)
    {
        var startTime = DateOnly.FromDateTime(scheduler.Now.Date).ToDateTime(timeOfDay);
        if (startTime < scheduler.Now.LocalDateTime) startTime = startTime.AddDays(1);

        scheduler.RunEvery(TimeSpan.FromDays(1), startTime, action);
    }

    public static void RunWeekDays(this INetDaemonScheduler scheduler, TimeOnly timeOfDay, Action action)
    {
        var startTime = DateOnly.FromDateTime(scheduler.Now.Date).ToDateTime(timeOfDay);
        if (startTime < scheduler.Now.LocalDateTime) startTime = startTime.AddDays(1);

        scheduler.RunEvery(TimeSpan.FromDays(1), startTime, () =>
        {
            if (Constants.WeekdayNightDays.Contains(DateTime.Now.DayOfWeek))
            {
                action.Invoke();
            }
        });
    }

    public static void RunWeekends(this INetDaemonScheduler scheduler, TimeOnly timeOfDay, Action action)
    {
        var startTime = DateOnly.FromDateTime(scheduler.Now.Date).ToDateTime(timeOfDay);
        if (startTime < scheduler.Now.LocalDateTime) startTime = startTime.AddDays(1);

        scheduler.RunEvery(TimeSpan.FromDays(1), startTime, () =>
        {
            if (Constants.WeekendNightDays.Contains(DateTime.Now.DayOfWeek))
            {
                action.Invoke();
            }
        });
    }
}