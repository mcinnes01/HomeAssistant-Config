using System.Threading.Tasks;
using CacheManager.Core;

namespace MotionState;

public interface IMotionStateService
{
    IObservable<long> GetTimer(MotionStateItem motionState, 
        StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>> state);
}

public class MotionStateService : IMotionStateService
{
    private readonly ICacheManager<MotionStateItem> _motionStateCache;

    public MotionStateService(ICacheManager<MotionStateItem> motionStateCache)
    {
        _motionStateCache = motionStateCache;
    }

    public IObservable<long> GetTimer(MotionStateItem motionState, StateChange<BinarySensorEntity, EntityState<BinarySensorAttributes>> state)
    {
        throw new NotImplementedException();
        // var cacheItem = _motionStateCache.Get(motionState.Name);
        // if (cacheItem == null)
        // {
        //     StartTimer(motionState);
        //     _motionStateCache.Add(motionState.Name, motionState);
        // }
        // else 
        // {
        //     motionState.Event = cacheItem.Event;
        //     StartTimer(motionState);
        // }
        // if (motionState.Event.EndTime < DateTime.Now)
        // {
        //     CancelTimer(motionState.Event);
        //     return TimeSpan.MinValue.TotalSeconds;
        // }
        // return motionState.Event.EndTime.Subtract(DateTime.Now);
    }

    private void StartTimer(MotionStateItem motionState)
    {
        if (motionState.Event.BackoffCount == 0)
        {
            motionState.Event.PreviousDelay = motionState.DefaultDurationSeconds;
            motionState.Event.BackoffCount++;
        }
        else
        {
            motionState.Event.PreviousDelay = Math.Round(motionState.Event.BackoffCount * motionState.BackoffFactor, 2);
            if (motionState.Event.PreviousDelay > motionState.MaxBackoff)
            {
                motionState.Event.PreviousDelay = motionState.MaxBackoff;
            }
        }
    }

    private void CancelTimer(MotionEvent motionEvent)
    {
        // TODO: This needs to tie the cache item together with the
        // Observable.Timer for the throttle and we perhaps need some
        // intermediary to handle tracking and calling the cancellation
        // token on Reactive state.
    }

    private void ResetTimer(MotionEvent motionEvent)
    {

    }

    private void TimerExpire(MotionEvent motionEvent)
    {

    }
}