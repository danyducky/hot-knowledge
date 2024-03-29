using System.Net.Mime;
using Identity.Domain.Entities;
using Inspirer.Contracts.Identity;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.UseCases.Consumers;

/// <summary>
/// Handler for <see cref="UserEmailConfirmedEvent"/>.
/// </summary>
public class UserEmailConfirmedConsumer : IConsumer<UserEmailConfirmedEvent>
{
    private readonly UserManager<User> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userManager">User manager.</param>
    public UserEmailConfirmedConsumer(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public async Task Consume(ConsumeContext<UserEmailConfirmedEvent> context)
    {
        var user = await userManager.Users.FirstAsync(
            user => user.Id == context.Message.UserId, context.CancellationToken);

        user.EmailConfirmed = true;

        await userManager.UpdateAsync(user);
    }
}




