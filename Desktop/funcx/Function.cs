using System.Reflection.Metadata;

public abstract class Function
{
    public double this[double x] //permite q o objeto acesse coisas com o colchete
        => this.compute(x);

    protected abstract double compute(double x);

    public abstract Function Derive();

    public static Function operator +(Function f, Function g)
    {
        CompositeFunction h = new CompositeFunction();
        h.Composition = Compositions.Sum;
        h.Functions.Add(f);
        h.Functions.Add(g);
        return h;
    }

    public static Function operator +(Function f, double n)
    {
        CompositeFunction h = new CompositeFunction();
        h.Composition = Compositions.Sum;
        h.Functions.Add(f);
        h.Functions.Add(n);
        return h;
    }

    public static Function operator *(Function f, Function g)
    {
        CompositeFunction h = new CompositeFunction();
        h.Composition = Compositions.Multi;
        h.Functions.Add(f);
        h.Functions.Add(g);
        return h;
    }

    public static Function operator *(Function f, double n)
    {
        CompositeFunction h = new CompositeFunction();
        h.Composition = Compositions.Multi;
        h.Functions.Add(f);
        h.Functions.Add(n);
        return h;
    }

    public static implicit operator Function(double x)
        => new ConstantFunction(x);
} 