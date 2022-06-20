public static class Constants
{
    public const double DARK_THRESHOLD = 30.0;
    public const double BRIGHT_THRESHOLD = 480.0;
    public static TimeOnly DAYTIME = new TimeOnly(9, 0);
    public static TimeOnly BACK_IN_SHADOW = new TimeOnly(9, 0);
    public static TimeOnly NIGHTTIME_WEEKDAYS = new TimeOnly(23, 59, 59);
    public static TimeOnly NIGHTTIME_WEEKENDS = new TimeOnly(2, 30);
    public static TimeOnly NIGHT_START = new TimeOnly(20, 0);
    public static TimeOnly NIGHT_END = new TimeOnly(4, 0);
    public static TimeOnly EVENING_START = new TimeOnly(17, 0);
    public static TimeOnly EVENING_END = new TimeOnly(19, 59, 59);
    public static TimeOnly MORNING_START = new TimeOnly(6, 0);
    public static TimeOnly MORNING_END = new TimeOnly(10, 0);
    public static TimeOnly CLEANING_STARTTIME = new TimeOnly(9, 30);
    public static TimeOnly CLEANING_ENDTIME = new TimeOnly(11, 30);
    public const DayOfWeek CLEANING_DAY = DayOfWeek.Friday;
    public static DayOfWeek[] WeekdayNightDays = new DayOfWeek[]
    {
        DayOfWeek.Sunday,
        DayOfWeek.Monday,
        DayOfWeek.Tuesday,
        DayOfWeek.Wednesday,
        DayOfWeek.Thursday,
    };
    public static DayOfWeek[] WeekendNightDays = new DayOfWeek[]
    {
        DayOfWeek.Friday,
        DayOfWeek.Saturday,
    };

    public static LoungeModeOptions[] LoungeLightModes = new[] 
    { 
        LoungeModeOptions.Normal, 
        LoungeModeOptions.Reading
    };

    public static LoungeModeOptions[] LoungeLampModes = new[] 
    { 
        LoungeModeOptions.Television
    };

    public static LightControlModeOptions[] MotionModes = new[]
    {
        LightControlModeOptions.Cleaning,
        LightControlModeOptions.Motion,
        LightControlModeOptions.Relaxing
    };

    public static LightControlModeOptions[] NormalMotionModes = new[]
    {
        LightControlModeOptions.Cleaning,
        LightControlModeOptions.Motion
    };

    public static LightControlModeOptions[] LampMotionModes = new[]
    {
        LightControlModeOptions.Motion,
        LightControlModeOptions.Relaxing
    };

    public static BedroomModeOptions[] BedroomMotionModes = new[]
    {
        BedroomModeOptions.Normal,
        BedroomModeOptions.Relaxing
    };
}