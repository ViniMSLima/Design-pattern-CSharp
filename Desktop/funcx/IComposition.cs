public interface IComposition
{
    double Calcule(List<Function> fs, double x);
    
    Function Derive(List<Function> fs);
}