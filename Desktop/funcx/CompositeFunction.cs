public class CompositeFunction : Function
{
    public IComposition Composition { get; set; }
    public List<Function> Functions { get; private set; } = new();

    public override Function Derive()
        => Composition.Derive(Functions);

    protected override double compute(double x)
        => Composition.Calcule(Functions, x);
}

// "PIMBA" 
//       Trevisan, 19/10/2023
