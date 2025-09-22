using System;
using System.Reactive.Linq;
using NetDaemon.HassModel.Entities;

public static class HomeAssistantBooleanRxExtensions
{
    /// <summary>
    /// Projects InputBooleanEntity state changes to IObservable&lt;bool?&gt;
    /// </summary>
    public static IObservable<bool?> StateAsBool(this InputBooleanEntity entity)
        => entity.StateChanges().Select(e =>
            e.New?.State == "on" ? true :
            e.New?.State == "off" ? false : (bool?)null);

    /// <summary>
    /// Projects BinarySensorEntity state changes to IObservable&lt;bool?&gt;
    /// </summary>
    public static IObservable<bool?> StateAsBool(this BinarySensorEntity entity)
        => entity.StateChanges().Select(e =>
            e.New?.State == "on" ? true :
            e.New?.State == "off" ? false : (bool?)null);
}
