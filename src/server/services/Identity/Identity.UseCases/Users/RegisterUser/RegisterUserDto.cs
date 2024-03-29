using System.ComponentModel.DataAnnotations;

namespace Identity.UseCases.Users.RegisterUser;

/// <summary>
/// Register user data transfer object.
/// </summary>
public record RegisterUserDto
{
    /// <summary>
    /// User email address.
    /// </summary>
    [Required]
    [EmailAddress]
    [StringLength(256)]
    public required string Email { get; init; }

    /// <summary>
    /// User first name.
    /// </summary>
    [Required]
    [MaxLength(64)]
    public required string FirstName { get; init; }

    /// <summary>
    /// User last name.
    /// </summary>
    [Required]
    [MaxLength(64)]
    public required string LastName { get; init; }

    /// <summary>
    /// User password.
    /// </summary>
    [Required]
    [StringLength(64, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}
