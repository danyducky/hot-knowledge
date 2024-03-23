namespace Inspirer.Infrastructure.Options;

/// <summary>
/// Application infrastructure options.
/// </summary>
public record InfrastructureOptions
{
    /// <summary>
    /// Application Rabbit MQ options.
    /// </summary>
    public required RabbitMqOptions RabbitMqOptions { get; init; }

    /// <summary>
    /// Application Redis options.
    /// </summary>
    public required RedisOptions RedisOptions { get; init; }
}
