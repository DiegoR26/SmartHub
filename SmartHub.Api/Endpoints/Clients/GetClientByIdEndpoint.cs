using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Clients
{
    public class GetClientByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync).WithName("Clients: Get by Id").Produces<Response<Client?>>();
        }

        private static async Task<IResult> HandleAsync(IClientHandler handler, int id)
        {
            var request = new GetClientByIdRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var response = await handler.GetByIdAsync(request);

            return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}