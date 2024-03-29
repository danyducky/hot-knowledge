using Identity.Abstractions.Authentication;
using Inspirer.Application.Caching;
using Inspirer.Application.Exceptions;
using MediatR;

namespace Identity.UseCases.Tokens.RefreshToken;

/// <summary>
/// Handler for <see cref="RefreshTokenCommand"/>.
/// </summary>
internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenDto>
{
    private readonly ICacheService cacheService;
    private readonly ITokenService tokenService;
    private readonly TokenGenerator tokenGenerator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="cacheService">Cache service.</param>
    /// <param name="tokenService">Token service.</param>
    public RefreshTokenCommandHandler(ICacheService cacheService, ITokenService tokenService)
    {
        this.cacheService = cacheService;
        this.tokenService = tokenService;

        this.tokenGenerator = new TokenGenerator(tokenService);
    }

    /// <inheritdoc />
    public async Task<TokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await cacheService.GetAsync<TokenDto>(request.Token.RefreshToken, cancellationToken);
        if (token == null)
        {
            // Means that refresh token expired or isn't exists.
            throw new ForbiddenException("Given refresh token isn't valid.");
        }

        // Revoke previously created refresh token.
        await cacheService.RemoveAsync(token.RefreshToken, cancellationToken);

        // Get claims from access token.
        var claims = tokenService.GetClaims(token.AccessToken);

        // Regenerate token from access token claims.
        token = tokenGenerator.Generate(claims);

        // Save refresh token to cache.
        await cacheService.SetAsync(token.RefreshToken, token,
            absoluteExpiration: TokenConstants.RefreshTokenExpiration,
            cancellationToken: cancellationToken);

        return token;
    }
}
