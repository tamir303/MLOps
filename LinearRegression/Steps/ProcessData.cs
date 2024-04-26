using LinearRegression.Config;
using LinearRegression.Data.Processing;
using LinearRegression.Data.Processing.Implementations;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LinearRegression.Steps;
using MathNet.Numerics.LinearAlgebra;

public class ProcessData
{
    public (
        Matrix<float> xTrain, Matrix<float> xVal, Vector<float> yTrain, Vector<float> yVal) Prepare(
        IEnumerable<List<string>> xTrainList, IEnumerable<List<string>> xValList,
        List<string> yTrainList, List<string> yValList)
    {
        // Parse the data from Enumerable to Matrix and Vector of type float
        var (xTrain, xVal, yTrain, yVal) = 
            StringToFloatParser.Parse(xTrainList, xValList, yTrainList, yValList);
        
        // Get the processor type from the config and create the strategy
        var processorType = ConfigManager.Config["processType"];
        var strategy = new ProcessStrategy(processorType switch
        {
            "Standard" => new Standard(),
            _ => throw new ArgumentException("Invalid processor type")
        });
        
        // Process each column of the matrix
        for (var i = 0; i < xTrain.ColumnCount; i++)
        {
            Vector<float> column = Vector<float>.Build.Dense(50);
            xVal.Column(0, column);
            xTrain.SetColumn(i, strategy.Process(xTrain.Column(0)));
            xVal.SetColumn(i, strategy.Process(xVal.Column(i)));
        }
        
        return (xTrain, xVal, yTrain, yVal);
    }
}