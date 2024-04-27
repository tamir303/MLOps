using Microsoft.ML;

namespace LinearRegression.Model.Implementations;

public class MultinomialLogisticRegression : ModelBase
{
    public override IEstimator<ITransformer> CreateModel(MLContext mlContext)
    {
        return mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy();
    }
}