namespace NetDaemon.apps.LightApp;

using NetDaemon.Extensions.MqttEntityManager;
#pragma warning disable CS8618 

public class RoomControl
{
    public required string Name { get; set; }
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
    public InputSelectEntity? RoomMode { get; set; }
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
        _roomModeSelect = RoomMode?.EntityId ?? $"input_select.{room}_mode";
        _logger.LogDebug("{room} Setup Room Mode Select", Name);

        if (_context.Entity(_roomModeSelect) != null && RecreateRoomMode)
        {
            _logger.LogDebug("{room} Remove Room Mode Select", _roomModeSelect);
            await _entityManager.RemoveAsync(_roomModeSelect);
        }
        
        if (_context.Entity(_roomModeSelect).State == null)
        {
            _logger.LogDebug("{room} Creating Room Mode Select", _roomModeSelect);
            await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions
            {
                Name = $"{Name} Mode",
                UniqueId = _roomModeSelect,
                DeviceClass = "input_select",
                Persist = true
            }).ConfigureAwait(false);
            RoomMode = new InputSelectEntity(_context, _roomModeSelect);
        }

        if (RoomMode == null)
        {
            _logger.LogError("{room} Room Mode Select not created", Name);
            return;
        }

        // Load options based on room
        if (IsBedroom)
            RoomMode.SetOptions(EnumExtensions.ToOptions<RoomModeOptions>());
        else if (room.Equals("lounge"))
            RoomMode.SetOptions(EnumExtensions.ToOptions<LoungeModeOptions>());
        else if (room.Equals("snug"))
            RoomMode.SetOptions(EnumExtensions.ToOptions<SnugModeOptions>());
        else
            RoomMode.SetOptions(EnumExtensions.ToOptions<RoomModeOptions>());

        // Set the default value to "Normal"
        RoomMode.SelectOption(RoomModeOptions.Normal);

        if (_roomModeSelect != "input_select.testroom_mode")
        {
            _logger.LogTrace("{room} Setup Room Mode Select Subscriptions", Name);
            // This creates a subscription just to output the state of the entity
            (await _entityManager.PrepareCommandSubscriptionAsync(RoomMode.EntityId)).SubscribeAsync(async s =>
                {
                    _logger.LogDebug("{room} Changing Room Mode", RoomMode.EntityId);
                    await _entityManager.SetStateAsync(RoomMode.EntityId, s);
                    _logger.LogDebug("{room} Changed Room Mode {state}", RoomMode.EntityId, s);
                }
            );
        }
    }
}