using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MotionState;

/// <summary>
///     Extension methods for motion-state
/// </summary>
public static class HostBuilderExtensions
{
    /// <summary>
    ///     Use the motion state entity for NetDaemon
    /// </summary>
    /// <param name="hostBuilder">Builder</param>
    public static IHostBuilder UseMotionState(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddCacheManager<MotionStateItem>(inline => inline.WithDictionaryHandle());
            services.AddCacheManager();
            services.AddSingleton<IMotionStateService, MotionStateService>();
        });
        return hostBuilder;
    }
}