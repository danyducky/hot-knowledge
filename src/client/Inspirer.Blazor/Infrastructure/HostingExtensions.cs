using Inspirer.Blazor.Infrastructure.Dependencies;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Inspirer.Blazor.Infrastructure;

/// <summary>
/// Application hosting extensions.
/// </summary>
public static class HostingExtensions
{
    /// <summary>
    /// Build an application.
    /// </summary>
    /// <param name="builder">Application builder.</param>
    /// <returns>Application host.</returns>
    public static WebAssemblyHost BuildApplication(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        AddModulesServices(builder.Services, builder.Configuration);

        return builder.Build();
    }

    private static void AddModulesServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
    }

    /// <summary>
    /// Configure an application.
    /// </summary>
    /// <param name="app">Application host.</param>
    /// <returns>Application host.</returns>
    public static WebAssemblyHost ConfigureApplication(this WebAssemblyHost app)
    {
        return app;
    }
}
