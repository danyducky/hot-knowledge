using Identity.Api.Infrastructure.Dependencies;
using Inspirer.Infrastructure.Extensions;
using Inspirer.Infrastructure.Options;

namespace Identity.Api.Infrastructure;

/// <summary>
/// Application hosting extensions.
/// </summary>
public static class HostingExtensions
{
    /// <summary>
    /// Builds an application.
    /// </summary>
    /// <param name="builder">Application builder.</param>
    /// <returns>Web application.</returns>
    public static WebApplication BuildApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddBuildingBlocks(new InfrastructureOptions
        {
            RabbitMqOptions = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>(),
            RedisOptions = builder.Configuration.GetSection("Redis").Get<RedisOptions>(),
        }, consumerAssembly: typeof(Program).Assembly);

        AddModulesServices(builder.Services, builder.Configuration);

        builder.Services.AddControllers();

        return builder.Build();
    }

    private static void AddModulesServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices(configuration);
    }

    /// <summary>
    /// Configures web application.
    /// </summary>
    /// <param name="app">Web application to be configured.</param>
    /// <returns>Web application.</returns>
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseBuildingBlocks();

        app.MapControllers();

        return app;
    }
}
