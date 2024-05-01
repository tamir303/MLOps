namespace LinearRegression.Model.DataScheme;
using Microsoft.ML.Data;

public class InputPredictData
{
    [VectorType(1)]
    [ColumnName("Features")]
    public float[] Features { get; set; }
}