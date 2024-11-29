using Microsoft.EntityFrameworkCore;
using SmartHub.Api.Data.Mappings;
using SmartHub.Api.Handlers;
using SmartHub.Core;
using SmartHub.Core.Handlers;

namespace SmartHub.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=C:\\DiegoDB\\SmartHub.db"));
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
                options.AddPolicy(ApiConfiguration.CorsPolicyName, policy =>
                    policy.WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                        ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IClientHandler, ClientHandler>();
            builder.Services.AddTransient<IDeclarationHandler, DeclarationHandler>();
            builder.Services.AddTransient<ISlipHandler, SlipHandler>();
        }
    }
}