using System.Text.Json;
using System.Text.Json.Serialization;
using Inspirer.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Inspirer.Infrastructure.Middlewares;

/// <summary>
/// Application exception middleware.
/// </summary>
public class ExceptionMiddleware : IMiddleware
{
    private const string MimeType = "application/problem+json";

    private static readonly Dictionary<Type, int> ExceptionStatusCodes = new()
    {
        { typeof(ValidationException), StatusCodes.Status400BadRequest },
        { typeof(UnauthorizedException), StatusCodes.Status401Unauthorized },
        { typeof(ForbiddenException), StatusCodes.Status403Forbidden },
        { typeof(NotFoundException), StatusCodes.Status404NotFound },
    };

    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    private readonly IHostEnvironment environment;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="environment">Application host environment.</param>
    public ExceptionMiddleware(IHostEnvironment environment)
    {
        this.environment = environment;
    }

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            if (context.Response.HasStarted)
            {
                throw;
            }

            var details = GetProblemDetails(context, exception);
            var json = JsonSerializer.Serialize(details, Options);

            context.Response.ContentType = MimeType;

            await context.Response.WriteAsync(json);
        }
    }

    private ProblemDetails GetProblemDetails(HttpContext context, Exception exception)
    {
        var details = new ProblemDetails
        {
            Title = GetExceptionTitle(exception),
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.ToString(),
        };

        if (ExceptionStatusCodes.TryGetValue(exception.GetType(), out var statusCode))
        {
            details.Status = statusCode;
        }

        if (environment.IsProduction())
        {
            return details;
        }

        details.Extensions["traceId"] = context.TraceIdentifier;
        details.Extensions["data"] = exception.Data;

        return details;
    }

    private static string GetExceptionTitle(Exception exception) => exception switch
    {
        UnauthorizedException => "Unauthorized",
        ForbiddenException => "Forbidden",
        NotFoundException => "Not Found",
        _ => "Internal server error",
    };
}
