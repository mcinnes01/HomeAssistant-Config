namespace NetDaemonApps.Infrastructure;

public abstract class AvailableHandler
{
    private bool isAvailable;
    public bool IsAvailable => isAvailable;
    public Entity Entity { get; }

    public AvailableHandler(Entity entity)
    {
        this.Entity = entity;

        entity.StateChanges()
           .Where(c => c.New.IsUnknown() || c.New.IsUnavailable())
           .Subscribe(_ => { isAvailable = false; OnAvailable(false); });

        entity.StateChanges()
            .Where(c => !c.New.IsUnknown() && !c.New.IsUnavailable() && (c.Old.IsUnavailable() || c.Old.IsUnknown()))
            .Subscribe(_ => { isAvailable = false; OnAvailable(true); });

        isAvailable = !entity.IsUnavailable() && !entity.IsUnknown();
        
    }

    protected virtual void OnAvailable(bool value) { }
}