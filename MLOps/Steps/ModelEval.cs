using LinearRegression.Evaluate;

namespace LinearRegression.Steps;
using LinearRegression.Model;
using MathNet.Numerics.LinearAlgebra;

public class ModelEval : IStep
{
    public (float r2_score, float mse) Evaluation(
        ModelBase model, Matrix<float> x_val, Vector<float> y_val)
    {
        var predicted = model.Predict(x_val);

        var r2_score = R2.Score(predicted, y_val);
        var mse = MSE.Score(predicted, y_val);
        
        Console.WriteLine("Model Evaluated Successfully...");
        return (r2_score, mse);
    }
}