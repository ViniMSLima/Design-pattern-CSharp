public class AggregateFunction : Function
{
    public IAggregation Aggregation { get; set; }
    public Function Function { get; set; }

    public override Function Derive()
        => Aggregation.Derive(Function);

    protected override double compute(double x)
        => Aggregation.Calculate(Function, x);
}