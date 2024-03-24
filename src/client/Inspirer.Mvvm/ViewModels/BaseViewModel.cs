using System.ComponentModel;

namespace Inspirer.Mvvm.ViewModels;

/// <summary>
/// Application base view model.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
{
    private readonly CancellationTokenSource cancellationTokenSource = new();

    private bool disposed;

    /// <summary>
    /// Property changed event.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// View model cancellation token.
    /// </summary>
    protected CancellationToken CancellationToken => cancellationTokenSource.Token;

    /// <summary>
    /// Indicates whether view model is busy or not.
    /// </summary>
    public bool IsBusy { get; set; }

    /// <summary>
    /// Load view model.
    /// </summary>
    public virtual Task LoadAsync() => Task.CompletedTask;

    /// <summary>
    /// Dispose view model.
    /// </summary>
    /// <param name="disposing">Is view model services must be disposed.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            cancellationTokenSource.Cancel();
        }

        disposed = true;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
