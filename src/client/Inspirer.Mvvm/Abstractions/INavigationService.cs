using Inspirer.Mvvm.ViewModels;

namespace Inspirer.Mvvm.Abstractions;

/// <summary>
/// Application navigation service.
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Navigate to view model.
    /// </summary>
    /// <typeparam name="TViewModel">View model type.</typeparam>
    void NavigateTo<TViewModel>()
        where TViewModel : BaseViewModel;

    /// <summary>
    /// Navigate to view model with assigned parameters.
    /// </summary>
    /// <param name="assignParameters">Assign parameters delegate.</param>
    /// <typeparam name="TViewModel">View model type.</typeparam>
    /// <typeparam name="TParameters">View model parameters type.</typeparam>
    void NavigateTo<TViewModel, TParameters>(Action<TParameters> assignParameters)
        where TViewModel : BaseViewModel, IWithParameters<TParameters>;
}
