using MathNet.Numerics.LinearAlgebra;

namespace LinearRegression.Evaluate;

public class MSE: IEvaluator
{
    public static float Score(Vector<float> predicted, Vector<float> expected)
    {
        // the mean squared error (MSE) measures the average of the squares of the errors
        // MSE = (1/N) * Sum(Ei-Pi)^2
        var n = predicted.Count;
        var mse = (1.0f / n) * (expected - predicted).PointwisePower(2).Sum();
        
        return mse;
    }
}