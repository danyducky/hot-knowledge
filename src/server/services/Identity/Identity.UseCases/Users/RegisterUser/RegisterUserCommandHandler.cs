using AutoMapper;
using Identity.Domain.Entities;
using Inspirer.Application.Bus;
using Inspirer.Application.Exceptions;
using Inspirer.Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.UseCases.Users.RegisterUser;

/// <summary>
/// Handler for <see cref="RegisterUserCommand"/>.
/// </summary>
internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;
    private readonly IMessageBus messageBus;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mapper">Auto mapper.</param>
    /// <param name="userManager">User manager.</param>
    /// <param name="messageBus">Message bus.</param>
    public RegisterUserCommandHandler(IMapper mapper, UserManager<User> userManager, IMessageBus messageBus)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.messageBus = messageBus;
    }

    /// <inheritdoc />
    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.User);

        var result = await userManager.CreateAsync(user, request.User.Password);
        if (!result.Succeeded)
        {
            throw new ValidationException(
                result.Errors.ToDictionary(error => error.Code, error => error.Description));
        }

        // TODO: probably we must use Saga orchestrator.
        var @event = mapper.Map<UserRegisteredEvent>(user);

        await messageBus.PublishAsync(@event, cancellationToken);

        return user.Id;
    }
}
