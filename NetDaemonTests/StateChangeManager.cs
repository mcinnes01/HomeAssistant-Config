using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;
using NetDaemon.HassModel.Entities;
using Stateless.Graph;

namespace NetDaemon.Extensions.Testing;

public class StateChangeManager(IHaContext haContextMock, TestScheduler testScheduler)
{
    public ReadOnlyCollection<TestServiceCall> ServiceCalls => ( (HaContextMockImpl)haContextMock ).ServiceCalls;

    public StateChangeManager AdvanceDays(int days)
    {
        testScheduler.AdvanceBy(TimeSpan.FromDays(days).Ticks);
        return this;
    }

    public StateChangeManager AdvanceTo(DateTime dateTime)
    {
        testScheduler.AdvanceTo(dateTime.ToUniversalTime().Ticks);
        return this;
    }

    public StateChangeManager AdvanceTo(TimeOnly timeOnly)
    {
        testScheduler.AdvanceTo(new DateTime(DateOnly.FromDateTime(testScheduler.Now.Date), timeOnly).ToUniversalTime().Ticks);
        return this;
    }

    public StateChangeManager AdvanceTo(DateOnly dateOnly)
    {
        testScheduler.AdvanceTo(new DateTime(dateOnly, TimeOnly.FromDateTime(testScheduler.Now.DateTime)).ToUniversalTime().Ticks);
        return this;
    }

    public StateChangeManager Change(Entity entity, string newStatevalue, object? attributes = null)
    {
        ( (HaContextMockImpl)haContextMock ).TriggerStateChange(entity, newStatevalue, attributes);
        return this;
    }
    
    public StateChangeManager Change(Entity entity, EntityState newState)
    {
        ( (HaContextMockImpl)haContextMock ).TriggerStateChange(entity, newState);
        return this;
    }
    
    public StateChangeManager Change(Entity entity, EntityState oldState, EntityState newState)
    {
        ( (HaContextMockImpl)haContextMock ).TriggerStateChange(entity, oldState, newState);
        return this;
    }

    public StateChangeManager Change(Entity entity, Dictionary<string, object> attributes)
    {
        var entityState = new EntityState
        {
            EntityId = entity.EntityId,
            State = "off",
            AttributesJson = ToAttributeJson(attributes)
        };

        // Arrange
        return Change(entity, entityState);
        
    }
    public StateChangeManager Change(Entity entity, object? attributes)
    {
        
        var entityState = new EntityState
        {
            EntityId = entity.EntityId,
            State = "off",
            AttributesJson = ToAttributeJson(attributes)
        };

        // Arrange
        return Change(entity, entityState);

    }


    public StateChangeManager Change(NumericSensorEntity entity, double newStatevalue, object? attributes = null) =>
        Change(entity, newStatevalue.ToString(CultureInfo.InvariantCulture), attributes);

    public static JsonElement ToAttributeJson(object? attributes)
    {
        // Serialize the dictionary to a JSON string
        var attributesJsonString = JsonSerializer.Serialize(attributes);

        // Parse the JSON string into a JsonElement
        return JsonSerializer.Deserialize<JsonElement>(attributesJsonString);
    }
}