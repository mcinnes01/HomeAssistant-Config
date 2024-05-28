using NetDaemon.NotificationManager;

namespace NetDaemon;

public class ApplianceFactory : IApplianceFactory
{
    private readonly IEntities                     _entities;
    private readonly INotificationConfigFactory    _configFactory;
    private readonly IScheduler                    _scheduler;
    private readonly ILogger<NotificationsManager> _logger;

    public ApplianceFactory(IEntities entities, INotificationConfigFactory configFactory, IScheduler scheduler, ILogger<NotificationsManager> logger)
    {
        _entities = entities;
        _configFactory = configFactory;
        _scheduler     = scheduler;
        _logger        = logger;
    }

    public List<Appliance> CreateAppliances(string[] applianceType)
    {
        return applianceType.Select(CreateAppliance).ToList();
    }

    public Appliance CreateAppliance(string applianceType)
    {
        var config                = _configFactory.CreateConfig(applianceType, _entities);
        var applianceNotification = new ApplianceNotification(_scheduler, config, _logger);
        return new Appliance(config.MotionSensor, applianceNotification, config.MediaPlayer, config.Status , config.Reminder, config.Acknowledge, config.CycleStateHandler);
    }
}