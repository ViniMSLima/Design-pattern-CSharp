public class MultiComposition : IComposition
{
    public double Calcule(List<Function> fs, double x)
    {
        double multi = 1;
        foreach(Function f in fs)
            multi *= f[x];
        return multi;
    }

    public Function Derive(List<Function> fs)
        => throw new NotImplementedException();
    
}