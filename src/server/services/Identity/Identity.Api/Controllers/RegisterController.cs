using Identity.UseCases.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

/// <summary>
/// Register controller.
/// </summary>
[ApiController]
[Route("api/register")]
public class RegisterController :  ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator">Mediator.</param>
    public RegisterController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Register user.
    /// </summary>
    /// <param name="user">Register user data transfer object.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User identifier.</returns>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<int> Register(RegisterUserDto user, CancellationToken cancellationToken)
        => await mediator.Send(new RegisterUserCommand(user), cancellationToken);
}
