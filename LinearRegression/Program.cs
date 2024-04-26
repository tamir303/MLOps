using LinearRegression.Pipelines;
using LinearRegression.Steps;

var training = new TrainingPipeline(
    new IngestData(),
    new ProcessData(),
    new ModelTrain(),
    new ModelEval());
    
training.Run();