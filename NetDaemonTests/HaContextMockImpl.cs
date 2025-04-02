using System.Collections.ObjectModel;
using System.Reactive.Subjects;
using System.Text.Json;
using NetDaemon.HassModel.Entities;

namespace NetDaemon.Extensions.Testing;

public class HaContextMockImpl : IHaContext
{
    private readonly List<TestServiceCall> _serviceCalls = [];

    public Dictionary<string, EntityState> EntityStates { get; } = [];
    public ReadOnlyCollection<TestServiceCall> ServiceCalls => new(_serviceCalls);
    public Subject<Event> EventsSubject { get; } = new();
    public Subject<StateChange> StateAllChangeSubject { get; } = new();

    public void CallService(string domain, string service, ServiceTarget? target = null, object? data = null)
    {
        _serviceCalls.Add(new TestServiceCall(domain, service, target, data));
    }

    public Task<JsonElement?> CallServiceWithResponseAsync(string domain, string service, ServiceTarget? target = null, object? data = null) => throw new NotImplementedException();

    public IObservable<Event> Events => EventsSubject;

    public IReadOnlyList<Entity> GetAllEntities() => EntityStates.Keys.Select(s => new Entity(this, s)).ToList();

    public Area? GetAreaFromEntityId(string entityId) => null;

    public EntityState? GetState(string entityId) => EntityStates.TryGetValue(entityId, out var result) ? result : null;

    public virtual void SendEvent(string eventType, object? data = null)
    {
    }

    public IObservable<StateChange> StateAllChanges() => StateAllChangeSubject;

    public void TriggerStateChange(Entity entity, string newStatevalue, object? attributes = null)
    {
        var newState                     = new EntityState { State = newStatevalue };
        if (attributes != null) newState = newState.WithAttributes(attributes);

        TriggerStateChange(entity.EntityId, newState);
    }

    public void TriggerStateChange(Entity entity, EntityState newState)
    {
        TriggerStateChange(entity.EntityId, newState);
    }
    public void TriggerStateChange(string entityId, EntityState newState)
    {
        var oldState = EntityStates.TryGetValue(entityId, out var current) ? current : null;
        EntityStates[entityId] = newState;
        StateAllChangeSubject.OnNext(new StateChange(new Entity(this, entityId), oldState, newState));
    }
    
    
    public void TriggerStateChange(Entity entity, EntityState oldState, EntityState newState)
    {
        EntityStates[entity.EntityId] = newState;
        StateAllChangeSubject.OnNext(new StateChange(new Entity(this, entity.EntityId), oldState, newState));
    }

    EntityRegistration? IHaContext.GetEntityRegistration(string entityId)
    {
        throw new NotImplementedException();
    }
}

public record TestServiceCall(string Domain, string Service, ServiceTarget? Target = null, object? Data = null);