using LinearRegression.Pipelines;
using LinearRegression.Steps;

new TrainingPipeline(
    new IngestData(),
    new ModelTrain(),
    new ModelEval())
    .Run();