using Identity.DataAccess;
using Inspirer.Infrastructure.Extensions;
using Inspirer.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Infrastructure.DI;

/// <summary>
/// Application infrastructure extensions.
/// </summary>
public static class InfrastructureExtensions
{
    /// <summary>
    /// Adds application infrastructure services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="configuration">Application configuration.</param>
    internal static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("AppDatabase"));
        });
    }
}
