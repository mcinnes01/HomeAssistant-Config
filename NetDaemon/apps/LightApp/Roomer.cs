namespace NetDaemon.apps.LightApp;

using NetDaemon.Extensions.MqttEntityManager;
#pragma warning disable CS8618 

public class Roomer
{
    public required string Name { get; set; }
    public bool IsBedroom { get; set; } = false;
    public required IEnumerable<Lighter> Lights { get; set; }
    public required IEnumerable<BinarySensorEntity> PresenceSensors { get; set; }
    public required IEnumerable<BinarySensorEntity> TriggerSensors { get; set; }
    public bool RecreateRoomMode { get; set; } = false;
    private InputSelectEntity? RoomMode { get; set; }
    private string _roomModeSelect;
    private IMqttEntityManager _entityManager;
    private IScheduler _scheduler;
    private IHaContext _context;
    private ILogger<Lighting> _logger;
   
    public async Task Register(IMqttEntityManager entityManager, IScheduler scheduler, IHaContext haContext, ILogger<Lighting> logger)
    {
        _entityManager = entityManager;
        _scheduler = scheduler;
        _context = haContext;
        _logger = logger;

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
        _roomModeSelect = RoomMode?.EntityId ?? $"input_select.light_manager_{room}_mode";
        _logger.LogDebug("{room} Setup Room Mode Select", Name);

        if (_context.Entity(_roomModeSelect).State != null && RecreateRoomMode)
        {
            _logger.LogDebug("{room} Removing Room Mode Select", _roomModeSelect);
            await _entityManager.RemoveAsync(_roomModeSelect);
        }
        
        if (_context.Entity(_roomModeSelect).State == null)
        {
            // Create the input_select entity
            await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions(Name: $"{Name} Mode", DeviceClass: "input_select", Persist: true));
            RoomMode = new InputSelectEntity(_context, _roomModeSelect);
        }

        if (RoomMode == null)
        {
            _logger.LogError("{room} Room Mode Select not created", Name);
            return;
        }

        // Set the options for the input_select entity
        if (IsBedroom)
            RoomMode.SetOptions(EnumExtensions.ToOptions<BedroomModeOptions>());
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