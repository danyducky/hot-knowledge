using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Inspirer.Blazor.Infrastructure;

await WebAssemblyHostBuilder.CreateDefault(args)
    .BuildApplication()
    .ConfigureApplication()
    .RunAsync();
