namespace LinearRegression.Model;
using LinearRegression.Model.Implementations;
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
        var key = modelType.ToLower();  
        if (!_stringToEnumMap.ContainsKey(key))
            throw new ArgumentException($"Model type {modelType} not found");
        
        var model = _stringToEnumMap[key];
        model.CreateModel(new MLContext());

        return model;
    } 
}