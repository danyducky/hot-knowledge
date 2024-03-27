using Microsoft.AspNetCore.Http;

namespace Inspirer.Infrastructure.Middlewares;

/// <summary>
/// Application exception middleware.
/// </summary>
public class ExceptionMiddleware : IMiddleware
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ExceptionMiddleware()
    {

    }

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            // Handle an application exception and unify a response message.
        }
    }
}
