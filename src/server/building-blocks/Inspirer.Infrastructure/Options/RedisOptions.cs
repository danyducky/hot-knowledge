namespace Inspirer.Infrastructure.Options;

/// <summary>
/// Application Redis options.
/// </summary>
public record RedisOptions
{
    /// <summary>
    /// Redis host.
    /// </summary>
    public required string Host { get; init; }

    /// <summary>
    /// Redis password.
    /// </summary>
    public required string Password { get; init; }
}
