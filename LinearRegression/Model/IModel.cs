using MathNet.Numerics.LinearAlgebra;
namespace LinearRegression.Model;

public interface IModel
{
    public void Fit(Matrix<float> X, Vector<float> y, float learningRate, int epochs);
    public Vector<float> Predict(Matrix<float> X);
}