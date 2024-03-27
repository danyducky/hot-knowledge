using Inspirer.Mvvm.Abstractions;

namespace Inspirer.Mvvm.ViewModels.Route;

/// <summary>
/// Route view model parameters.
/// </summary>
public interface IRouteViewModelParameters
{
    /// <summary>
    /// Route text.
    /// </summary>
    string Text { get; set; }

    /// <summary>
    /// Route name.
    /// </summary>
    string Name { get; set; }
}

/// <summary>
/// TODO: Remove this.
/// </summary>
public class RouteViewModel : BaseViewModel, IWithParameters<IRouteViewModelParameters>
{
    private readonly INavigationService navigationService;

    /// <inheritdoc />
    public IRouteViewModelParameters Parameters { get; }

    /// <summary>
    /// Route text.
    /// </summary>
    public string Route { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="parameters">View model parameters.</param>
    /// <param name="navigationService">Navigation service.</param>
    public RouteViewModel(
        IRouteViewModelParameters parameters,
        INavigationService navigationService)
    {
        this.navigationService = navigationService;

        Parameters = parameters;
    }

    public void GoToRoute()
    {
        navigationService.NavigateTo<RouteViewModel, IRouteViewModelParameters>(parameters =>
        {
            parameters.Text = Route;
            parameters.Name = "Danil";
        });
    }
}
