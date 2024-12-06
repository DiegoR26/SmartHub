using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Associations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Associations
{
    public class UpdateAssociationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync).WithName("Associations: Update").Produces<Response<Association?>>();
        }

        private static async Task<IResult> HandleAsync(IAssociationHandler handler, UpdateAssociationRequest request, int id)
        {
            request.UserId = ApiConfiguration.UserId;
            request.Id = id;

            var response = await handler.UpdateAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}
