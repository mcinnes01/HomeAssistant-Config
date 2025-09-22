using System;
using NetDaemon.HassModel.Entities;

public interface IBooleanStateEntity
{
    bool? State { get; }
    string EntityId { get; }
}

public class InputBooleanStateEntityAdapter : IBooleanStateEntity
{
    private readonly InputBooleanEntity _entity;
    public InputBooleanStateEntityAdapter(InputBooleanEntity entity) => _entity = entity;
    public bool? State => _entity?.State == "on" ? true :
                          _entity?.State == "off" ? false : (bool?)null;
    public string EntityId => _entity?.EntityId;
}

public class BinarySensorStateEntityAdapter : IBooleanStateEntity
{
    private readonly BinarySensorEntity _entity;
    public BinarySensorStateEntityAdapter(BinarySensorEntity entity) => _entity = entity;
    public bool? State => _entity?.State == "on" ? true :
                          _entity?.State == "off" ? false : (bool?)null;
    public string EntityId => _entity?.EntityId;
}

// Optional: Extension methods for convenience
public static class BooleanStateEntityExtensions
{
    public static IBooleanStateEntity AsBooleanStateEntity(this InputBooleanEntity entity)
        => new InputBooleanStateEntityAdapter(entity);

    public static IBooleanStateEntity AsBooleanStateEntity(this BinarySensorEntity entity)
        => new BinarySensorStateEntityAdapter(entity);
}
