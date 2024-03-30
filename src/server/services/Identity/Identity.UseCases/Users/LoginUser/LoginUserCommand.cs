using Identity.UseCases.Tokens;
using MediatR;

namespace Identity.UseCases.Users.LoginUser;

/// <summary>
/// Login user command.
/// </summary>
/// <param name="User">Auth user data transfer object.</param>
public record LoginUserCommand(LoginUserDto User) : IRequest<TokenDto>;
