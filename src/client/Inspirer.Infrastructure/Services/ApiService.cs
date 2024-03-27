using Inspirer.Infrastructure.Abstractions.Services;
using Inspirer.Infrastructure.Abstractions.Models.Identity;

namespace Inspirer.Infrastructure.Services;

/// <summary>
/// Identity API service.
/// </summary>
public class ApiService : IIdentityService
{
    private readonly HttpClient client;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="client">Http client.</param>
    public ApiService(HttpClient client)
    {
        this.client = client;
    }

    /// <inheritdoc />
    public Task<UserTokenDto> LoginAsync(UserLoginDto dto) => throw new NotImplementedException();
}
