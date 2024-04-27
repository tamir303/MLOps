using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LinearRegression.Data.Processing;

public class StringToFloatParser
{
    private static Dictionary<string, int> _encoding = new Dictionary<string, int>();
    
    public static (Matrix<float> xTrain, Matrix<float> xVal, Vector<float> yTrain, Vector<float> yVal)
        Parse(IEnumerable<List<string>> xTrain, IEnumerable<List<string>> xVal, List<string> yTrain, List<string> yVal)
    {
        return (ParseMatrix(xTrain), ParseMatrix(xVal), ParseVector(yTrain), ParseVector(yVal));
    }
    
    private static Vector<float> ParseVector(List<string> data)
    {
        if (data == null || data.Count == 0)
            throw new ArgumentException("Data is empty");
        
        // Check if all values are numbers, true -> all values are numbers
        var allNumbers = !data.Exists(value => !float.TryParse(value, out _));
        
        if (allNumbers)
            // Parse the data in the vector as float
            return Vector<float>.Build.DenseOfArray(data.Select(float.Parse).ToArray());
        
        
        // If not all values are numbers, encode the data
        data.ForEach(sample => {
            if (!_encoding.ContainsKey(sample))
                _encoding.Add(sample, _encoding.Count);
        });
        
        // Parse the data in the vector as float
         return Vector<float>.Build.DenseOfArray(
             data.Select(sample => (float) _encoding[sample]).ToArray());
    }
    
    private static Matrix<float> ParseMatrix(IEnumerable<List<string>> data)
    {
        return Matrix<float>.Build.DenseOfColumns(
            data.Select(ParseVector).ToList());
    }
}