using LinearRegression.Steps;

namespace LinearRegression.Pipelines;

public class TrainingPipeline : IPipeline
{
    private IngestData _ingest_data;
    private ModelTrain _model_train;
    private ModelEval _model_eval;
    public TrainingPipeline(IngestData ingestData, ModelTrain modelTrain, ModelEval modelEval)
    {
        _ingest_data = ingestData;
        _model_train = modelTrain;
        _model_eval = modelEval;
    }
    
    public void Run()
    {
        var (xTrain, yTrain,
            xVal, yVal) = _ingest_data.GetData();
        
        var model = _model_train.Train(xTrain, yTrain);
        
        var (r2_score, mse) = _model_eval.Evaluation(model, xVal, yVal);
        Console.WriteLine($"Metrics: r2_score: {r2_score}  mse: {mse}");
    }
}