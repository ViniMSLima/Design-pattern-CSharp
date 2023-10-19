public class QuadraticFunction : Function
{
    private double value;
    private double a;
    private double b;
    private double c;

    public QuadraticFunction(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
        
    public override Function Derive()
    {
        throw new NotImplementedException();
    }

    protected override double compute(double x)
        => a * x  * x + b * x + c;
}