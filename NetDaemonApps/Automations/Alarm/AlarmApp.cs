namespace NetDaemonApps.Automations.States;

[NetDaemonApp]
public class AlarmAppController
{
    private readonly ILogger<AlarmAppController> _logger;
    private readonly IEntities _entities;
    private readonly IAlexa _alexa;
    InputBooleanEntity? IsEnabled;

    public AlarmAppController(IHaContext context, IAlexa alexa, ILogger<AlarmAppController> logger)
    {
        _logger = logger;
        _entities = new Entities(context);
        _alexa = alexa;
        var alarmo = _entities.AlarmControlPanel.Alarmo;
        var persistentNotification = new PersistentNotificationServices(context);

        alarmo.WhenArmed(a =>
        {
            _logger.LogInformation("Alarm Armed!");
            persistentNotification.Create("Alarm Armed!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "The alarm is armed.");
        });

        alarmo.WhenArmedAway(a =>
        {
            _logger.LogInformation("Alarm Armed Away!");
            persistentNotification.Create("Alarm Armed Away!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm Armed Away!");
        });

        alarmo.WhenArmedCustomBypass(a =>
        {
            _logger.LogInformation("Alarm Armed Guest Night!");
            persistentNotification.Create("Alarm Armed Guest Night!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm Armed Guest Night!");
        });

        alarmo.WhenArmedHome(a =>
        {
            _logger.LogInformation("Alarm Armed Home!");
            persistentNotification.Create("Alarm Armed Home!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm Armed Home!");
        });

        alarmo.WhenArmedNight(a =>
        {
            _logger.LogInformation("Alarm Armed Night!");
            persistentNotification.Create("Alarm Armed Night!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm Armed Night!");
        });

        alarmo.WhenArmedVacation(a =>
        {
            _logger.LogInformation("Alarm Armed Vacation!");
            persistentNotification.Create("Alarm Armed Vacation!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm Armed Vacation!");
        });

        alarmo.WhenArming(a =>
        {
            _logger.LogInformation("Alarm Arming");
            persistentNotification.Create("Alarm Arming");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm is arming.");
        });

        alarmo.WhenDisarmed(a =>
        {
            _logger.LogInformation("Alarm Disarmed");
            persistentNotification.Create("Alarm Disarmed");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Alarm disarmed.");
        });

        alarmo.WhenPending(a =>
        {
            _logger.LogInformation("Alarm Pending!");
            persistentNotification.Create("Alarm Pending!");
        });

        alarmo.WhenTriggered(a =>
        {
            _logger.LogInformation("Alarm Triggered! By Sensors: {@Sensors}", a.New?.Attributes?.OpenSensors);
            persistentNotification.Create("Alarm Triggered!");
            _alexa.Announce(_entities.MediaPlayer.AllSpeakers.EntityId, "Get out me chuffing house you thieving scumbag, I tell thee I'll have your no good, two bit, lilly liver guts for garters!");
        });
    }
}