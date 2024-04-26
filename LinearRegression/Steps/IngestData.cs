using MathNet.Numerics.LinearAlgebra;
namespace LinearRegression.Steps;
using LinearRegression.Data;

public class IngestData
{
    private readonly string _trainFilePath = "C:\\Users\\tamir\\RiderProjects\\LinearRegression\\LinearRegression\\Data\\data_training.csv";
    private readonly string _valFilePath = "C:\\Users\\tamir\\RiderProjects\\LinearRegression\\LinearRegression\\Data\\data_validation.csv";
    
    public (
        List<List<string>> xTrain, List<string> yTrain, // Input and Output for Training
        List<List<string>> xVal, List<string> yVal, // Input and Output for Validation
        List<string> headers ) // Headers  
        GetData() 
    {
        try
        {   
            // Load Training DataSet
            var (xTrain, yTrain, headers) = LoadDataFromCsv.LoadFromPath(this._trainFilePath);
            // Load Validation DataSet
            var (xVal, yVal, _) = LoadDataFromCsv.LoadFromPath(this._valFilePath);
            
            Console.WriteLine("Ingested Data Successfully...");
            return (xTrain, yTrain, xVal, yVal, headers);
        }
        catch (FileLoadException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}