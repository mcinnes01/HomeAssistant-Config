using NetDaemon.Extensions.MqttEntityManager;
using System.Threading.Tasks;
using NetDaemon.Extensions;

namespace NetDaemonApps.Infrastructure.Automation;

internal class AutomationEnabledHandler : AutomationHandler, IAsyncInitializable
{
    protected readonly IHaContext haContext;
    protected readonly IMqttEntityManager mqttEntityManager;
    protected SwitchEntity? enabledSwitch;


    public AutomationEnabledHandler(IHaContext haContext, IMqttEntityManager mqttEntityManager, 
        string id, string? name = null) 
        : base(id, name)
    {
        this.haContext = haContext;
        this.mqttEntityManager = mqttEntityManager;

    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        enabledSwitch = await mqttEntityManager.RequiresSwitchAsync(haContext,
            $"switch.{Id}_automation_enabled",
            new EntityCreationOptions()
            {
                Name = $"{this.Name} Automation Enabled",
                Persist = true,                
            });


        enabledSwitch?.WhenOn(_ => OnEnabled(true));
        enabledSwitch?.WhenOff(_ => OnEnabled(false));            
    }

    public bool IsActive
    {
        get => enabledSwitch.IsOn();
        set
        {
            if (value && enabledSwitch.IsOff())            
                enabledSwitch?.TurnOn();
            else if (!value && enabledSwitch.IsOn())
                enabledSwitch?.TurnOff();
        }
    }

    protected virtual void OnEnabled(bool value)
    {

    }



}
