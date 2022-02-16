namespace MotionState;
public class MotionEvent
{
    public MotionEvent(int defaultDelay)
    {
        PreviousDelay = defaultDelay * 1.0;
        BackoffCount = 0;
        StartTime = DateTime.Now;
        EndTime = StartTime.AddSeconds(PreviousDelay);
    }

    public int BackoffCount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double PreviousDelay { get; set; }
}

public class MotionStateItem
{
    public MotionStateItem(string name, BinarySensorEntity entity, 
        int defaultDurationSeconds = 60, int maxBackoff = 300, double backoffFactor = 1.0)
    {
        Name = name;
        Entity = entity;
        DefaultDurationSeconds = defaultDurationSeconds;
        MaxBackoff = maxBackoff;
        BackoffFactor = backoffFactor;
        Event = new MotionEvent(DefaultDurationSeconds);
    }

    public string Name { get; set; }
    public BinarySensorEntity Entity { get; set; }
    public int DefaultDurationSeconds { get; set; }
    public int MaxBackoff { get; set; }
    public double BackoffFactor { get; set; }
    public MotionEvent Event { get; set; }
}