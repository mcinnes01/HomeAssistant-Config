using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDaemon.Extensions.Logging;
using NetDaemon.Extensions.MqttEntityManager;
using NetDaemon.Runtime;

#pragma warning disable CA1812

try
{
    await Host.CreateDefaultBuilder(args)
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
            services.AddSingleton<LogbookHelperRegister>();
            services.AddTransient<ILightingStates, LightingStates>();
         })      
        .Build()
        .RunAsync()
        .ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine($"Failed to start host... {e}");
    throw;
}