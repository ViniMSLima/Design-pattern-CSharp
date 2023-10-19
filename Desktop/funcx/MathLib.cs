public static class MathLib
{
    public static LinearFunction x { get; private set; } = new();

    public static Function cos(Function f)
    {
        var cos = new AggregateFunction();
        cos.Function = f;
        cos.Aggregation = new CosAggregation();
        return cos;
    }

    public static Function sin(Function f)
    {
        var sin = new AggregateFunction();
        sin.Function = f;
        sin.Aggregation = new CosAggregation();
        return sin;
    }
}