using MathNet.Numerics.LinearAlgebra;

namespace LinearRegression.Data.Processing;

public interface IProcessor
{
    public Vector<float> Process(Vector<float> data);
}