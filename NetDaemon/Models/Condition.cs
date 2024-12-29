namespace NetDaemon.Models;

public record Condition
{
    public required Entity Entity { get; set; }
    public Operator Operator { get; set; } = Operator.Equals;
    public required string State { get; set; }
}