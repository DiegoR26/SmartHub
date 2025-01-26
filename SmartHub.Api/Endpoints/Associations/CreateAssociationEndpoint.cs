using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Associations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Associations
{
    public class CreateAssociationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync).WithName("Associations: Create").Produces<Response<Association?>>();
        }

        private static async Task<IResult> HandleAsync(IAssociationHandler handler, CreateAssociationRequest request)
        {
            request.UserId = ApiConfiguration.UserId;

            var response = await handler.CreateAsync(request);

            return response.IsSuccess ? TypedResults.Created($"v1/associations/{response.Data?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
