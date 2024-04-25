using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;
namespace LinearRegression.Evaluate;

public class R2: IEvaluator
{
    public static float Score(Vector<float> predicted, Vector<float> expected)
    {
        // The coefficient of R2 is a measure that provides information about the goodness of fit of a model
        // R2 = 1 - SSR/SST
        var expectedMean  = Vector<float>.Build.Dense(expected.Count, (float)expected.Mean());
        var sst = (expected - expectedMean).PointwisePower(2).Sum();
        var ssr = (expected - predicted).PointwisePower(2).Sum();
        var r2 = 1.0f - ssr / sst;

        return r2;
    }
}