namespace Inspirer.Infrastructure.Abstractions.Models.Identity;

/// <summary>
/// User login data transfer object.
/// </summary>
public class UserLoginDto
{
    /// <summary>
    /// User email address.
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// User password.
    /// </summary>
    public string Password { get; init; }

    /// <summary>
    /// Remember user.
    /// </summary>
    public bool RememberMe { get; init; }
}
