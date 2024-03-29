using Inspirer.Contracts.Events;

namespace Inspirer.Contracts.Identity;

/// <summary>
/// User registered event.
/// </summary>
public record UserRegisteredEvent : IIntegrationEvent
{
    /// <summary>
    /// User identifier.
    /// </summary>
    public required int UserId { get; init; }

    /// <summary>
    /// User email.
    /// </summary>
    public required string Email { get; init; }
}
