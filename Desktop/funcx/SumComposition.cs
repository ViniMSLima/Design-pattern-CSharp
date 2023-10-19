
public class SumComposition : IComposition
{
    public double Calcule(List<Function> fs, double x)
    {
        double sum = 0;
        foreach(Function f in fs)
            sum += f[x];
        return sum;
    }

    public Function Derive(List<Function> fs)
    {
        CompositeFunction g = new CompositeFunction();
        g.Composition = Compositions.Sum;
        foreach (Function f in fs)
            g.Functions.Add(f.Derive());
        return g;
    }
}