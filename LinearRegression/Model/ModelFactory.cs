namespace LinearRegression.Model;

public abstract class ModelFactory
{
    public static AbstractModel CreateCleanModel(string modelType)
    {
        if (modelType.Equals("LinearRegression"))
            return new LinearRegression();
        
        return null;
    }

    public static AbstractModel LoadModelFromFile(string modelType, string filePath)
    {
        if (modelType.Equals("LinearRegression"))
            return AbstractModel.Load<LinearRegression>(filePath);

        return null;
    }
}