using Identity.Abstractions.Authentication;
using Identity.Domain.Entities;
using Identity.UseCases.Tokens;
using Inspirer.Application.Caching;
using Inspirer.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.UseCases.Users.LoginUser;

/// <summary>
/// Handler for <see cref="LoginUserCommand"/>.
/// </summary>
internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenDto>
{
    private readonly SignInManager<User> signInManager;
    private readonly ICacheService cacheService;
    private readonly TokenGenerator tokenGenerator;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="signInManager">Sign in manager.</param>
    /// <param name="cacheService">Cache service.</param>
    /// <param name="tokenService">Token service.</param>
    public LoginUserCommandHandler(
        SignInManager<User> signInManager,
        ICacheService cacheService,
        ITokenService tokenService)
    {
        this.signInManager = signInManager;
        this.cacheService = cacheService;
        this.tokenGenerator = new TokenGenerator(tokenService);
    }

    /// <inheritdoc />
    public async Task<TokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await signInManager.PasswordSignInAsync(request.User.Email, request.User.Password,
            lockoutOnFailure: false,
            isPersistent: request.User.RememberMe);

        ValidateSignInResult(result, request.User.Email);

        var user = await signInManager.UserManager.FindByEmailAsync(request.User.Email);
        if (user == null)
        {
            throw new ValidationException("Cannot find the user.");
        }

        // Create access token with user claims.
        var principal = await signInManager.CreateUserPrincipalAsync(user);
        var token = tokenGenerator.Generate(principal.Claims);

        // Save refresh token to cache.
        await cacheService.SetAsync(token.RefreshToken, token,
            absoluteExpiration: TokenConstants.RefreshTokenExpiration,
            cancellationToken: cancellationToken);

        return token;
    }

    private static void ValidateSignInResult(SignInResult signInResult, string email)
    {
        if (signInResult.Succeeded)
        {
            return;
        }

        if (signInResult.IsNotAllowed)
        {
            throw new ValidationException($"User {email} is not allowed to Sign In.");
        }
        if (signInResult.IsLockedOut)
        {
            throw new ValidationException($"User {email} is locked out.");
        }

        throw new ValidationException("Email or password is incorrect.");
    }
}
