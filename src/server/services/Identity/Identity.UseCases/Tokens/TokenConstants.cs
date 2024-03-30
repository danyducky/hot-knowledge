namespace Identity.UseCases.Tokens;

/// <summary>
/// Application token constants.
/// </summary>
internal static class TokenConstants
{
    /// <summary>
    /// Refresh token expiration time.
    /// </summary>
    public static readonly DateTimeOffset RefreshTokenExpiration = DateTimeOffset.UtcNow.AddDays(30);

    /// <summary>
    /// Access token expiration time.
    /// </summary>
    public static readonly TimeSpan AccessTokenExpiration = TimeSpan.FromMinutes(5);
}
