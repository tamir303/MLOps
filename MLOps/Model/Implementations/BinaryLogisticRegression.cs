using Microsoft.ML;

namespace LinearRegression.Model.Implementations;

public class BinaryLogisticRegression : ModelBase
{
    public override IEstimator<ITransformer> CreateModel(MLContext mlContext)
    {
        return mlContext.BinaryClassification.Trainers.SdcaLogisticRegression();
    }
}