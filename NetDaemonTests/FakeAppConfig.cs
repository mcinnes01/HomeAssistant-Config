using NetDaemon.AppModel;

namespace NetDaemon.Extensions.Testing;

public class FakeAppConfig<T>(T instance) : IAppConfig<T>
    where T : class, new()
{
    public T Value { get; } = instance;
}