namespace StartupEvents;

//[NetDaemonApp]
public class SetCurrentModes
{
    private readonly IHaContext _haContext;
    private readonly INetDaemonScheduler _scheduler;
    private readonly ILogger<HouseStateManager> _log;
    private readonly Entities _entities;

    public SetCurrentModes(IHaContext ha, INetDaemonScheduler scheduler, ILogger<HouseStateManager> logger)
    {
        _haContext = ha;
        _scheduler = scheduler;
        _log = logger;
        _entities = new Entities(ha);
        
        InitHouseStateTimeOfDay();
        InitHouseStateModes();
    }

    private void InitHouseStateTimeOfDay()
    {
        _log.LogTrace("InitHouseStateTimeOfDay");
        if (TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.NIGHT_START, Constants.NIGHT_END)
            && _entities.InputSelect.TimeOfDay.IsNotOption(TimeOfDayOptions.Night))
        {
            _log.LogTrace("Setting time of day to Night");
            _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Night);
        }
        else if (TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.NIGHT_END, Constants.MORNING_END)
            && _entities.InputSelect.TimeOfDay.IsNotOption(TimeOfDayOptions.Morning))
        {
            _log.LogTrace("Setting time of day to Morning");
            _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Morning);
        }
        else if (TimeOnly.FromDateTime(DateTime.Now).IsBetween(Constants.MORNING_END, Constants.NIGHT_START)
            && _entities.Sun.Sun.State == "above_horizon"
            && _entities.InputSelect.TimeOfDay.IsNotOption(TimeOfDayOptions.Day))
        {
            _log.LogTrace("Setting time of day to Day");
            _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Day);
        }
        else if (_entities.InputSelect.TimeOfDay.IsNotOption(TimeOfDayOptions.Evening))
        {
            _log.LogTrace("Setting time of day to Evening");
            _entities.InputSelect.TimeOfDay.SelectOption(TimeOfDayOptions.Evening);
        }
    }

    private void InitHouseStateModes()
    {
        _log.LogTrace("InitHouseStateModes");
        if (_entities.InputBoolean.InBed.IsOn() && _entities.InputSelect.TimeOfDay.IsOption(TimeOfDayOptions.Night))
        {
            _entities.InputSelect.LightControlMode.SelectOption(LightControlModeOptions.Sleeping);
            _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Sleeping);
            _entities.InputSelect.LoungeMode.SelectOption(LoungeModeOptions.Normal);
            _entities.InputSelect.SnugMode.SelectOption(SnugModeOptions.Normal);
            _log.LogTrace("In bed and night so Setting control and bedroom mode to Sleeping and other rooms to Normal.");
        }
        else 
        {
            _entities.InputSelect.LightControlMode.SelectOption(LightControlModeOptions.Motion);
            _entities.InputSelect.BedroomMode.SelectOption(BedroomModeOptions.Normal);
            _log.LogTrace("Not in bed so Setting control to Motion and bedroom mode to Normal.");
        }
    }
}