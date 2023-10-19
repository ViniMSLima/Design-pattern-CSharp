public class LinearFunction : Function
{
    protected override double compute(double x)
        => x;

    public override Function Derive()
        => new ConstantFunction(1);
}