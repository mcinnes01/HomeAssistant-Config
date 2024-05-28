namespace NetDaemon;

public interface ICycleStateHandler
{
    void HandleCycleState(CycleState cycleState, InputBooleanEntity applianceReminder, InputBooleanEntity applianceAcknowledge);
}