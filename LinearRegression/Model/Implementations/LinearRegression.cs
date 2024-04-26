using System.Xml.Serialization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

namespace LinearRegression.Model.Implementations;

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
        this._weights = Vector<float>.Build.Random(X.ColumnCount, new Normal(0, 1));
        this._bias = 0;

        for (var epoch = 0; epoch < epochs; epoch++)
        {
            // Get current feature vector and predicted value
            var predictions = X.Multiply(_weights) + _bias;

            // Compute gradients
            var gradientWeights = (2.0f / X.RowCount) * X.Transpose().Multiply(predictions - y);
            var gradientBias = (2.0f / X.RowCount) * (predictions - y).Sum();

            // Update weights and bias
            this._weights -= gradientWeights * learningRate;
            this._bias -= gradientBias * learningRate;
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