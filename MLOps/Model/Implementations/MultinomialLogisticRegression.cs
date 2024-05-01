using Microsoft.ML;

namespace LinearRegression.Model.Implementations;

public class MultinomialLogisticRegression : ModelBase
{
    public override void CreateModel(MLContext mlContext)
    {
        this._mlContext = mlContext;
        this._model = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy();
    }
}