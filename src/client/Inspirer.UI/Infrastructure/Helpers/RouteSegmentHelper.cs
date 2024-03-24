using Microsoft.AspNetCore.Routing.Template;

namespace Inspirer.UI.Infrastructure.Helpers;

/// <summary>
/// Route segment helper.
/// </summary>
public static class RouteSegmentHelper
{
    /// <summary>
    /// Gets route template segments.
    /// </summary>
    /// <param name="route">Route template.</param>
    /// <param name="values">Route segment values.</param>
    /// <returns>Route segments.</returns>
    public static IEnumerable<string> ParseRouteSegments(RouteTemplate route, IDictionary<string, object> values)
    {
        foreach (var segment in route.Segments)
        {
            var part = segment.Parts.First();

            if (string.IsNullOrWhiteSpace(part.Name))
            {
                yield return part.Text;

                continue;
            }

            if (values.TryGetValue(part.Name, out var value))
            {
                yield return value.ToString();

                continue;
            }

            throw new InvalidOperationException($"Not found \"{part.Name}\" parameter.");
        }
    }
}
