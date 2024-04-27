using Microsoft.ML;

namespace LinearRegression.Model.Implementations;

public class LinearRegression : ModelBase
{
    public override IEstimator<ITransformer> CreateModel(MLContext mlContext)
    {
        return mlContext.Regression.Trainers.Sdca();
    }
}