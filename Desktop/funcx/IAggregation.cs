public interface IAggregation
{
    double Calculate(Function f, double x);
    Function Derive(Function f);
}