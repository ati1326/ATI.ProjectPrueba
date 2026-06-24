using ATI.ProjectPrueba.Frontend;
using ATI.ProjectPrueba.Frontend.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7181/weather") });
builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();
