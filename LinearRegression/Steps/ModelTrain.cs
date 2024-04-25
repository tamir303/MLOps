namespace LinearRegression.Steps;
using LinearRegression.Model;
using MathNet.Numerics.LinearAlgebra;
using LinearRegression.Config;

public class ModelTrain
{
    public AbstractModel Train(
        Matrix<float> x_train, Vector<float> y_train)
    {
        var isCached = ConfigManager.Config["cached"].Equals("Yes");
        var modelType = ConfigManager.Config["modelType"];
        AbstractModel? model = null;
        
        if (isCached)
        {
            const string pathToModel = "LinearRegression/Save/{modelName}.xml";
            if (File.Exists(pathToModel))
            {
                model = ModelFactory.LoadModelFromFile(modelType, pathToModel);
                Console.WriteLine("Model Loaded Successfully...");
                return model;
            }
            
            Console.WriteLine("Didn't find model instance in path, creating new one...");
        }

        var learningRate = float.Parse(ConfigManager.Config["learningRate"]);
        var epochs = int.Parse(ConfigManager.Config["epochs"]);
        model = ModelFactory.CreateCleanModel(modelType);
        model.Fit(x_train, y_train, learningRate, epochs);
        
        Console.WriteLine("Model Trained Successfully...");
        return model;
    }
}