using Microsoft.Extensions.DependencyInjection;

namespace Inspirer.Mvvm.ViewModels;

/// <summary>
/// Application view models factory.
/// </summary>
public class ViewModelFactory
{
    private readonly IServiceProvider serviceProvider;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ViewModelFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Create an instance of <see cref="TViewModel"/>.
    /// </summary>
    /// <param name="parameters">View model parameters.</param>
    /// <typeparam name="TViewModel">View model type.</typeparam>
    /// <returns>Instance of <see cref="TViewModel"/>.</returns>
    public TViewModel Create<TViewModel>(params object[] parameters)
        where TViewModel : BaseViewModel
    {
        return ActivatorUtilities.CreateInstance<TViewModel>(serviceProvider, parameters);
    }
}
