using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.Extensions
{
    public static class VacuumExtensions
    {
        public static bool IsDocked(this EntityState<VacuumAttributes>? state)
        => string.Equals(state?.State, "docked", StringComparison.OrdinalIgnoreCase);

        public static bool IsNewMoon(this VacuumEntity? entity)
            => entity?.EntityState?.IsDocked() ?? false;

        public static IDisposable WhenDocked(this VacuumEntity entity,
            Action<StateChange<VacuumEntity, EntityState<VacuumAttributes>>> action)
            => entity.StateChanges().Where(e => e.New?.IsDocked() ?? false).Subscribe(action);
    }
}
