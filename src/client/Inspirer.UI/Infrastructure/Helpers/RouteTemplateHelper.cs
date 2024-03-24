using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing.Template;

namespace Inspirer.UI.Infrastructure.Helpers;

/// <summary>
/// Route templates helper.
/// </summary>
internal static class RouteTemplateHelper
{
    /// <summary>
    /// Get route template for component type.
    /// </summary>
    /// <typeparam name="TComponent">Component type.</typeparam>
    /// <returns>Route template.</returns>
    public static RouteTemplate GetRouteTemplate<TComponent>()
        where TComponent : ComponentBase
    {
        return GetRouteTemplate(componentType: typeof(TComponent));
    }

    /// <summary>
    /// Get route template for component type.
    /// </summary>
    /// <param name="componentType">Component type.</param>
    /// <returns>Route template.</returns>
    public static RouteTemplate GetRouteTemplate(Type componentType)
    {
        var routeAttribute = componentType.GetCustomAttribute<RouteAttribute>();
        if (routeAttribute is null)
        {
            return null;
        }

        return TemplateParser.Parse(routeAttribute.Template);
    }
}
