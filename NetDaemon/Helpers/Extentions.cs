using Microsoft.Extensions.DependencyInjection;
using NetDaemon.apps.NotificationsManager.Appliances;
using NetDaemon.Helpers.Notifications;

namespace NetDaemon.Helpers;

public static class Extentions
{
    
    public static IServiceCollection SetupDependencies(this IServiceCollection serviceCollection)
        => serviceCollection
           .AddTransient<IEntities, Entities>()
           .AddTransient<IServices, Services>()
           .AddTransient<IAlexa, Alexa>()
           .AddSingleton<IVoiceProvider, VoiceProvider>()
           .AddScoped<INotificationConfigFactory, NotificationConfigFactory>()
           .AddScoped<IApplianceFactory, ApplianceFactory>()
           //.AddScoped<People>()
           .AddSingleton<IServiceProvider>(sp => sp);
        

    public static Dictionary<string, object>? ToDictionary(this object obj)
    {
        var json       = JsonSerializer.Serialize(obj);
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
        return dictionary;
    }
}