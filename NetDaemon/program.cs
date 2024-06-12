using System.Reflection;
using HomeAssistantGenerated.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NetDaemon.Extensions.MqttEntityManager;
using NetDaemon.Runtime;
using HomeAssistantGenerated;

try
{
    Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

    var builder = Host.CreateDefaultBuilder(args);
    builder.UseNetDaemonAppSettings();
    builder.UseCustomLogging();
    builder.UseNetDaemonRuntime();
    builder.UseNetDaemonTextToSpeech();
    builder.UseNetDaemonMqttEntityManagement();
    builder.ConfigureServices((context, services) =>
        services
            .AddAppsFromAssembly(Assembly.GetExecutingAssembly())
            .AddNetDaemonStateManager()
            .AddNetDaemonScheduler()
            .SetupDependencies()
    );

    var app = builder.Build();
    var mqttServiceAfter = app.Services.GetRequiredService<IMqttEntityManager>();
    Console.WriteLine(mqttServiceAfter != null ? "IMqttEntityManager is registered." : "IMqttEntityManager is NOT registered.");

    await app.RunAsync().ConfigureAwait(false);
}
catch (Exception e)
{
    Console.WriteLine($"Failed to start host... {e}");
    throw;
}