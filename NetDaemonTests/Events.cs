using NetDaemon.HassModel.Entities;

namespace NetDaemon.Extensions.Testing;

public static partial class Events
{
    public static TestServiceCall ServiceCall(string domain, string service, ServiceTarget? target = null, object? data = null) =>
        new TestServiceCall(domain, service, target, data);
    public static class Light
    {
        public static object TurnOff(LightEntity entity) =>
            new
            {
                Domain = "light",
                Service = "turn_off",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };

        public static object TurnOn(LightEntity entity, LightTurnOnParameters lightTurnOnParameters) =>
            new
            {
                Domain = "light",
                Service = "turn_on",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                },
                Data = lightTurnOnParameters
            };

        public static object TurnOn(LightEntity entity) =>
            new
            {
                Domain = "light",
                Service = "turn_on",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };
    }

    public static class Switch
    {
        public static object TurnOff(SwitchEntity entity) =>
            new
            {
                Domain = "switch",
                Service = "turn_off",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };

        public static object TurnOn(SwitchEntity entity) =>
            new
            {
                Domain = "switch",
                Service = "turn_on",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };
    }

    public static class InputBoolean
    {
        public static object TurnOff(InputBooleanEntity entity) =>
            new
            {
                Domain = "input_boolean",
                Service = "turn_off",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };

        public static object TurnOn(InputBooleanEntity entity) =>
            new
            {
                Domain = "input_boolean",
                Service = "turn_on",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };
    }

    public static class AlarmPanel
    {
        public static object Disarmed(AlarmControlPanelEntity entity) =>
            new
            {
                Domain = "alarm_control_panel",
                Service = "alarm_disarm",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };

        public static object ArmedAway(AlarmControlPanelEntity entity) =>
            new
            {
                Domain = "alarm_control_panel",
                Service = "alarm_arm_away",
                Target = new
                {
                    EntityIds = new[] { entity.EntityId }
                }
            };
    }

    public static class Notify
    {
        public static TestServiceCall AlexaMedia(MediaPlayerEntity entity, string message, string type) =>
            ServiceCall("notify", "alexa_media",
                data: new
                {
                    Data = new { type = type },
                    Target = entity.EntityId,
                    Message = message
                });

        public static TestServiceCall Twinstead(string message) =>
            ServiceCall("notify", "twinstead",
                data: new
                {                    
                    Message = message
                });
    };

    public static class Logbook
    {
        public static TestServiceCall Log(string message, string? entityId = "", string? domain = "", string? name = "") =>
            ServiceCall("logbook", "log",
                data: new LogbookLogParameters 
                {                    
                    EntityId = entityId,
                    Message = message,
                    Domain = domain,
                    Name = name
                });        
    };
}
