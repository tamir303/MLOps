using Microsoft.ML.Data;
namespace LinearRegression.Model.DataScheme;


public class OutputData
{
    [ColumnName("Label")]
    public float Label { get; set; }
}