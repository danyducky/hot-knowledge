using Identity.Abstractions.Authentication;
using Identity.Api.Infrastructure.Database;
using Identity.Api.Infrastructure.Identity;
using Identity.Api.Infrastructure.Jwt;
using Identity.DataAccess;
using Identity.Domain.Entities;
using Identity.UseCases.Consumers;
using Identity.UseCases.Users.RegisterUser;
using Inspirer.Application.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Infrastructure.Dependencies;

/// <summary>
/// Application infrastructure extensions.
/// </summary>
public static class ApplicationModule
{
    /// <summary>
    /// Adds application infrastructure services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="configuration">Application configuration.</param>
    internal static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Application database.
        services.AddDbContext(configuration);

        // Application infrastructure.
        services.AddAutoMapper(assemblies: typeof(UserEmailConfirmedConsumer).Assembly);

        // Application mediatr.
        services.AddMediatR(config =>
        {
            config.Lifetime = ServiceLifetime.Scoped;

            config.RegisterServicesFromAssemblies(typeof(RegisterUserCommand).Assembly);
        });

        // Identity.
        services.Configure<IdentityOptions>(IdentityConfiguration.Setup);

        // Jwt.
        var jwtCredentials = configuration.GetSection("Jwt").Get<JwtCredentials>();
        var jwtConfiguration = new JwtConfiguration(jwtCredentials);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtConfiguration.Setup);

        // Application services.
        AddServices(services);
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("AppDatabase"));
        });

        services.AddAsyncInitializer<DatabaseInitializer>();

        services
            .AddIdentity<User, Role>()
            .AddEntityFrameworkStores<IdentityDbContext>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ITokenService, JwtTokenService>();
    }
}
