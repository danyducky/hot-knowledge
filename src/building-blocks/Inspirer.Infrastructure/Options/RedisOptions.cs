namespace Inspirer.Infrastructure.Options;

/// <summary>
/// Application Redis options.
/// </summary>
public record RedisOptions
{
    /// <summary>
    /// Redis connection string.
    /// </summary>
    public required string ConnectionString { get; init; }
}
