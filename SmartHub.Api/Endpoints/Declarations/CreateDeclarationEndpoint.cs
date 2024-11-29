using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Declarations
{
    public class CreateDeclarationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync).WithName("Declarations: Create").Produces<Response<Declaration?>>();
        }

        private static async Task<IResult> HandleAsync(IDeclarationHandler handler, CreateDeclarationRequest request)
        {
            request.UserId = ApiConfiguration.UserId;

            var response = await handler.CreateAsync(request);

            return response.IsSucess ? TypedResults.Created($"v1/declarations/{response.Data?.Id}") : TypedResults.BadRequest(response);
        }
    }
}