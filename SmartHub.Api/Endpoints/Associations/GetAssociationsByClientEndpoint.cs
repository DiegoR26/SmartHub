using Microsoft.AspNetCore.Mvc;
using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Associations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Associations
{
    public class GetAssociationsByClientEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/clientAssociation", HandleAsync).WithName("Associations: Get All by Client").Produces<Response<List<Association>>?>();
        }

        private static async Task<IResult> HandleAsync(IAssociationHandler handler)
        {
            var request = new GetAssociationsByClientRequest
            {
                UserId = ApiConfiguration.UserId
            };

            var response = await handler.GetByClientAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}
