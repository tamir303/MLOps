namespace LinearRegression.Evaluate;
using MathNet.Numerics.LinearAlgebra;

public interface IEvaluator
{
    public static abstract float Score(Vector<float> predicted, Vector<float> expected);
}