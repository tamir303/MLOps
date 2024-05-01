namespace LinearRegression.Model.DataScheme;
using Microsoft.ML.Data;

public class InputTrainData
{
    [VectorType(1)]
    [ColumnName("Features")]
    public float[] Features { get; set; }
    [ColumnName("Label")]
    public float Label { get; set; }
}