namespace LinearRegression.Model;
using LinearRegression.Model.Implementations;
using LinearRegression.Model;
using Microsoft.ML;

public abstract class ModelFactory
{
    private static Dictionary<string, ModelBase> _stringToEnumMap
        = new Dictionary<string, ModelBase>
    {
        { "linearregression", new LinearRegression() },
        { "logisticregression", new BinaryLogisticRegression() },
        { "softmax", new MultinomialLogisticRegression() }
        
    };
    
    public static ModelBase GetModel(string modelType)
    {
        if (!_stringToEnumMap.ContainsKey(modelType))
            throw new ArgumentException($"Model type {modelType} not found");
        
        var mlContext = new MLContext();
        return _stringToEnumMap[modelType].CreateModel(mlContext);
    } 
}