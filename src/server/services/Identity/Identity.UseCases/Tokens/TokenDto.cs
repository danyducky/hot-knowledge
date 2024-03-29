namespace Identity.UseCases.Tokens;

/// <summary>
/// Authentication access and refresh tokens data transfer object.
/// </summary>
/// <param name="AccessToken">Authentication access token.</param>
/// <param name="RefreshToken">Refresh token.</param>
public record TokenDto(string AccessToken, string RefreshToken);
