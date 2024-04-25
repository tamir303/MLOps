using MathNet.Numerics.LinearAlgebra;
namespace LinearRegression.Steps;
using LinearRegression.Data;

public class IngestData
{
    private readonly string _trainFilePath = "LinearRegression/Data/data_training.csv";
    private readonly string _valFilePath = "LinearRegression/Data/data_validation.csv";
    
    public (Matrix<float> x_train, Vector<float> y_train,
        Matrix<float> x_val, Vector<float> y_val) GetData() 
    {
        try
        {   
            // Load Training DataSet
            var (x_train, y_train) = LoadDataFromCsv.LoadFromPath(this._trainFilePath);
            // Load Validation DataSet
            var (x_val, y_val) = LoadDataFromCsv.LoadFromPath(this._valFilePath);
            
            Console.WriteLine("Ingested Data Successfully...");
            return (x_train, y_train, x_val, y_val);
        }
        catch (FileLoadException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}