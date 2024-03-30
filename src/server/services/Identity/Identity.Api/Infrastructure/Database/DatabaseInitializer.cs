using Extensions.Hosting.AsyncInitialization;
using Identity.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Infrastructure.Database;

/// <summary>
/// Identity database initializer.
/// </summary>
public class DatabaseInitializer : IAsyncInitializer
{
    private readonly IdentityDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    public DatabaseInitializer(IdentityDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}
