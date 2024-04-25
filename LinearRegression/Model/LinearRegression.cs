using System.Xml.Serialization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

namespace LinearRegression.Model;

[XmlRoot("LinearRegressionModel")]
public class LinearRegression: AbstractModel
{
    [XmlArray("Weights")]
    private Vector<float> _weights;
    private float _bias;
    
    public override void Fit(
        Matrix<float> X, Vector<float> y, float learningRate = 0.01f, int epochs = 50)
    {
        if (X.RowCount != y.Count)
            throw new ArgumentException("X rows count doesn't match y");
        
        // Initialize random coefficients values between -1 to 1
        this._weights = Vector<float>.Build.Random(X.RowCount, new Normal(0, 1));
        this._bias = 0;

        for (var epoch = 0; epoch < epochs; epoch++)
            for (var i = 0; i < X.RowCount; i++)
            {
                // Get current feature vector and predicted value
                var yPredicted = _weights.DotProduct(X.Row(i)) + _bias;

                // Compute gradients
                var deltaVector = Vector<float>.Build.Dense(X.ColumnCount, yPredicted - y[0]);
                var gradientWeights = deltaVector * X.Row(i) * learningRate;
                var gradientBias = deltaVector[0] * learningRate;
                
                // Update weights and bias
                this._weights -= gradientWeights;
                this._bias -= gradientBias;
            }
        
    }

    public override Vector<float> Predict(Matrix<float> X)
    {
        if (X.ColumnCount != this._weights.Count)
            throw new ArgumentException("X rows count doesn't match fitted data");
        
        // Calculate the product of X with the Coefficients.
        var predicted = Vector<float>.Build.DenseOfArray(X
            .ToRowArrays()
            .Select(sample => this.Predict(Vector<float>.Build.DenseOfArray(sample)))
            .ToArray());

        return predicted;
    }

    private float Predict(Vector<float> sample)
    {
        // Calculate the product of X with the Coefficients.
        return this._weights.DotProduct(sample) + this._bias;
    }
}