using System.Globalization;
using CsvHelper;
namespace LinearRegression.Data;

public static class LoadDataFromCsv
{
    public static (List<List<string>> input, List<string> target, List<string> headers) 
        LoadFromPath(string filePath)
    {
        try
        {
            if (String.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new FileNotFoundException();
            
            
            // Load the data from the CSV file and read the headers
            var reader = new StreamReader(filePath);
            
            // Read the headers
            var line = reader.ReadLine();
            
            // Initialize the input list and output list
            var headers = line.Split(',').ToList();
            var input = Enumerable.Range(0, headers.Count - 1)
                .Select(_ => new List<string>()).ToList();
            var target = new List<string>();

            // Read the data from the CSV file and store it in the input and output lists
            while ((line = reader.ReadLine()) != null)
            {
                var row = line.Split(',').ToList();
                Enumerable.Zip(Enumerable.Range(0, headers.Count - 1), row)
                    .ToList()
                    .ForEach(pair => input[pair.First].Add(pair.Second));
                target.Add(row.Last());
            }
            
            return (input, target, headers);
        }
        catch (Exception ex)
        {
            throw new FileLoadException($"Error: Failed to load {filePath}", ex);
        }
    }
}