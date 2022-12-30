using NetDaemon.Extensions.MqttEntityManager;
using System.Threading.Tasks;

namespace NetDaemonApps.Extensions;

public static class IMqttEntityManagerExtensions
{
    public static Task CreateEntityAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttCommonAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateBinarySensorAsync(this IMqttEntityManager manager, string id, 
        EntityCreationOptions? options, MqttBinarySensorAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateButtonAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttButtonAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateCoverAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttCoverAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateNumberAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttNumberAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateSelectAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttSelectAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateSensorAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttSensorAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static Task CreateSwitchAsync(this IMqttEntityManager manager, string id,
        EntityCreationOptions? options, MqttSwitchAttributes? additionalConfig)
    {
        return manager.CreateAsync(id, options, additionalConfig);
    }

    public static async Task<Entity?> RequiresEntityAsync(this IMqttEntityManager manager, IHaContext haContext, string id, 
        EntityCreationOptions? options = null, MqttCommonAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing != null)
            return existing;
        await manager.CreateAsync(id, options, additionalConfig);
        return new Entity(haContext, id);
    }

    public static async Task<BinarySensorEntity> RequiresBinarySensorAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
        EntityCreationOptions? options = null, MqttBinarySensorAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing == null)
            await manager.CreateBinarySensorAsync(id, options, additionalConfig);
        return new BinarySensorEntity(haContext, id);
    }

    public static async Task<ButtonEntity> RequiresButtonAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
        EntityCreationOptions? options = null, MqttButtonAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing == null)
            await manager.CreateButtonAsync(id, options, additionalConfig);
        return new ButtonEntity(haContext, id);
    }

    // public static async Task<CoverEntity> RequiresCoverAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
    //     EntityCreationOptions? options = null, MqttCoverAttributes? additionalConfig = null)
    // {
    //     var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
    //     if (existing == null)
    //         await manager.CreateCoverAsync(id, options, additionalConfig);
    //     return new CoverEntity(haContext, id);
    // }

    public static async Task<NumberEntity> RequiresNumberAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
        EntityCreationOptions? options = null, MqttNumberAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing == null)
            await manager.CreateNumberAsync(id, options, additionalConfig);
        return new NumberEntity(haContext, id);
    }

    public static async Task<SelectEntity> RequiresSelectAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
        EntityCreationOptions? options = null, MqttSelectAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing == null)
            await manager.CreateSelectAsync(id, options, additionalConfig);
        return new SelectEntity(haContext, id);
    }

    public static async Task<SensorEntity> RequiresSensorAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
        EntityCreationOptions? options = null, MqttSensorAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing == null)
            await manager.CreateSensorAsync(id, options, additionalConfig);
        return new SensorEntity(haContext, id);
    }

    public static async Task<SwitchEntity> RequiresSwitchAsync(this IMqttEntityManager manager, IHaContext haContext, string id,
        EntityCreationOptions? options = null, MqttSwitchAttributes? additionalConfig = null)
    {
        var existing = haContext.GetAllEntities().FirstOrDefault(e => e.EntityId == id);
        if (existing == null)
            await manager.CreateSwitchAsync(id, options, additionalConfig);
        return new SwitchEntity(haContext, id);
    }
}