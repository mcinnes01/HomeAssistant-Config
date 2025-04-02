using NetDaemon.HassModel.Entities;

namespace NetDaemon.Extensions.Testing;

public class TestEntityBuilder(IHaContext haContext, StateChangeManager stateChangeManager)
{
    public BinarySensorEntity CreateBinarySensorEntity(string entityId) => new(haContext, entityId);

    public BinarySensorEntity CreateBinarySensorEntity(string entityId, string state)
    {
        var entity = new BinarySensorEntity(haContext, entityId);
        stateChangeManager.Change(entity, state);
        return entity;
    }

    public InputBooleanEntity CreateInputBooleanEntity(string entityId) => new(haContext, entityId);

    public InputBooleanEntity CreateInputBooleanEntity(string entityId, string state)
    {
        var entity = new InputBooleanEntity(haContext, entityId);
        stateChangeManager.Change(entity, state);
        return entity;
    }

    public InputSelectEntity CreateInputSelectEntity(string entityId) => new(haContext, entityId);

    public LightEntity CreateLightEntity(string entityId) => new(haContext, entityId);
    public MediaPlayerEntity CreateMediaPlayerEntity(string entityId) => new(haContext, entityId);
    public NumericSensorEntity CreateNumericEntity(string entityId) => new(haContext, entityId);
    public PersonEntity CreatePersonEntity(string entityId) => new(haContext, entityId);
    public SensorEntity CreateSensorEntity(string entityId) => new(haContext, entityId);
    public SwitchEntity CreateSwitchEntity(string entityId) => new(haContext, entityId);

    public SwitchEntity CreateSwitchEntity(string entityId, string state)
    {
        var entity = new SwitchEntity(haContext, entityId);
        stateChangeManager.Change(entity, state);
        return entity;
    }
    
    public TEntity CreateEntity<TEntity>(string entityId, string state) where TEntity : Entity
    {
        var entity = Activator.CreateInstance(typeof(TEntity), haContext, entityId) as TEntity;
    
        if (entity != null)
        {
            stateChangeManager.Change(entity, state);
        }

        return entity;
    }
}