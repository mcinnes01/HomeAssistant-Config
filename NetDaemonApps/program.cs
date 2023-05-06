using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDaemon.Extensions.Logging;
using NetDaemon.Extensions.MqttEntityManager;
using NetDaemon.Runtime;
using NetDaemonApps.Infrastructure.State;

#pragma warning disable CA1812

try
{
    var host = Host.CreateDefaultBuilder(args)
        .UseNetDaemonAppSettings()
        .UseNetDaemonDefaultLogging()
        .UseNetDaemonRuntime()
        .UseNetDaemonTextToSpeech()
        .UseNetDaemonMqttEntityManagement()
        //.UseDeviceTriggers()
        .ConfigureServices((context, services) =>
        {
            services
                .AddAppsFromAssembly(Assembly.GetExecutingAssembly())
                .AddNetDaemonStateManager()
                .AddNetDaemonScheduler()
                .AddGeneratedCode();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddTransient<ILightingStates, LightingStates>();
        })
        .Build();

    // Configure Logbook helper extension
    var services = host.Services.GetService<IServices>();
    LogbookHelper.Configure(services?.Logbook);

    await host
      .RunAsync()
      .ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine($"Failed to start host... {e}");
    throw;
}