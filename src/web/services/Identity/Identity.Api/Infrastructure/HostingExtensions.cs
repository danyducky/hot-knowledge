using Identity.Api.Infrastructure.DI;
using Inspirer.Infrastructure.Extensions;
using Inspirer.Infrastructure.Options;

namespace Identity.Api.Configuration;

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

        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddMapper();

        builder.Services.AddControllers();

        return builder.Build();
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
