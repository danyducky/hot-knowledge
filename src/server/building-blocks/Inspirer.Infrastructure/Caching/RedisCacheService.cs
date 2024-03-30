using Inspirer.Application.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Inspirer.Infrastructure.Caching;

/// <summary>
/// Application redis cache service.
/// </summary>
internal class RedisCacheService : ICacheService
{
    private readonly IDistributedCache distributedCache;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="distributedCache">Distributed cache service.</param>
    public RedisCacheService(IDistributedCache distributedCache)
    {
        this.distributedCache = distributedCache;
    }

    /// <inheritdoc />
    public T Get<T>(string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var bytes = distributedCache.Get(key);
        if (bytes == null)
        {
            return default;
        }
        return System.Text.Json.JsonSerializer.Deserialize<T>(bytes);
    }

    /// <inheritdoc />
    public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(key);

        var bytes = await distributedCache.GetAsync(key, cancellationToken);
        if (bytes == null)
        {
            return default;
        }
        return System.Text.Json.JsonSerializer.Deserialize<T>(bytes);
    }

    /// <inheritdoc />
    public void Refresh(string key)
        => distributedCache.Refresh(key);

    /// <inheritdoc />
    public async Task RefreshAsync(string key, CancellationToken cancellationToken = default)
        => await distributedCache.RefreshAsync(key, cancellationToken);

    /// <inheritdoc />
    public void Remove(string key)
        => distributedCache.Remove(key);

    /// <inheritdoc />
    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        => await distributedCache.RemoveAsync(key, cancellationToken);

    /// <inheritdoc />
    public void Set<T>(string key, T value, TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(value);

        var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value);

        distributedCache.Set(key, bytes, new DistributedCacheEntryOptions
        {
            SlidingExpiration = slidingExpiration,
            AbsoluteExpiration = absoluteExpiration,
        });
    }

    /// <inheritdoc />
    public async Task SetAsync<T>(string key, T value, TimeSpan? slidingExpiration = null,
        DateTimeOffset? absoluteExpiration = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(value);

        var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value);

        await distributedCache.SetAsync(key, bytes, new DistributedCacheEntryOptions
        {
            SlidingExpiration = slidingExpiration,
            AbsoluteExpiration = absoluteExpiration,
        }, cancellationToken);
    }
}
