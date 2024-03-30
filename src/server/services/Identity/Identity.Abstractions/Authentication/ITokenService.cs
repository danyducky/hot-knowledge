using System.Security.Claims;

namespace Identity.Abstractions.Authentication;

/// <summary>
/// Authentication token service.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Generates a token.
    /// </summary>
    /// <param name="claims">Token claims.</param>
    /// <param name="expiration">Expiration time span.</param>
    /// <returns>Token.</returns>
    string GenerateToken(IEnumerable<Claim> claims, TimeSpan expiration);

    /// <summary>
    /// Gets token claims.
    /// </summary>
    /// <param name="token">Token.</param>
    /// <returns>Token claims.</returns>
    IEnumerable<Claim> GetClaims(string token);
}
