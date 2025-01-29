using Serilog;

namespace NetDaemon.Extensions;

public static class ConditionExtensions
{
    public static bool ConditionPassed(this Condition condition)
    {
        return condition.Entity.State?.ConditionPassed(condition) ?? false;
    }

    public static bool ConditionPassed(this EntityState entityState, Condition condition)
    {
        return entityState.State?.ConditionPassed(condition) ?? false;
    }

    public static bool ConditionPassed(this string? state, Condition condition)
    {
        Log.Logger.Verbose("Checking condition entity {Entity} {Operator} state {State} condition state {Condition}", condition.Entity.EntityId, condition.Operator, state, condition.State);
        switch (condition.Operator)
        {
            case Operator.Equals:
                return state == condition?.State;
            case Operator.NotEquals:
                return state != condition?.State;
            case Operator.GreaterThan:
                return double.TryParse(state, out var entityStateValue) && double.TryParse(condition?.State, out var conditionStateValue) && entityStateValue > conditionStateValue;
            case Operator.GreaterThanOrEqual:
                return double.TryParse(state, out entityStateValue) && double.TryParse(condition?.State, out conditionStateValue) && entityStateValue >= conditionStateValue;
            case Operator.LessThan:
                return double.TryParse(state, out entityStateValue) && double.TryParse(condition?.State, out conditionStateValue) && entityStateValue < conditionStateValue;
            case Operator.LessThanOrEqual:
                return double.TryParse(state, out entityStateValue) && double.TryParse(condition?.State, out conditionStateValue) && entityStateValue <= conditionStateValue;
            default:
                throw new InvalidOperationException("Unsupported operator");
        }
    }
}