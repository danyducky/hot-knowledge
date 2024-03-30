using MediatR;

namespace Identity.UseCases.Tokens.RefreshToken;

/// <summary>
/// Refresh access token command.
/// </summary>
/// <param name="Token">Refresh token data transfer object.</param>
public record RefreshTokenCommand(RefreshTokenDto Token) : IRequest<TokenDto>;
