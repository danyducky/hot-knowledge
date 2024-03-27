using Inspirer.Infrastructure.Abstractions.Models.Identity;

namespace Inspirer.Infrastructure.Abstractions.Services;

/// <summary>
/// Identity API service.
/// </summary>
public interface IIdentityService
{
    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="dto">User login.</param>
    /// <returns>User token.</returns>
    Task<UserTokenDto> LoginAsync(UserLoginDto dto);
}
