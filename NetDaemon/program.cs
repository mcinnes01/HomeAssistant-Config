using System.Reflection;
using HomeAssistantGenerated.Logging;
using Microsoft.Extensions.Hosting;
using NetDaemon.Extensions.MqttEntityManager;
using NetDaemon.Runtime;

try
{
    Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    await Host.CreateDefaultBuilder(args)
              .UseNetDaemonAppSettings()
              .UseCustomLogging()
              .UseNetDaemonRuntime()
              .UseNetDaemonTextToSpeech()
              .UseNetDaemonMqttEntityManagement()
              .ConfigureServices((context, services) =>
                  services
                      .AddAppsFromAssembly(Assembly.GetExecutingAssembly())
                      .AddNetDaemonStateManager()
                      .AddNetDaemonScheduler()
                      .SetupDependencies()
              )
              .Build()
              .RunAsync()
              .ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine($"Failed to start host... {e}");
    throw;
}