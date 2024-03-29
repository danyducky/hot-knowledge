using MediatR;

namespace Identity.UseCases.Users.RegisterUser;

/// <summary>
/// Register user command.
/// </summary>
/// <param name="User">Register user data transfer object.</param>
public record RegisterUserCommand(RegisterUserDto User) : IRequest<int>;
