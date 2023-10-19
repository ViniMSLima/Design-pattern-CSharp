public class SinAggregation : IAggregation
{
    public double Calculate(Function f, double x)
        => Math.Sin(f[x]);

    public Function Derive(Function f)
    {
        throw new NotImplementedException();
    }
        
}