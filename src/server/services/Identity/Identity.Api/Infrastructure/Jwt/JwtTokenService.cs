using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.Abstractions.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Infrastructure.Jwt;

/// <summary>
/// Authentication JWT token service.
/// </summary>
public class JwtTokenService : ITokenService
{
    private readonly TokenValidationParameters validationParameters;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="jwtOptionsMonitor">JWT options.</param>
    public JwtTokenService(IOptionsMonitor<JwtBearerOptions> jwtOptionsMonitor)
    {
        validationParameters = jwtOptionsMonitor.Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters;
    }

    /// <inheritdoc />
    public string GenerateToken(IEnumerable<Claim> claims, TimeSpan expiration)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(expiration),
            issuer: validationParameters.ValidIssuer,
            audience: validationParameters.ValidAudience,
            signingCredentials: new SigningCredentials(
                validationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    /// <inheritdoc />
    public IEnumerable<Claim> GetClaims(string token)
    {
        var principal = new JwtSecurityTokenHandler()
            .ValidateToken(token, validationParameters, out _);
        return principal.Claims;
    }
}
