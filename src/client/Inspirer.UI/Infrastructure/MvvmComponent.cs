using System.ComponentModel;
using Inspirer.Mvvm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Inspirer.UI.Infrastructure;

/// <summary>
/// Application MVVM component with parameters.
/// </summary>
/// <typeparam name="TViewModel">View model type.</typeparam>
/// <typeparam name="TViewModelParameters">View model parameters type.</typeparam>
public abstract class MvvmComponent<TViewModel, TViewModelParameters> : MvvmComponent<TViewModel>
    where TViewModel : BaseViewModel, IWithParameters<TViewModelParameters>
    where TViewModelParameters : class
{
    /// <inheritdoc />
    protected override TViewModel CreateViewModel()
    {
        var parameters = this as TViewModelParameters;

        return ViewModelFactory.Create<TViewModel>(parameters);
    }
}

/// <summary>
/// Application MVVM component.
/// </summary>
/// <typeparam name="TViewModel">View model type.</typeparam>
public abstract class MvvmComponent<TViewModel> : ComponentBase, IDisposable
    where TViewModel : BaseViewModel
{
    private bool disposed;

    /// <summary>
    /// Component view model.
    /// </summary>
    protected TViewModel ViewModel { get; private set; }

    /// <summary>
    /// View model factory.
    /// </summary>
    [Inject]
    protected ViewModelFactory ViewModelFactory { get; private set; }

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        // Create a view model.
        ViewModel = CreateViewModel();

        // Load view model.
        ViewModel.IsBusy = true;
        try
        {
            await ViewModel.LoadAsync();
        }
        finally
        {
            ViewModel.IsBusy = false;
        }

        // Subscribe to view model updates.
        // Refresh component when it's changed.
        Subscribe(ViewModel);
    }

    /// <summary>
    /// Creates <see cref="TViewModel"/> instance.
    /// </summary>
    /// <returns>View model instance.</returns>
    protected virtual TViewModel CreateViewModel()
    {
        return ViewModelFactory.Create<TViewModel>();
    }

    private void Subscribe(TViewModel viewModel)
    {
        viewModel.PropertyChanged += ViewModelOnPropertyChanged;
    }

    private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        => StateHasChanged();

    /// <summary>
    /// Dispose component.
    /// </summary>
    /// <param name="disposing">Is component services must be disposed.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            ViewModel?.Dispose();
        }

        disposed = true;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
