using System.Reflection;
using HomeAssistantGenerated.Logging;
using Microsoft.Extensions.Hosting;
using NetDaemon.Extensions.MqttEntityManager;
using NetDaemon.Runtime;

try
{
    Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    var builder = Host.CreateDefaultBuilder(args);
    builder.UseNetDaemonAppSettings();
    builder.UseCustomLogging();
    builder.UseNetDaemonRuntime();
    builder.UseNetDaemonTextToSpeech();

    var services = builder.Services.BuildServiceProvider();
    var mqttServiceBefore = services.GetService<IMqttEntityManager>();
    Console.WriteLine(mqttServiceBefore != null ? "IMqttEntityManager is registered." : "IMqttEntityManager is NOT registered.");

    builder.UseNetDaemonMqttEntityManagement();

    services = builder.Services.BuildServiceProvider();
    var mqttServiceAfter = services.GetService<IMqttEntityManager>();
    Console.WriteLine(mqttServiceAfter != null ? "IMqttEntityManager is registered." : "IMqttEntityManager is NOT registered.");

    builder.ConfigureServices((context, services) =>
        services
            .AddAppsFromAssembly(Assembly.GetExecutingAssembly())
            .AddNetDaemonStateManager()
            .AddNetDaemonScheduler()
            .SetupDependencies()
    );

    var app = builder.Build();
    await app.RunAsync().ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine($"Failed to start host... {e}");
    throw;
}