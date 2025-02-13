using Microsoft.AspNetCore.Identity;
using SmartHub.Api;
using SmartHub.Api.Common.Api;
using SmartHub.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//Tem que ser nessa ordem
builder.AddConfiguration();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorization();

builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ConfigureDevEnviroment();
}

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
