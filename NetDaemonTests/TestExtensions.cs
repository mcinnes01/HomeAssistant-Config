using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using NetDaemon.HassModel.Entities;

namespace NetDaemon.Extensions.Testing;

public static class TestExtensions
{
    public static JsonElement AsJsonElement(this object value)
    {
        var jsonString = JsonSerializer.Serialize(value);
        return JsonSerializer.Deserialize<JsonElement>(jsonString);
    }

    public static EntityState WithAttributes(this EntityState entityState, object attributes)
    {
        var copy = entityState with { };
        entityState.GetType().GetProperty("AttributesJson", BindingFlags.Public | BindingFlags.Instance)!.SetValue(copy, AsJsonElement(attributes));
        return copy;
    }

    public static ReadOnlyCollection<TestServiceCall> Light(this IEnumerable<TestServiceCall> collection) => 
        new ( collection.Where(s => string.Equals(s.Domain, "light", StringComparison.InvariantCultureIgnoreCase)).ToList());
    public static ReadOnlyCollection<TestServiceCall> Switch(this IEnumerable<TestServiceCall> collection) => 
        new ( collection.Where(s => string.Equals(s.Domain, "switch", StringComparison.InvariantCultureIgnoreCase)).ToList());
    
    public static ReadOnlyCollection<TestServiceCall> Filter(this IEnumerable<TestServiceCall> collection, Domain domain) => 
        new ( collection.Where(s => string.Equals(s.Domain, domain.ToString(), StringComparison.InvariantCultureIgnoreCase)).ToList());

    public static ReadOnlyCollection<TestServiceCall> Filter(this IEnumerable<TestServiceCall> collection, IEnumerable<Domain> domains) =>
        new(collection.Where(s => domains.Any(d => string.Equals(s.Domain, d.ToString(), StringComparison.InvariantCultureIgnoreCase))).ToList());

    public static ReadOnlyCollection<TestServiceCall> Filter(this IEnumerable<TestServiceCall> collection, Domain domain, string service) =>
        new(collection.Where(s => string.Equals(s.Domain, domain.ToString(), StringComparison.InvariantCultureIgnoreCase) 
        && string.Equals(s.Service, service, StringComparison.InvariantCultureIgnoreCase)).ToList());

    public static ReadOnlyCollection<TestServiceCall> Filter(this IEnumerable<TestServiceCall> collection, string service) => 
        new ( collection.Where(s => string.Equals(s.Service, service, StringComparison.InvariantCultureIgnoreCase)).ToList());
    
}

public enum Domain
{
    Light,
    Switch,
    Notify,
    Logbook
}