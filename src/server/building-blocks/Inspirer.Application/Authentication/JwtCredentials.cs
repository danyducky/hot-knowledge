namespace Inspirer.Application.Authentication;

/// <summary>
/// Application JWT credentials.
/// </summary>
/// <param name="Secret">JWT secret key.</param>
/// <param name="Issuer">JWT issuer.</param>
public record struct JwtCredentials(string Secret, string Issuer);
