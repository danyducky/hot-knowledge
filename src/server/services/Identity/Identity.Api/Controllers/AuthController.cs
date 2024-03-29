using Identity.UseCases.Tokens;
using Identity.UseCases.Tokens.RefreshToken;
using Identity.UseCases.Users.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

/// <summary>
/// Auth controller.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Log in user.
    /// </summary>
    /// <param name="user">Log in user data transfer object.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Access and refresh tokens.</returns>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<TokenDto> Login(LoginUserDto user, CancellationToken cancellationToken)
        => await mediator.Send(new LoginUserCommand(user), cancellationToken);

    /// <summary>
    /// Refresh access token by given refresh token.
    /// </summary>
    /// <param name="token">Refresh token data transfer object.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Newly created access and refresh token.</returns>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<TokenDto> Refresh(RefreshTokenDto token, CancellationToken cancellationToken)
        => await mediator.Send(new RefreshTokenCommand(token), cancellationToken);
}
