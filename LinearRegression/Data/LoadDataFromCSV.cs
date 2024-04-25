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
            var xList = new List<float>();
            var yList = new List<float>();

            foreach (var record in records)
            {
                float xVal = Convert.ToSingle(record.SAT);
                float yVal = Convert.ToSingle(record.GPA);
                xList.Add(xVal);
                yList.Add(yVal);
            }

            // Convert lists to MathNet.Numerics data structures
            var xMatrix = Matrix<float>.Build.DenseOfColumnArrays(new[] { xList.ToArray() });
            var yVector = Vector<float>.Build.DenseOfArray(yList.ToArray());

            return (xMatrix, yVector);
        }
        catch (Exception ex)
        {
            throw new FileLoadException($"Error: Failed to load {filePath}");
        }
    }
}