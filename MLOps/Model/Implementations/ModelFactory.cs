namespace LinearRegression.Model.Implementations;

public abstract class ModelFactory
{
    public static AbstractModel CreateCleanModel(string modelType)
    {
        if (modelType.Equals("MLOps"))
            return new LinearRegression();
        
        return null;
    }

    public static AbstractModel LoadModelFromFile(string modelType, string filePath)
    {
        if (modelType.Equals("MLOps"))
            return AbstractModel.Load<LinearRegression>(filePath);

        return null;
    }
}