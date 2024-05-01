using Microsoft.ML;

namespace LinearRegression.Model.Implementations;

public class LinearRegression : ModelBase
{
    public override void CreateModel(MLContext mlContext)
    {
        this._mlContext = mlContext;
        this._model = mlContext.Regression.Trainers.Sdca();
    }
}