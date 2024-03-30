using System.Security.Claims;
using System.Security.Cryptography;
using Identity.Abstractions.Authentication;

namespace Identity.UseCases.Tokens;

/// <summary>
/// Application authentication token generator.
/// </summary>
public class TokenGenerator
{
    private readonly ITokenService tokenService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="tokenService">Token service.</param>
    public TokenGenerator(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }

    /// <summary>
    /// Generate access and refresh tokens.
    /// </summary>
    /// <param name="claims">Token claims.</param>
    /// <returns>Access and refresh tokens.</returns>
    public TokenDto Generate(IEnumerable<Claim> claims)
    {
        var accessToken = tokenService.GenerateToken(claims, TokenConstants.AccessTokenExpiration);
        var refreshToken = GenerateRefreshToken();

        return new TokenDto(accessToken, refreshToken);
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}
