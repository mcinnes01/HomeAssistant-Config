using Microsoft.Extensions.DependencyInjection;

namespace NetDaemonApps.Extensions;


public static class ServiceProviderExtensions
{
    public static IHaContext GetContext(this IServiceProvider provider)
    {
        var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetService<IHaContext>();
        if (service == null)
            throw new Exception($"Service is not available.");
        return service;
    }

    //public static T GetService<T>(this IServiceProvider provider) 
    //{
    //    var scope = provider.CreateScope();
    //    var service = scope.ServiceProvider.GetService<T>();
    //    if (service == null)
    //        throw new Exception($"Service {typeof(T)} is not available.");
    //    return service;
    //}

}

