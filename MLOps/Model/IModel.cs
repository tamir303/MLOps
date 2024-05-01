using MathNet.Numerics.LinearAlgebra;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
namespace LinearRegression.Model;

public interface IModel
{
    void Train(Matrix<float> xTrain, Vector<float> yTrain);
    Vector<float> Predict(Matrix<float> data);
    float Predict(Vector<float> data);
}