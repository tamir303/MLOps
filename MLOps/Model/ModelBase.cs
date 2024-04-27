using Microsoft.ML;
namespace LinearRegression.Model;

public abstract class ModelBase : IModel
{
    public abstract IEstimator<ITransformer> CreateModel(MLContext mlContext);
}