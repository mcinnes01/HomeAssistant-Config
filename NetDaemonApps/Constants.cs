public static class Constants
{
    public const double DARK_THRESHOLD = 30.0;
    public const double BRIGHT_THRESHOLD = 480.0;
    public static TimeOnly PORCH_LIGHT_OFF_TIME = new TimeOnly(23, 0);
    public static TimeOnly MORNING_START = new TimeOnly(6, 0);
    public static TimeOnly MORNING_END = new TimeOnly(9, 59, 59);
    public static TimeOnly MORNINGTIME_WEEKDAYS = new TimeOnly(7, 30);
    public static TimeOnly MORNINGTIME_WEEKENDS = new TimeOnly(8, 30);
    public static TimeOnly DAYTIME = new TimeOnly(10, 0);
    public static TimeOnly AFTERNOONTIME = new TimeOnly(12, 0);
    public static TimeOnly BACK_IN_SHADOW = new TimeOnly(13, 0);
    public static TimeOnly EVENING_START = new TimeOnly(16, 0);
    public static TimeOnly EVENING_END = new TimeOnly(19, 59, 59);
    public static TimeOnly EVENINGTIME = new TimeOnly(18, 0);
    public static TimeOnly NIGHT_START = new TimeOnly(20, 0);
    public static TimeOnly NIGHT_END = new TimeOnly(4, 0);
    public static TimeOnly NIGHTTIME_WEEKDAYS = new TimeOnly(22, 0);
    public static TimeOnly NIGHTTIME_WEEKENDS = new TimeOnly(22, 0);
    public static TimeOnly CLEANING_STARTTIME = new TimeOnly(9, 30);
    public static TimeOnly CLEANING_ENDTIME = new TimeOnly(11, 30);
    public const DayOfWeek CLEANING_DAY = DayOfWeek.Friday;
    public static DayOfWeek[] WeekdayNightDays =
    [
        DayOfWeek.Sunday,
        DayOfWeek.Monday,
        DayOfWeek.Tuesday,
        DayOfWeek.Wednesday,
        DayOfWeek.Thursday,
    ];
    public static DayOfWeek[] WeekendNightDays =
    [
        DayOfWeek.Friday,
        DayOfWeek.Saturday,
    ];

    public static LoungeModeOptions[] LoungeLightModes =
    [
        LoungeModeOptions.Normal,
        LoungeModeOptions.Reading
    ];

    public static LoungeModeOptions[] LoungeLampModes =
    [
        LoungeModeOptions.Television
    ];

    public static LightControlModeOptions[] MotionModes =
    [
        LightControlModeOptions.Cleaning,
        LightControlModeOptions.Motion,
        LightControlModeOptions.Relaxing
    ];

    public static LightControlModeOptions[] NormalMotionModes =
    [
        LightControlModeOptions.Cleaning,
        LightControlModeOptions.Motion
    ];

    public static LightControlModeOptions[] LampMotionModes =
    [
        LightControlModeOptions.Motion,
        LightControlModeOptions.Relaxing
    ];

    public static BedroomModeOptions[] BedroomMotionModes =
    [
        BedroomModeOptions.Normal,
        BedroomModeOptions.Relaxing
    ];

    public static LocationModeOptions[] HouseOccupied =
    [
        LocationModeOptions.Home,
        LocationModeOptions.OneAway,
        LocationModeOptions.HouseSitter,
        LocationModeOptions.Guest
    ];
}