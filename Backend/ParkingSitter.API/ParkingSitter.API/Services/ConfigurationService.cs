namespace ParkingSitter.API.Services;
public class ConfigurationService
{
    public IConfigurationRoot ConfigurationHandler()
    {
        var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables();
        return builder.Build();
    }
}