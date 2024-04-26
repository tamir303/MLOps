namespace LinearRegression.Data.Processing;
using MathNet.Numerics.LinearAlgebra;

public class ProcessStrategy
{
    private IProcessor _processor;
    
    public ProcessStrategy(IProcessor processor)
    {
        _processor = processor;
    }
    
    public Vector<float> Process(Vector<float> data)
    {
        return _processor.Process(data);
    }
}