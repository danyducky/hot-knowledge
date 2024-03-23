using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Inspirer.Infrastructure.Extensions;

/// <summary>
/// Application mapper extensions.
/// </summary>
public static class MapperExtensions
{
    /// <summary>
    /// Add application auto mapper.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="profileAssemblies">Auto mapper profile assemblies.</param>
    public static void AddMapper(this IServiceCollection services, params Assembly[] profileAssemblies)
    {
        services.AddAutoMapper(profileAssemblies);
    }
}
