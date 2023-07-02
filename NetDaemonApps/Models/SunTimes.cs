   namespace NetDaemonApps.Models;

    public class SunTimes
    {
        public DateTime Dawn { get; private set; }
        public DateTime Noon { get; private set; }
        public DateTime Dusk { get; private set; }
        public bool IsSet { get; private set; } = false;

        public SunTimes Set(DateTime dawn, DateTime noon, DateTime dusk)
        {
            Dawn = dawn;
            Noon = noon;
            Dusk = dusk;
            IsSet = true;
            return this;
        }
    }