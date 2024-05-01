namespace LinearRegression.Model.DataScheme;
using LinearRegression.Model.DataScheme;
using MathNet.Numerics.LinearAlgebra;

public static class DataSchemeUtils
{
    public static IEnumerable<InputTrainData> DataToEnumerable(Matrix<float> xTrain, Vector<float> yTrain)
    {
        var data = Enumerable
            .Range(0, xTrain.RowCount)
            .Select(i => new InputTrainData { Features = xTrain.Row(i).ToArray(), Label = yTrain[i] });

        return data;
    }
    
    public static IEnumerable<InputPredictData> DataToEnumerable(Matrix<float> input)
    {
        var data = Enumerable
            .Range(0, input.RowCount)
            .Select(i => new InputPredictData { Features = input.Row(i).ToArray() });

        return data;
    }
}