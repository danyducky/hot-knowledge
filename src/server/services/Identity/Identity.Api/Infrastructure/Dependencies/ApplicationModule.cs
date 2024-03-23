using Identity.DataAccess;
using Inspirer.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Infrastructure.Dependencies;

/// <summary>
/// Application infrastructure extensions.
/// </summary>
public static class ApplicationModule
{
    /// <summary>
    /// Adds application infrastructure services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="configuration">Application configuration.</param>
    internal static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);

        services.AddMapper();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("AppDatabase"));
        });
    }
}
