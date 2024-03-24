using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace Inspirer.UI.Infrastructure.Helpers;

/// <summary>
/// Helper for MVVM components.
/// </summary>
internal static class MvvmComponentHelper
{
    private static readonly Type ComponentDefinition = typeof(MvvmComponent<>);
    private static readonly Type ComponentWithParametersDefinition = typeof(MvvmComponent<,>);

    private static readonly Type[] Definitions = [ComponentDefinition, ComponentWithParametersDefinition];

    /// <summary>
    /// Gets assembly MVVM component types.
    /// </summary>
    /// <returns>Component types.</returns>
    public static IEnumerable<Type> GetComponentTypes(Assembly assembly)
        => assembly.GetTypes()
            .Where(type => !type.IsAbstract)
            .Where(type => type.BaseType is not null)
            .Where(type => type.BaseType.IsGenericType)
            .Where(DefinitionsContainsType);

    private static bool DefinitionsContainsType(Type type)
        => Definitions.Contains(type.BaseType!.GetGenericTypeDefinition());

    /// <summary>
    /// Gets component parameters properties.
    /// </summary>
    /// <param name="componentType">Component type.</param>
    /// <param name="attributeType">Attribute type.</param>
    /// <returns>Property infos.</returns>
    public static PropertyInfo[] GetComponentParameters(Type componentType, Type attributeType)
        => componentType
            .GetProperties()
            .Where(property => Attribute.IsDefined(property, attributeType))
            .ToArray();
}
