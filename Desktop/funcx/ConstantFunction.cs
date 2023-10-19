public class ConstantFunction : Function
{
    private double value;
    
    public ConstantFunction(double value)
        => this.value = value;

    protected override double compute(double x)
        => value;

    public override Function Derive()
        => new ConstantFunction(0);
}