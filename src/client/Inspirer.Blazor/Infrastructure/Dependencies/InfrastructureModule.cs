using Inspirer.Infrastructure.Abstractions.Services;
using Inspirer.Infrastructure.Services;

namespace Inspirer.Client.Infrastructure.Dependencies;

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
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IIdentityService, IdentityService>();
        return services;
    }
}
