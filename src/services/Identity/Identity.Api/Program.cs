using Identity.Api.Infrastructure.DI;

namespace Identity.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        app.Run();
    }
}
