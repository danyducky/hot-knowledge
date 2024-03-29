using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Infrastructure.Identity;

/// <summary>
/// Configuration for <see cref="IdentityOptions"/>.
/// </summary>
public static class IdentityConfiguration
{
    /// <summary>
    /// Setup identity options.
    /// </summary>
    /// <param name="options">Identity options instance.</param>
    public static void Setup(IdentityOptions options)
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireNonAlphanumeric = false;
    }
}
