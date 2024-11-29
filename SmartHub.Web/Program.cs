using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SmartHub.Core;
using SmartHub.Core.Handlers;
using SmartHub.Web;
using SmartHub.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient(WebConfiguration.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(Configuration.BackendUrl);
});

builder.Services.AddTransient<IClientHandler, ClientHandler>();
builder.Services.AddTransient<IDeclarationHandler, DeclarationHandler>();
builder.Services.AddTransient<ISlipHandler, SlipHandler>();

await builder.Build().RunAsync();
