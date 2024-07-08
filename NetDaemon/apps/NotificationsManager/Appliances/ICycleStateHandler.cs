namespace NetDaemon.apps.NotificationsManager.Appliances;

public interface ICycleStateHandler
{
    void HandleCycleState(CycleState cycleState, InputBooleanEntity applianceReminder, InputBooleanEntity applianceAcknowledge);
}