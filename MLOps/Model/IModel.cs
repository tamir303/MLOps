using MathNet.Numerics.LinearAlgebra;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
namespace LinearRegression.Model;

public interface IModel
{
    IEstimator<ITransformer> CreateModel(MLContext mlContext);
}