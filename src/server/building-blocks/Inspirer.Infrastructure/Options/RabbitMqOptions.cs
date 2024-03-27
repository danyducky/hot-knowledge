namespace Inspirer.Infrastructure.Options;

/// <summary>
/// Contains Rabbit MQ options.
/// </summary>
public record RabbitMqOptions
{
    /// <summary>
    /// Host address.
    /// </summary>
    public required string Host { get; init; }

    /// <summary>
    /// Exchange name.
    /// </summary>
    public required string ExchangeName { get; init; }

    /// <summary>
    /// User name.
    /// </summary>
    public required string UserName { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    public required string Password { get; init; }
}
