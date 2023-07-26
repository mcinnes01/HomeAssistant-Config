   namespace NetDaemonApps.Models;

    public class SunTimes
    {
        public DateTime Now => DateTime.Now;
        public DateTime Morning { get; private set; }
        public DateTime Day { get; private set; }
        public DateTime Afternoon { get; private set; }
        public DateTime Evening { get; private set; }
        public DateTime Night { get; private set; }
        public TimeOnly NowTime => TimeOnly.FromDateTime(Now);
        public TimeOnly MorningTime => TimeOnly.FromDateTime(Morning);
        public TimeOnly DayTime => TimeOnly.FromDateTime(Day);
        public TimeOnly AfternoonTime => TimeOnly.FromDateTime(Afternoon);
        public TimeOnly EveningTime => TimeOnly.FromDateTime(Evening);
        public TimeOnly NightTime => TimeOnly.FromDateTime(Night);
        public DateOnly NowDate => DateOnly.FromDateTime(Now);
        public DateOnly MorningDate => DateOnly.FromDateTime(Morning);
        public DateOnly DayDate => DateOnly.FromDateTime(Day);
        public DateOnly AfternoonDate => DateOnly.FromDateTime(Afternoon);
        public DateOnly EveningDate => DateOnly.FromDateTime(Evening);
        public DateOnly NightDate => DateOnly.FromDateTime(Night);
        public bool IsSet { get; private set; } = false;

        public SunTimes Set(DateTime nextDawn, DateTime nextNoon, DateTime nextDusk)
        {
            Morning = nextDawn;
            Day = DateTime.Today.Add(Constants.DAYTIME.ToTimeSpan());
            Afternoon = nextNoon;
            Evening = DateTime.Today.Add(Constants.EVENINGTIME.ToTimeSpan());
            Night = nextDusk;

            // Correct day if we are setting things out of schedule
            if (MorningDate > NowDate && AfternoonDate > NowDate)
                Day.AddDays(1);

            // Correct afternoon if we are setting things out of schedule
            if (AfternoonDate > EveningDate && NowTime > Constants.NIGHT_START)
                Evening.AddDays(1);

            IsSet = true;
            return this;
        }
    }