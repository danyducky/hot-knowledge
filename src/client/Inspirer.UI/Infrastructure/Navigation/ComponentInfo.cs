using System.Reflection;
using Microsoft.AspNetCore.Routing.Template;

namespace Inspirer.UI.Infrastructure.Navigation;

/// <summary>
/// Contains component information.
/// </summary>
public struct ComponentInfo
{
    /// <summary>
    /// MVVM component type.
    /// </summary>
    public required Type ComponentType { get; init; }

    /// <summary>
    /// MVVM component view model type.
    /// </summary>
    public required Type ViewModelType { get; init; }

    /// <summary>
    /// Route template.
    /// </summary>
    public required RouteTemplate Route { get; init; }

    /// <summary>
    /// Component route properties.
    /// </summary>
    public IEnumerable<PropertyInfo> RouteProperties { get; init; }

    /// <summary>
    /// Component query properties.
    /// </summary>
    public IEnumerable<PropertyInfo> QueryProperties { get; init; }
}
