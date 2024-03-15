using Inspirer.Application.Caching;
using Inspirer.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Inspirer.Infrastructure.Caching;

/// <summary>
/// Application caching extensions.
/// </summary>
public static class CachingExtensions
{
    /// <summary>
    /// Add redis caching dependencies.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="options">Redis options.</param>
    public static void AddRedisCache(this IServiceCollection services, RedisOptions options)
    {
        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = options.ConnectionString;
            opt.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
            {
                AbortOnConnectFail = true,
                EndPoints = { options.ConnectionString }
            };
        });

        services.AddTransient<ICacheService, RedisCacheService>();
    }
}
