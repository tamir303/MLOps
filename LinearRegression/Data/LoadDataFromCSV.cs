using System.Globalization;
using CsvHelper;
using MathNet.Numerics.LinearAlgebra;
namespace LinearRegression.Data;

public static class LoadDataFromCsv
{
    public static (Matrix<float> input, Vector<float> output) LoadFromPath(string filePath)
    {
        try
        {
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<dynamic>();
            
            // Retrieve headers to determine input and output columns
            // Initialize input columns based on header count
            var recordsCount = records.Count();
            var numOfColumns = csv.HeaderRecord.Length;
            var outputValues = new List<float>();
            var inputColumns = Enumerable.Range(0, recordsCount)
                .Select(_ => new List<float>())
                .ToList();  
            
            // Read records and populate input and output lists
            foreach (var record in records) 
                for (var i = 0; i < numOfColumns; i++)
                {
                    var value = Convert.ToSingle(record);
                    Console.WriteLine(value);
                    if (i == numOfColumns - 1)
                        inputColumns[i].Add(value);
                    else
                        outputValues.Add(value);
                }


            // Convert input columns to input matrix
            var inputMatrix = Matrix<float>.Build
                .DenseOfColumnArrays(inputColumns.ConvertAll(list => list.ToArray()));

            // Convert output values to output vector
            var outputVector = Vector<float>.Build
                .DenseOfArray(outputValues.ToArray());
            
            return (inputMatrix, outputVector);
        }
        catch (Exception ex)
        {
            throw new FileLoadException($"Error: Failed to load {filePath}", ex);
        }
    }
}