namespace LinearRegression.Model;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.IO;
using System.Xml.Serialization;

public abstract class AbstractModel: IModel
{
    // Override each method with the requested algorithm
    public abstract void Fit(Matrix<float> X, Vector<float> y, float learningRate, int epochs);
    public abstract Vector<float> Predict(Matrix<float> X);
    
    // Options to Load and Save trained model into an XML file
    public void Save(string filePath)
    {
        try
        {
            var modelType = this.GetType();
            var stream = File.Create(filePath);
            var serializer = new XmlSerializer(modelType);
            serializer.Serialize(stream, this);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    public static T Load<T>(string filePath) where T : AbstractModel
    {
        try
        {
            var stream = File.OpenRead(filePath);
            var serializer = new XmlSerializer(typeof(T));
            var serializedObj = serializer.Deserialize(stream);
            
            if (serializedObj == null)
                throw new Exception($"Error: Failed to deserialize file {filePath}");

            var obj = (T)serializedObj;
            return obj;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}