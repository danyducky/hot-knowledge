using Inspirer.Infrastructure.Abstractions.Services;
using Inspirer.Infrastructure.Services;

namespace Inspirer.Blazor.Infrastructure.Dependencies;

/// <summary>
/// Application infrastructure module.
/// </summary>
public static class InfrastructureModule
{
    /// <summary>
    /// Add an application infrastructure services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="configuration">Application configuration.</param>
    /// <returns>Services collection.</returns>
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiServices(configuration);
    }

    private static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add an Http Client to the main API service.
        services.AddHttpClient<ApiService>(client =>
        {
            var url = configuration["Application:ApiGateway"];

            ArgumentNullException.ThrowIfNull(url, nameof(url));

            client.BaseAddress = new Uri(url);
        });

        // Add APIs interfaces.
        services.AddSingleton<IIdentityService>(provider => provider.GetRequiredService<ApiService>());
    }
}
