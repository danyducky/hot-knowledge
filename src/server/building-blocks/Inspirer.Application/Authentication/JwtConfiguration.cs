using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Inspirer.Application.Authentication;

/// <summary>
/// JWT configuration.
/// </summary>
public class JwtConfiguration
{
    private readonly JwtCredentials credentials;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="credentials">JWT credentials.</param>
    public JwtConfiguration(JwtCredentials credentials)
    {
        this.credentials = credentials;
    }

    /// <summary>
    /// Setup application JWT options.
    /// </summary>
    /// <param name="options">JWT options.</param>
    public void Setup(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(credentials.Secret)),
            ValidIssuer = credentials.Issuer,
        };
    }
}
