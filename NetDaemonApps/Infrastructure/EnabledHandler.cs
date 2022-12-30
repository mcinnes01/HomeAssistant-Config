namespace NetDaemonApps.Infrastructure;

public abstract class EnabledHandler
{
    private bool isEnabled;
    public bool IsEnabled => isEnabled;   

    public EnabledHandler(Entity entity, InputBooleanEntity enabledToggle)        
    {
        enabledToggle.StateChanges()
           .Where(c => c.New.IsOn())
           .Subscribe(_ => { isEnabled = true; OnEnabled(true); });

        enabledToggle.StateChanges()
            .Where(c => c.New.IsOff())
            .Subscribe(_ => { isEnabled = false; OnEnabled(true); });

        isEnabled = enabledToggle.IsOn();    
    }

    protected virtual void OnEnabled(bool value) { }
}