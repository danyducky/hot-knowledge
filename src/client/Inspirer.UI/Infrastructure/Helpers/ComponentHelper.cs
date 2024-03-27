using System.Reflection;
using Inspirer.Mvvm.ViewModels;
using Inspirer.UI.Infrastructure.Navigation;
using Microsoft.AspNetCore.Components;

namespace Inspirer.UI.Infrastructure.Helpers;

/// <summary>
/// Components helper.
/// </summary>
internal static class ComponentHelper
{
    /// <summary>
    /// Returns components information.
    /// </summary>
    /// <returns>Component information per view model type.</returns>
    public static Dictionary<Type, ComponentInfo> GetComponentsInfo()
    {
        var types = MvvmComponentHelper.GetComponentTypes(
            assembly: typeof(MvvmComponent<>).Assembly);

        var infos = new Dictionary<Type, ComponentInfo>();
        foreach (var type in types)
        {
            ArgumentNullException.ThrowIfNull(type.BaseType, nameof(type.BaseType));

            var viewModelType = type.BaseType.GenericTypeArguments
                .First(generic => generic.BaseType == typeof(BaseViewModel));

            var routeProperties = MvvmComponentHelper.GetComponentParameters(
                componentType: type,
                attributeType: typeof(ParameterAttribute));

            var queryProperties = MvvmComponentHelper.GetComponentParameters(
                componentType: type,
                attributeType: typeof(SupplyParameterFromQueryAttribute));

            infos.Add(viewModelType, new ComponentInfo
            {
                ComponentType = type,
                ViewModelType = viewModelType,
                Route = RouteTemplateHelper.GetRouteTemplate(type),
                RouteProperties = routeProperties,
                QueryProperties = queryProperties,
            });
        }
        return infos;
    }

    /// <summary>
    /// Gets component parameters values.
    /// </summary>
    /// <param name="properties">Component properties.</param>
    /// <param name="parameters">Component parameters.</param>
    /// <typeparam name="TParameters">Parameters type.</typeparam>
    /// <returns>Extracted component parameters.</returns>
    public static Dictionary<string, object> GetValues<TParameters>(
        IEnumerable<PropertyInfo> properties, TParameters parameters)
    {
        var values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        foreach (var property in properties)
        {
            var value = property.GetValue(parameters);
            if (value == null)
            {
                continue;
            }

            values.Add(property.Name, value);
        }
        return values;
    }
}
