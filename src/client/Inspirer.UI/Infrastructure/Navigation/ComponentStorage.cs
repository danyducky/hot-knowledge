using Inspirer.Mvvm.ViewModels;
using Inspirer.UI.Infrastructure.Helpers;

namespace Inspirer.UI.Infrastructure.Navigation;

/// <summary>
/// Components storage.
/// </summary>
public static class ComponentStorage
{
    private static readonly Dictionary<Type, ComponentInfo> ComponentsInfo;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static ComponentStorage()
    {
        ComponentsInfo = ComponentHelper.GetComponentsInfo();
    }

    /// <summary>
    /// Gets view model component configuration.
    /// </summary>
    /// <typeparam name="TViewModel">View model type.</typeparam>
    /// <returns></returns>
    public static ComponentInfo GetComponentInfo<TViewModel>()
        where TViewModel : BaseViewModel
        => ComponentsInfo[typeof(TViewModel)];
}
