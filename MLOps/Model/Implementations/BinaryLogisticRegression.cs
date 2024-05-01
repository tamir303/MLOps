using Microsoft.ML;

namespace LinearRegression.Model.Implementations;

public class BinaryLogisticRegression : ModelBase
{
    public override void CreateModel(MLContext mlContext)
    {
        this._mlContext = mlContext;
        this._model = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression();
    }
}