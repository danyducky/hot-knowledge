using System.ComponentModel.DataAnnotations;

namespace Identity.UseCases.Users.LoginUser;

/// <summary>
/// Login user data transfer object.
/// </summary>
public record LoginUserDto
{
    /// <summary>
    /// User email.
    /// </summary>
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; init; }

    /// <summary>
    /// User password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; init; }

    /// <summary>
    /// Remember user cookie for a longer time or not.
    /// </summary>
    public bool RememberMe { get; init; }
}
