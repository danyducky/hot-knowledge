namespace Inspirer.Contracts.Identity;

/// <summary>
/// User email address confirmed event.
/// </summary>
/// <param name="UserId">User identifier.</param>
/// <param name="Email">User email.</param>
public record UserEmailConfirmedEvent(int UserId, string Email);
