namespace Helpers.Extensions;
public static class SchedulerExtensions
{        
    public static void RunDaily(this INetDaemonScheduler scheduler, TimeOnly timeOfDay, Action action)
    {
        var startTime = DateOnly.FromDateTime(scheduler.Now.Date).ToDateTime(timeOfDay);
        if (startTime < scheduler.Now.LocalDateTime) startTime = startTime.AddDays(1);

        scheduler.RunEvery(TimeSpan.FromDays(1), startTime, action);
    }
}