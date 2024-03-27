using Microsoft.AspNetCore.Routing.Template;
using Microsoft.AspNetCore.WebUtilities;

namespace Inspirer.UI.Infrastructure.Helpers;

/// <summary>
/// Application route helper.
/// </summary>
public static class RouteHelper
{
    private const string PathSeparator = "/";

    /// <summary>
    /// Gets route path.
    /// </summary>
    /// <param name="route">Route template.</param>
    /// <param name="values">Route values.</param>
    /// <returns>Route path.</returns>
    public static string GetRoutePath(RouteTemplate route, IDictionary<string, object> values)
    {
        var segments = RouteSegmentHelper.ParseRouteSegments(route, values);
        return string.Join(PathSeparator, segments);
    }

    /// <summary>
    /// Gets route path with given routes and queries.
    /// </summary>
    /// <param name="route">Route template.</param>
    /// <param name="routeValues">Route values.</param>
    /// <param name="queryValues">Query values.</param>
    /// <returns></returns>
    public static string GetRoutePath(
        RouteTemplate route,
        IDictionary<string, object> routeValues,
        IDictionary<string, object> queryValues)
    {
        var path = GetRoutePath(route, routeValues);
        var query = queryValues.ToDictionary(pair => pair.Key, pair => pair.Value.ToString());

        return QueryHelpers.AddQueryString(path, query);
    }
}
