using SmartHub.Api.Common.Api;
using SmartHub.Api.Endpoints.Clients;
using SmartHub.Api.Endpoints.Declarations;
using SmartHub.Api.Endpoints.Slips;
using SmartHub.Api.Endpoints.Associations;

namespace SmartHub.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/").WithTags("Health Check").MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/clients").WithTags("Clients")
                                            .MapEndpoint<CreateClientEndpoint>()
                                            .MapEndpoint<DeleteClientEndpoint>()
                                            .MapEndpoint<GetAllClientsEndpoint>()
                                            .MapEndpoint<GetClientByIdEndpoint>()
                                            .MapEndpoint<UpdateClientEndpoint>();

            endpoints.MapGroup("v1/declarations").WithTags("Declarations")
                                            .MapEndpoint<CreateDeclarationEndpoint>()
                                            .MapEndpoint<DeleteDeclarationEndpoint>()
                                            .MapEndpoint<GetAllDeclarationsEndpoint>()
                                            .MapEndpoint<GetDeclarationByIdEndpoint>()
                                            .MapEndpoint<GetDeclarationsByCompetenceEndpoint>()
                                            .MapEndpoint<UpdateDeclarationEndpoint>();

            endpoints.MapGroup("v1/slips").WithTags("Slips")
                                            .MapEndpoint<CreateSlipEndpoint>()
                                            .MapEndpoint<DeleteSlipEndpoint>()
                                            .MapEndpoint<GetAllSlipsEndpoint>()
                                            .MapEndpoint<GetSlipByIdEndpoint>()
                                            .MapEndpoint<GetSlipsByCompetenceEndpoint>()
                                            .MapEndpoint<UpdateSlipEndpoint>();

            endpoints.MapGroup("v1/associations").WithTags("Associations")
                                                    .MapEndpoint<CreateAssociationEndpoint>()
                                                    .MapEndpoint<DeleteAssociationEndpoint>()
                                                    .MapEndpoint<GetAllAssociationsEndpoint>()
                                                    .MapEndpoint<GetAssociationByIdEndpoint>()
                                                    .MapEndpoint<GetAssociationsByClientEndpoint>()
                                                    .MapEndpoint<UpdateAssociationEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}