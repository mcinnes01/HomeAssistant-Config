using NetDaemon.Helpers.Notifications;

namespace NetDaemon.apps.NotificationsManager;

[NetDaemonApp]
//[Focus]
public class BatteryNotifications(IEntities entities, IServices services, IHaContext context, IScheduler scheduler, IAlexa alexa, ILogger<BatteryNotifications> logger) : IAsyncInitializable
{
    private readonly IList<BatteryNotificationsConfig> _config = new List<BatteryNotificationsConfig>
    {
        new(entities.Sensor.ClairesIphoneBatteryLevel, entities.Sensor.ClairesIphoneBatteryState, "mobile_app_claireiphone"),
        new(entities.Sensor.ClairesAppleWatchBattery, entities.Sensor.ClairesIphoneBatteryState, "mobile_app_claireiphone"),
        new(entities.Sensor.Pixel6BatteryLevel2, entities.Sensor.Pixel6BatteryState2, "mobile_app_pixel_6"),
        new(entities.Sensor.PixelWatchBatteryLevel, entities.Sensor.PixelWatchBatteryState, "mobile_app_pixel_6")
    };


    public Task InitializeAsync(CancellationToken cancellationToken)
    {
        scheduler.ScheduleCron("0 8-19 * * *", SendNotifications);
        return Task.CompletedTask;
    }

    private List<string> CheckBatteryLevel()
    {
        var deviceNames = new List<string>();
        foreach (var config in _config)
        {
            var deviceName = config.BatteryLevel.Attributes.FriendlyName.Replace(" Battery Level", "");
            if (config.BatteryState.State == "Charging") continue;

            switch (config.BatteryLevel.State)
            {
                case <= 30:
                    deviceNames.Add(deviceName);
                    break;
            }
        }

        return deviceNames;
    }

    private List<string> CheckLastUpdated()
    {
        var deviceNames = new List<string>();
        foreach (var config in _config)
        {
            var totalHours = (DateTime.Now - config.BatteryLevel.EntityState.LastUpdated.Value).TotalHours;
            if (totalHours < 12)
            {
                ForceUpdate(config.MobileApp);
                return [];
            }

            var deviceName = config.BatteryLevel.Attributes.FriendlyName.Replace(" Battery Level", "");
            deviceNames.Add(deviceName);
            break;
        }

        return deviceNames;
    }

    private void SendNotifications()
    {
        var deviceNamesFromBatteryCheck = CheckBatteryLevel();
        var deviceNamesFromLastUpdatedCheck = CheckLastUpdated().Except(deviceNamesFromBatteryCheck).ToList();

        if (deviceNamesFromBatteryCheck.Count != 0)
        {
            var batteryCheckMessage = $"{string.Join(" and ", deviceNamesFromBatteryCheck)} needs charging";
            alexa.Announce(entities.MediaPlayer.AllSpeakers.EntityId, batteryCheckMessage);
        }

        if (deviceNamesFromLastUpdatedCheck.Count != 0)
        {
            var lastUpdateCheckMessage = $"{string.Join(" and ", deviceNamesFromLastUpdatedCheck)} has not been seen";
            alexa.Announce(entities.MediaPlayer.AllSpeakers.EntityId, lastUpdateCheckMessage);
        }
    }

    private void ForceUpdate(string mobileApp)
    {
        context.CallService("notify", mobileApp, null, new { Message = "request_location_update" });
    }
}