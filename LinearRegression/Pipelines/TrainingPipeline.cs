using LinearRegression.Steps;

namespace LinearRegression.Pipelines;

public class TrainingPipeline : IPipeline
{
    private IngestData _ingest_data;
    private ModelTrain _model_train;
    private ModelEval _model_eval;
    private ProcessData _processData;
    public TrainingPipeline(IngestData ingestData, ProcessData processData, ModelTrain modelTrain, ModelEval modelEval)
    {
        _ingest_data = ingestData;
        _model_train = modelTrain;
        _model_eval = modelEval;
        _processData = processData;
    }
    
    public void Run()
    {
        // TODO Figure what to do with the headers
        
        // Get the data
        var (xTrainList, yTrainList,
            xValList, yValList, headers) = _ingest_data.GetData();
        
        // Process the data
        var (xTrain, xVal, yTrain, yVal) = 
            _processData.Prepare(xTrainList, xValList, yTrainList, yValList);
        
        // Train the model
        var model = _model_train.Train(xTrain, yTrain);
        
        // Evaluate the model
        var (r2_score, mse) = _model_eval.Evaluation(model, xVal, yVal);
        Console.WriteLine($"Metrics: r2_score: {r2_score}  mse: {mse}");
    }
}