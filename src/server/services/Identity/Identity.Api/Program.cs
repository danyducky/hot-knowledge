using Identity.Api.Infrastructure;

await WebApplication.CreateBuilder(args)
    .BuildApplication()
    .ConfigureApplication()
    .RunAsync();
