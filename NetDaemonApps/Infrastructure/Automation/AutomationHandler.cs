
namespace NetDaemonApps.Infrastructure.Automation;

internal class AutomationHandler
{
    public AutomationHandler(string id, string? name = null)
    {
        Id = id;
        Name = name ?? id.Prettify();
    }   

    public string Id { get; private set; }
    public string? Name { get; private set; }    

}
