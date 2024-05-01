using Microsoft.ML;

namespace LinearRegression.Steps;
using LinearRegression.Model;
using LinearRegression.Model.Implementations;
using MathNet.Numerics.LinearAlgebra;
using LinearRegression.Config;

public class ModelTrain : IStep
{
    public ModelBase Train(
        Matrix<float> xTrain, Vector<float> yTrain)
    {
        // var isCached = ConfigManager.Config["cached"].Equals("Yes");
        var modelType = ConfigManager.Config["modelType"];
        
        // if (isCached)
        // {
        //     const string pathToModel = "MLOps/Save/{modelName}.xml";
        //     if (File.Exists(pathToModel))
        //     {
        //         model = ModelFactory.LoadModelFromFile(modelType, pathToModel);
        //         Console.WriteLine("Model Loaded Successfully...");
        //         return model;
        //     }
        //     
        //     Console.WriteLine("Didn't find model instance in path, creating new one...");
        // }

        var learningRate = float.Parse(ConfigManager.Config["learningRate"]);
        var epochs = int.Parse(ConfigManager.Config["epochs"]);
        var model = ModelFactory.GetModel(modelType);
        model.Train(xTrain, yTrain);
        
        Console.WriteLine("Model Trained Successfully...");
        return model;
    }
}