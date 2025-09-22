namespace NetDaemon.apps.LightApp;

using Humanizer;
using NetDaemon.Extensions.MqttEntityManager;
using NetDaemon.Extensions;
#pragma warning disable CS8618 

public class RoomControl
{
    public required string Name { get; set; }
    public string TitleName => Name.ReplaceLineEndings().Titleize().Trim();
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
    public bool RecreateRoomMode { get; set; } = false;
    public SelectEntity? RoomMode { get; set; }
    public string[] BlockModes { get; set; } = ["Sleeping", "Manual"];
    public string[] KeepAliveModes { get; set; } = ["Relaxing", "Bright"];
    private string _roomModeSelect;
    private IMqttEntityManager _entityManager;
    private IScheduler _scheduler;
    private IHaContext _context;
    private Entities _entities;
    private SelectEntities _selectEntities;
    private SelectEntity? _bedroomMode { get; set; }
    private InputBooleanEntity? _inBedSensor { get; set; }
    private BinarySensorEntity? _bedPresenceSensor { get; set; }
    private InputSelectEntity? _locationMode { get; set; }
    private InputSelectEntity? _timeOfDay { get; set; }
    private ILogger<LightingManager> _logger;
    private bool _inBed => _inBedSensor.IsOn() || _bedPresenceSensor.IsDetected();

    public async Task Register(IMqttEntityManager entityManager, IScheduler scheduler, IHaContext haContext, ILogger<LightingManager> logger)
    {
        _entityManager = entityManager;
        _scheduler = scheduler;
        _context = haContext;
        _entities = new Entities(haContext);
        _selectEntities = new SelectEntities(haContext);
        _logger = logger;

        IlluminanceSensor ??= _entities.Sensor.WeatherStationAmbientLight;
        _bedroomMode = _selectEntities.EnumerateAll().FirstOrDefault(e => e.EntityId == "select.bedroom_mode");
        _inBedSensor = _entities.InputBoolean.InBed;
        _bedPresenceSensor = _entities.BinarySensor.BedroomBedPresence;
        _locationMode = _entities.InputSelect.LocationMode ?? throw new ArgumentNullException("Location Mode Select not found");
        _timeOfDay = _entities.InputSelect.TimeOfDay ?? throw new ArgumentNullException("Time of Day Select not found");

        await SetupRoomModeSelect();
        await SubscribeToTimeOfDayWhenAway();
        await SubscribeToBedroomMode();
        await SubscribeToBedPresence();
    }

    private async Task SetupRoomModeSelect()
    {
        if (string.IsNullOrEmpty(Name))
        {
            _logger.LogError("Room Name is required");
            return;
        }

        var room = $"{Name}_mode";
        _roomModeSelect = RoomMode?.EntityId ?? $"select.{room}";
        var selectName = $"{Name.Replace("_", "").Titleize()} Mode";
        _logger.LogDebug("Setup Room Mode Select {select}", selectName);

        if (_context.Entity(_roomModeSelect) != null && RecreateRoomMode)
        {
            _logger.LogDebug("Remove Room Mode Select {select}", selectName);
            await _entityManager.RemoveAsync(_roomModeSelect);
        }

        if (_context.Entity(_roomModeSelect).State == null)
        {
            _logger.LogDebug("Creating Room Mode Select {select}", selectName);
            var options = EnumExtensions.ToList<RoomModeOptions>();
            if (Name.Equals("lounge"))
                options = EnumExtensions.ToList<LoungeModeOptions>();
            else if (Name.Equals("snug"))
                options = EnumExtensions.ToList<SnugModeOptions>();

            await _entityManager.CreateAsync(_roomModeSelect, new EntityCreationOptions
            {
                Name = selectName,
                DeviceClass = "select"
            },
            new
            {
                options,
                current_option = "Normal"
            }).ConfigureAwait(false);
            RoomMode = new SelectEntity(_context, _roomModeSelect);
            if (_roomModeSelect == "select.bedroom_mode")
            {
                _bedroomMode = RoomMode;
            }   
        }

        if (RoomMode == null)
        {
            _logger.LogError("Room Mode Select not created {select}", selectName);
            return;
        }

        if (RoomMode.State == null)
        {
            _logger.LogDebug("Setting Room Mode Select State {select}", selectName);
            await _entityManager.SetStateAsync(_roomModeSelect, RoomModeOptions.Normal.ToString());
        }
    }

    private async Task SubscribeToTimeOfDayWhenAway()
    {
        _timeOfDay?.StateAllChangesWithCurrent()
            .Where(_ => _locationMode.Away() && RoomMode != null)
            .Subscribe(async change =>
            {
                _logger.LogDebug("Time of Day Changed {old} -> {new}", change.Old?.State, change.New?.State);
                if (change.New.IsOption(TimeOfDayOptions.Night))
                {
                    await _entityManager.SetStateAsync(RoomMode!.EntityId, RoomModeOptions.Sleeping.ToString());
                }
                else if (change.New.IsOption(TimeOfDayOptions.Morning))
                {
                    await _entityManager.SetStateAsync(RoomMode!.EntityId, RoomModeOptions.Normal.ToString());
                }
            });
    }

    private async Task SubscribeToBedroomMode()
    {
        if (_bedroomMode == null)
        {
            _logger.LogError("Bedroom Mode Select not created");
            return;
        }

        _bedroomMode!.StateChanges()
            .Subscribe(async change =>
            {
                _logger.LogDebug("Bedroom Mode Changed {old} -> {new}", change.Old?.State, change.New?.State);
                await BedroomModeLogic(change.New.IsSleeping(), _bedroomMode.AsOption<RoomModeOptions>(), _locationMode.AsOption<LocationModeOptions>());
            });
    }
    
    private async Task SubscribeToBedPresence()
    {
        _inBedSensor!.StateAsBool()
        .Merge(_bedPresenceSensor!.StateAsBool())
        .Throttle(TimeSpan.FromMinutes(10))
        .Subscribe(async inBed =>
        {
            _logger.LogDebug("Bedroom Presence Changed to {inBed}", inBed);
            await BedroomModeLogic(inBed!.Value, _bedroomMode.AsOption<RoomModeOptions>(), _locationMode.AsOption<LocationModeOptions>());
        });
    }

    private async Task SubscribeRoomMode()
    {
        if (_roomModeSelect != "select.test_mode"
            && _roomModeSelect != "select.bedroom_mode"
            && IsBedroom)
        {
            _logger.LogTrace("Setup Room Mode Select Subscriptions {select}", _roomModeSelect);
            RoomMode!.StateChanges()
                .Where(_ => _locationMode?.OneOrBothHome() ?? false)
                .Subscribe(async change =>
                {
                    _logger.LogDebug("Room Mode Changed {old} -> {new}", change.Old?.State, change.New?.State);
                    await BedroomModeLogic(
                        _inBed,
                        change.New?.AsOption<RoomModeOptions>(),
                        _locationMode.AsOption<LocationModeOptions>());
                });
        }
        else
        {
            _logger.LogTrace("Setup Room Mode Select Subscriptions {select}", _roomModeSelect);
            RoomMode!.StateChanges()
                .Subscribe(async change =>
                {
                    _logger.LogDebug("Room Mode Changed {old} -> {new}", change.Old?.State, change.New?.State);
                    if (change.New.IsSleeping())
                    {
                        await BedroomModeLogic(
                        _inBed,
                        change.New?.AsOption<RoomModeOptions>(),
                        _locationMode.AsOption<LocationModeOptions>());
                    }
                    else if (change.New.IsNormal())
                    {
                       await BedroomModeLogic(
                        _inBed,
                        change.New?.AsOption<RoomModeOptions>(),
                        _locationMode.AsOption<LocationModeOptions>());
                    }
                });
        }
    }

// If location mode is guest:
//   - If and room is not called "Bedroom" but is IsBedroom=true and changes to sleeping or bed presence is detected for 10 minutes:
//     - And If Bedroom is already Sleeping, 
//       - And No Room is in mode Partying, then set all other rooms to sleeping.
//       - And a Room is in mode Partying but there has been no presence in the Partying Room for 30 minutes or more, then set all other rooms to sleeping.
//       - If any room is in mode Partying and there has been presence within 30 minutes, then don't change other rooms.
//     - But If Bedroom is not sleeping, don't change other room.
//   - If Bedroom mode changes to sleeping but no other IsBedrooms are sleeping, leave other rooms as normal
// If location mode is house sitter:
//   - As soon as any room that IsBedroom is sleeping or bed presence is detected for 10 minutes and time of day is evening or night set all rooms to sleeping.
//   - As soon as any room that IsBedroom is normal or time of day is morning/day and bed presence is absent for 10 minutes, set all rooms to normal.
// If location mode is one away or home:
//   - If bedroom mode changes to sleeping or the InBed input_boolean is true for 10 minutes, set all other rooms to sleeping.
//   - If bedroom mode changes to normal, set all other rooms to normal.
//\ If location mode is away:
//\   - If time of day is night, set all rooms to sleeping.
//\   - If time of day is morning, set all rooms to normal.

    private async Task BedroomModeLogic(bool inBed, RoomModeOptions? bedroomMode, LocationModeOptions? locationMode)
    {
        switch (locationMode)
        {
            case LocationModeOptions.Guest:
                await HandleGuestMode(bedroomMode?.ToString());
                break;
            case LocationModeOptions.HouseSitter:
                await HandleHouseSitterMode(_timeOfDay?.State);
                break;
            case LocationModeOptions.Home:
            case LocationModeOptions.OneAway:
                if (inBed || _bedPresenceSensor.IsDetected())
                {
                    await HandleHomeOrOneAwayMode(bedroomMode?.ToString());
                }
                else
                {
                    await SubscribeToBedPresence();
                }
                break;
            case LocationModeOptions.Away:
                await HandleAwayMode(_timeOfDay?.State);
                break;
        }
    }   

    private async Task HandleGuestMode(string? newBedroomState)
    {
        var isAnyBedroomSleeping = _selectEntities.EnumerateAll()
            .Where(e => IsBedroom && e.EntityId != "select.bedroom_mode")
            .Any(e => e.State == "Sleeping");

        if (newBedroomState == "Sleeping")
        {
            if (!isAnyBedroomSleeping)
            {
                // Leave other rooms as normal
                return;
            }

            var isAnyRoomPartying = _selectEntities.EnumerateAll()
                .Any(e => e.State == "Partying" 
                  && e.PresenceDetectedWithin(TimeSpan.FromMinutes(30)));

            if (!isAnyRoomPartying)
            {
                await SetAllRoomsToMode("Sleeping");
            }
        }
        else if (isAnyBedroomSleeping)
        {
            var isAnyRoomPartying = _selectEntities.EnumerateAll()
                .Any(e => e.State == "Partying"
                  && e.PresenceDetectedWithin(TimeSpan.FromMinutes(30)));

            if (!isAnyRoomPartying)
            {
                await SetAllRoomsToMode("Sleeping");
            }
        }
    }

    private async Task HandleHouseSitterMode(string? timeOfDay)
    {
        var isAnyBedroomSleeping = _selectEntities.EnumerateAll()
            .Where(e => e.IsBedroom)
            .Any(e => e.State == "Sleeping");

        if (isAnyBedroomSleeping && (timeOfDay == "Evening" || timeOfDay == "Night"))
        {
            await SetAllRoomsToMode("Sleeping");
        }
        else if (!isAnyBedroomSleeping && (timeOfDay == "Morning" || timeOfDay == "Day"))
        {
            await SetAllRoomsToMode("Normal");
        }
    }

    private async Task HandleHomeOrOneAwayMode(string? newBedroomState)
    {
        if (newBedroomState == "Sleeping" || _entities.InputBoolean.InBed?.IsOnFor(TimeSpan.FromMinutes(10)) == true)
        {
            await SetAllRoomsToMode("Sleeping");
        }
        else if (newBedroomState == "Normal")
        {
            await SetAllRoomsToMode("Normal");
        }
    }

    private async Task HandleAwayMode(string? timeOfDay)
    {
        if (timeOfDay == "Night")
        {
            await SetAllRoomsToMode("Sleeping");
        }
        else if (timeOfDay == "Morning")
        {
            await SetAllRoomsToMode("Normal");
        }
    }

    private async Task SetAllRoomsToMode(string mode)
    {
        foreach (var room in _selectEntities.EnumerateAll())
        {
            await _entityManager.SetStateAsync(room.EntityId, mode);
        }
    }
}