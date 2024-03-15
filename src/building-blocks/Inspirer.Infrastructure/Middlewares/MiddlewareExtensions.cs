using Microsoft.AspNetCore.Builder;

namespace Inspirer.Infrastructure.Middlewares;

/// <summary>
/// Application middleware extensions.
/// </summary>
internal static class MiddlewareExtensions
{
    /// <summary>
    /// Use application middlewares.
    /// </summary>
    /// <param name="app">Application builder.</param>
    public static void UseMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
