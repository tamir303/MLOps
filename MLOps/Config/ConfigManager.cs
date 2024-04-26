namespace LinearRegression.Config;
using System.Configuration;

public static class ConfigManager
{
    public static Dictionary<string, string> Config { get; } = BuildConfiguration();
    private static Dictionary<string, string> BuildConfiguration()
    {
        try
        {
            var section = ConfigurationManager.AppSettings;
            return section.AllKeys
                .ToDictionary(key => key, key => section[key]);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}