using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DataAccess;

/// <summary>
/// Identity database context.
/// </summary>
public class IdentityDbContext : IdentityDbContext<User, Role, int>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options">Database options.</param>
    public IdentityDbContext(DbContextOptions options) : base(options)
    {
    }
}
