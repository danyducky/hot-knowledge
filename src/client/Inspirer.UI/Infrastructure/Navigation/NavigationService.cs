using System.Collections.Immutable;
using Inspirer.Mvvm.Abstractions;
using Inspirer.Mvvm.ViewModels;
using Inspirer.UI.Infrastructure.Helpers;
using Microsoft.AspNetCore.Components;

namespace Inspirer.UI.Infrastructure.Navigation;

/// <summary>
/// Application navigation service.
/// </summary>
public class NavigationService : INavigationService
{
    private readonly NavigationManager navigationManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="navigationManager">Navigation manager.</param>
    public NavigationService(NavigationManager navigationManager)
    {
        this.navigationManager = navigationManager;
    }

    /// <inheritdoc />
    public void NavigateTo<TViewModel>()
        where TViewModel : BaseViewModel
    {
        var info = ComponentStorage.GetComponentInfo<TViewModel>();
        var path = RouteHelper.GetRoutePath(info.Route, ImmutableDictionary<string, object>.Empty);

        navigationManager.NavigateTo(path);
    }

    /// <inheritdoc />
    public void NavigateTo<TViewModel, TParameters>(Action<TParameters> assignParameters)
        where TViewModel : BaseViewModel, IWithParameters<TParameters>
    {
        var info = ComponentStorage.GetComponentInfo<TViewModel>();
        var parameters = CreateParameters(info.ComponentType, assignParameters);

        var routeValues = ComponentHelper.GetValues(info.RouteProperties, parameters);
        var queryValues = ComponentHelper.GetValues(info.QueryProperties, parameters);
        var path = RouteHelper.GetRoutePath(info.Route, routeValues, queryValues);

        navigationManager.NavigateTo(path);
    }

    private static TParameters CreateParameters<TParameters>(Type component, Action<TParameters> assignParameters)
    {
        var parameters = (TParameters)Activator.CreateInstance(component);

        assignParameters(parameters);

        return parameters;
    }
}
