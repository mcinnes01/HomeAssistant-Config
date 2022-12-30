// TODO: Create an entity to track if Andy is home or away
// Use this entity on the house level to control home/away at house level
// Additionally use to control motion and night on house state possible with a max time in manual and maybe guest mode
using System.ComponentModel;

namespace NetDaemonApps.Infrastructure;

public enum TVTarget
{
    [Description("lounge")]
    Lounge,
    [Description("snug")]
    Snug,
    All,
}

