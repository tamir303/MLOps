using System.Collections;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.ML;
using Microsoft.ML.Data;
using LinearRegression.Model.DataScheme;
namespace LinearRegression.Model;

public abstract class ModelBase : IModel
{
    protected dynamic _model; // Can be ITransformer or IEstimator
    protected ITransformer _dataPrepTransformer;
    protected MLContext _mlContext;
    
    public virtual void CreateModel(MLContext mlContext)
    {
        throw new NotImplementedException("CreateModel method not implemented");
    }

    public void Train(Matrix<float> xTrain, Vector<float> yTrain)
    {
        // Load data from matrix and vector to IDataView object
        var dataView = this._mlContext.Data.LoadFromEnumerable(
            DataSchemeUtils.DataToEnumerable(xTrain, yTrain)) as IDataView;
        
        // Concatenate features and label
        // Apply transforms to training data
        var dataPrepEstimator = this._mlContext.Transforms
            .Concatenate("Features", "Label");
        _dataPrepTransformer = dataPrepEstimator.Fit(dataView);
        var transformedTrainingData  = _dataPrepTransformer.Transform(dataView);
        
        // Train model with transformed data
        this._model = _model.Fit(transformedTrainingData);
    }

    public Vector<float> Predict(Matrix<float> data)
    {
        if (_model == null)
            throw new InvalidOperationException("Model is not trained yet");
        
        var dataView = this._mlContext.Data.LoadFromEnumerable(
            DataSchemeUtils.DataToEnumerable(data)) as IDataView;
        
        var predictionFunction = _mlContext.Model.CreatePredictionEngine<InputPredictData, OutputData>(_model);
        var enumerator = dataView.GetRowCursor(dataView.Schema);
        while (enumerator.MoveNext())
        {
            var input = enumerator.GetGetter<OutputData>()
        }
    }

    public float Predict(Vector<float> data)
    {
        throw new NotImplementedException();
    }
}