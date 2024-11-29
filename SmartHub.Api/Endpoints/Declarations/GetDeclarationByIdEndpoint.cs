using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Declarations
{
    public class GetDeclarationByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync).WithName("Declarations: Get by Id").Produces<Response<Declaration?>>();
        }

        private static async Task<IResult> HandleAsync(IDeclarationHandler handler, int id)
        {
            var request = new GetDeclarationByIdRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var response = await handler.GetByIdAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}