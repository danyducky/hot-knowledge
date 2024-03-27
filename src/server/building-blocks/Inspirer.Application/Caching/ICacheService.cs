namespace Inspirer.Application.Caching;

/// <summary>
/// Application cache service contract.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Gets cached object by given key.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <typeparam name="T">Object type.</typeparam>
    /// <returns>Object.</returns>
    T Get<T>(string key);

    /// <summary>
    /// Gets cached object by given key asynchronously.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <typeparam name="T">Object type.</typeparam>
    /// <returns>Object.</returns>
    Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Refresh cache by given key.
    /// </summary>
    /// <param name="key">Key.</param>
    void Refresh(string key);

    /// <summary>
    /// Refresh cache by given key asynchronously.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task RefreshAsync(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove cache by given key.
    /// </summary>
    /// <param name="key">Key.</param>
    void Remove(string key);

    /// <summary>
    /// Remove cache by given key asynchronously.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set cache with given key.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="value">Object value.</param>
    /// <param name="slidingExpiration">Sliding expiration.</param>
    /// <param name="absoluteExpiration">Absolute expiration.</param>
    /// <typeparam name="T">Object type.</typeparam>
    void Set<T>(string key, T value, TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null);

    /// <summary>
    /// Set cache with given key asynchronously.
    /// </summary>
    /// <param name="key">Key.</param>
    /// <param name="value">Object value.</param>
    /// <param name="slidingExpiration">Sliding expiration.</param>
    /// <param name="absoluteExpiration">Absolute expiration.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <typeparam name="T">Object type.</typeparam>
    Task SetAsync<T>(string key, T value, TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null, CancellationToken cancellationToken = default);
}
