using Inspirer.Application.Caching;
using Inspirer.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

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
            opt.ConfigurationOptions = new ConfigurationOptions
            {
                EndPoints = { options.Host },
                Password = options.Password,

                AbortOnConnectFail = true,
            };
        });

        services.AddTransient<ICacheService, RedisCacheService>();
    }
}
