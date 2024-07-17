namespace AutoMarket.Extensions;

public static class ConfigurationExtensions
{
    public static string GetConnectionStringOrThrow(this IConfiguration configuration, string connectionName)
    {
        return configuration
                .GetConnectionString(connectionName) ??
            throw new InvalidOperationException(
                $"The connection string {connectionName} was not found in the application configuration");
    }
}