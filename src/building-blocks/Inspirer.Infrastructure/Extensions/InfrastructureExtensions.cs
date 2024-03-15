using System.Reflection;
using Inspirer.Infrastructure.Bus;
using Inspirer.Infrastructure.Caching;
using Inspirer.Infrastructure.Middlewares;
using Inspirer.Infrastructure.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Inspirer.Infrastructure.Extensions;

/// <summary>
/// Application infrastructure extensions.
/// </summary>
public static class InfrastructureExtensions
{
    /// <summary>
    /// Add building blocks dependencies.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="options">Infrastructure options.</param>
    /// <param name="consumerAssembly">Reference to consumer assembly.</param>
    public static void AddBuildingBlocks(IServiceCollection services, InfrastructureOptions options,
        Assembly consumerAssembly)
    {
        services.AddMessageBus(options.RabbitMqOptions, consumerAssembly);
        services.AddRedisCache(options.RedisOptions);
    }

    /// <summary>
    /// Use building blocks dependencies.
    /// </summary>
    /// <param name="app">Application builder.</param>
    public static void UseBuildingBlocks(this IApplicationBuilder app)
    {
        app.UseMiddlewares();
    }
}
