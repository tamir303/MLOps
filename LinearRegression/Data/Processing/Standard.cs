using MathNet.Numerics.Statistics;

namespace LinearRegression.Data.Processing;
using MathNet.Numerics.LinearAlgebra;

public class Standard: IProcessor
{
    public Vector<float> Process(Vector<float> data)
    {
        var mean = (float) data.Mean();
        var stdDev = (float) data.StandardDeviation();
        return (data - mean) / stdDev;
    }
}