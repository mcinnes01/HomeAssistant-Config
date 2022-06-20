namespace Helpers.Extensions;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
public static class SchedulerExtensions
{
    public static void RunDaily(this INetDaemonScheduler scheduler, TimeSpan timeOfDay, Action action)
    {
        var startTime = scheduler.Now.Date.Add(timeOfDay);
        if (startTime < scheduler.Now) startTime = startTime.AddDays(1);

        scheduler.RunEvery(TimeSpan.FromDays(1), startTime, action);
    }
        
    public static void RunDaily(this INetDaemonScheduler scheduler, TimeOnly timeOfDay, Action action)
    {
        var startTime = DateOnly.FromDateTime(scheduler.Now.Date).ToDateTime(timeOfDay);
        if (startTime < scheduler.Now.LocalDateTime) startTime = startTime.AddDays(1);

        scheduler.RunEvery(TimeSpan.FromDays(1), startTime, action);
    }

    public static void ExtendableTimer(this IScheduler scheduler, TimeSpan timeOfDay, Action action, double exponentialFactor)
    {
        var resetSignal = new Subject<Unit>(); 
        var startTime = scheduler.Now.Date.Add(timeOfDay);
        if (startTime < scheduler.Now) startTime = startTime.AddDays(1);

        resetSignal
            .StartWith(Unit.Default)
            .Select(_ => Observable.Timer(startTime))
            .Switch()
            .ObserveOn(scheduler)
            .Subscribe(_ => action());
    }

    public static void Delay<T>(this IObservable<T> source, TimeSpan delay)
    {

    }
}