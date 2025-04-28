namespace NetDaemon.apps.LightApp;

using Humanizer;
using NetDaemon.Extensions.MqttEntityManager;
#pragma warning disable CS8618 

public class RoomControl
{
    public required string Name { get; set; }
    public string TitleName => Name.ReplaceLineEndings().Titleize();
    public bool IsBedroom { get; set; } = false;
    public bool IsEntrance { get; set; } = false;
    public required IEnumerable<LightControl> Lights { get; set; }
    public bool HasMultipleLights => Lights.Count() > 1;
    public required IEnumerable<BinarySensorEntity> PresenceSensors { get; set; }
    public required IEnumerable<BinarySensorEntity> TriggerSensors { get; set; }
    public NumericSensorEntity? IlluminanceSensor { get; set; }
    public bool IgnoreIlluminance { get; set; } = false;
    public double? IlluminanceLowThreshold { get; set; } = 40.0;
    public double? IlluminanceHighThreshold { get; set; } = 100.0;
    public bool IsBright => !IgnoreIlluminance && IlluminanceSensor?.State > IlluminanceHighThreshold;
    public bool RecreateRoomMode { get; set; } = true;
    public SelectEntity? RoomMode { get; set; }
    public string[] BlockModes { get; set; } = ["Sleeping", "Manual"];
    public string[] KeepAliveModes { get; set; } = ["Relaxing", "Bright"];
    private string _roomModeSelect;
    private IMqttEntityManager _entityManager;
    private IScheduler _scheduler;
    private IHaContext _context;
    private Entities _entities;
    private ILogger<LightingManager> _logger;
   
    public async Task Register(IMqttEntityManager entityManager, IScheduler scheduler, IHaContext haContext, ILogger<LightingManager> logger)
    {
        _entityManager = entityManager;
        _scheduler = scheduler;
        _context = haContext;
        _entities = new Entities(haContext);
        _logger = logger;

        IlluminanceSensor ??= _entities.Sensor.WeatherStationAmbientLight;
        
        await SetupRoomModeSelect();
    }

    private async Task SetupRoomModeSelect()
    {
        if (string.IsNullOrEmpty(Name))
        {
            _logger.LogError("Room Name is required");
            return;
        }

        var room = Name.ToLower().ReplaceLineEndings("").Replace(" ", "_");
        _roomModeSelect = RoomMode?.EntityId ?? $"select.{room}_mode";
        _logger.LogDebug("Setup Room Mode Select {select}", TitleName);

        if (_context.Entity(_roomModeSelect) != null && RecreateRoomMode)
        {
            _logger.LogDebug("Remove Room Mode Select {select}", _roomModeSelect);
            await _entityManager.RemoveAsync(_roomModeSelect);
        }
        
        if (_context.Entity(_roomModeSelect).State == null)
        {
            _logger.LogDebug("Creating Room Mode Select {select}", _roomModeSelect);
            var options = EnumExtensions.ToList<RoomModeOptions>();
            if (room.Equals("lounge"))
                options = EnumExtensions.ToList<LoungeModeOptions>();
            else if (room.Equals("snug"))
                options = EnumExtensions.ToList<SnugModeOptions>();

            await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions
            {
                Name = $"{TitleName} Mode",
                UniqueId = _roomModeSelect,
                DeviceClass = "select",
                Persist = true
            },
            new
            {
                options,
                current_option = "Normal"
            }).ConfigureAwait(false);
            RoomMode = new SelectEntity(_context, _roomModeSelect);
        }

        if (RoomMode == null)
        {
            _logger.LogError("Room Mode Select not created {select}", TitleName);
            return;
        }

        if (RoomMode.State == null)
        {
            _logger.LogDebug("Setting Room Mode Select State {select}", TitleName);
            await _entityManager.SetStateAsync(_roomModeSelect, "Normal");
        }

        if (_roomModeSelect != "select.testroom_mode")
        {
            _logger.LogTrace("Setup Room Mode Select Subscriptions {select}", TitleName);
            // This creates a subscription just to output the state of the entity
            (await _entityManager.PrepareCommandSubscriptionAsync(RoomMode.EntityId)).SubscribeAsync(async s =>
                {
                    _logger.LogDebug("Changing Room Mode {select}", TitleName);
                    await _entityManager.SetStateAsync(RoomMode.EntityId, s);
                    _logger.LogDebug("{select} Changed Room Mode {state}", TitleName, s);
                }
            );
        }
    }
}