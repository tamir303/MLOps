using LinearRegression.Config;
using LinearRegression.Data.Processing;
namespace LinearRegression.Steps;
using MathNet.Numerics.LinearAlgebra;

public class ProcessData
{
    public (Matrix<float> x_train, Matrix<float> x_val) Prepare(
        Matrix<float> x_train, Matrix<float> x_val)
    {
        // Get the processor type from the config and create the strategy
        var processorType = ConfigManager.Config["ProcessorType"];
        var strategy = new ProcessStrategy(processorType switch
        {
            "Standard" => new Standard(),
            _ => throw new ArgumentException("Invalid processor type")
        });
        
        // Process the data in x_train
        foreach (var (i, column) in x_train.EnumerateColumnsIndexed())
            x_train.SetColumn(i, strategy.Process(column));
        
        // Process the data in x_val
        foreach (var (i, column) in x_val.EnumerateColumnsIndexed())
            x_train.SetColumn(i, strategy.Process(column));
        
        return (x_train, x_val);
    }
}