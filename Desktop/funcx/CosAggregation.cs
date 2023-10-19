public class CosAggregation : IAggregation
{
    public double Calculate(Function f, double x)
        => Math.Cos(f[x]);

    public Function Derive(Function f)
    {
        throw new NotImplementedException();
    }
        
}