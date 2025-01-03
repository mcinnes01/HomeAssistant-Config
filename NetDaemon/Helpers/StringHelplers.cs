namespace NetDaemon.Helpers;

public static class StringHelpers
{
    public static string AsString(this IEnumerable<Condition> conditions)    
    {
        var conditionString = string.Empty;
        foreach (var condition in conditions)
        {
            conditionString += $"{{ {condition.Entity.EntityId}: '{condition.Entity.State}' {condition.Operator} '{condition.State}' }} and ";
        }
        return conditionString.EndsWith(" and ") 
            ? conditionString.Substring(0, conditionString.Length - 5) 
            : conditionString;
    }
}