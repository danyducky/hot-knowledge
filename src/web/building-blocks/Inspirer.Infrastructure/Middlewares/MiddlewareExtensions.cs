using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Inspirer.Infrastructure.Middlewares;

/// <summary>
/// Application middleware extensions.
/// </summary>
internal static class MiddlewareExtensions
{
    /// <summary>
    /// Adds application middlewares.
    /// </summary>
    /// <param name="services">Services collection.</param>
    public static void AddMiddlewares(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
    }

    /// <summary>
    /// Use application middlewares.
    /// </summary>
    /// <param name="app">Application builder.</param>
    public static void UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
