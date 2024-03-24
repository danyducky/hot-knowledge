using Inspirer.Mvvm.Abstractions;
using Inspirer.Mvvm.ViewModels;
using Inspirer.UI.Infrastructure.Navigation;
using Microsoft.AspNetCore.Components;

namespace Inspirer.Blazor.Infrastructure.Dependencies;

/// <summary>
/// Application mvvm module.
/// </summary>
public static class MvvmModule
{
    /// <summary>
    /// Add an application mvvm services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    public static void AddMvvmServices(this IServiceCollection services)
    {
        services.AddScoped<ViewModelFactory>();

        services.AddSingleton<INavigationService, NavigationService>();
    }
}
