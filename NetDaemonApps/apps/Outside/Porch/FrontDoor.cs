using System.Reactive.Concurrency;

namespace Outside.Porch;

[NetDaemonApp]
public class FrontDoor
{   
    private readonly ILogger<FrontDoor> _logger;
    private readonly Entities _entities;
    private readonly IScheduler _scheduler;
    
    public FrontDoor(IHaContext ha, ILogger<FrontDoor> logger, IScheduler scheduler)
    {
        _logger = logger;
        _entities = new Entities(ha);
        _scheduler = scheduler;

        // TODO: Doorbell turn hallway light on
        // Perhaps also consider some do not disturb mode
        // TODO: Include door/doorbell to control porch light too
    }

    private void TurnPorchLightOnWhenDarkInTheEvening()
    {
        
    }
}