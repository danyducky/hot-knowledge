namespace Inspirer.Infrastructure.Abstractions.Models.Identity;

/// <summary>
/// User authentication token data transfer object.
/// </summary>
public record UserTokenDto
{
    /// <summary>
    /// Authentication token.
    /// </summary>
    public string Token { get; init; }
}
