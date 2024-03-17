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
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBuildingBlocks(new InfrastructureOptions()
        {
            RabbitMqOptions = configuration.GetSection("RabbitMq").Get<RabbitMqOptions>(),
            RedisOptions = configuration.GetSection("Redis").Get<RedisOptions>(),
        }, consumerAssembly: typeof(Program).Assembly);

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
