using Identity.Api.Configuration;

namespace Identity.Api;

/// <summary>
/// Program entry point.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point.
    /// </summary>
    /// <param name="args">Program arguments.</param>
    public static void Main(string[] args)
    {
        WebApplication.CreateBuilder(args)
            .BuildApplication()
            .ConfigureApplication()
            .Run();
    }
}
