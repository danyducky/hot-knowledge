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
    protected override void OnViewModelCreated(TViewModel viewModel)
    {
        viewModel.Parameters = this as TViewModelParameters;
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
        ViewModel = ViewModelFactory.Create<TViewModel>();

        OnViewModelCreated(ViewModel);

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
    /// Method invoked when view model successfully created.
    /// </summary>
    /// <param name="viewModel">View model instance.</param>
    protected virtual void OnViewModelCreated(TViewModel viewModel)
    {
        // Can be overriden by other components.
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
