using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Clients
{
    public class GetAllClientsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync).WithName("Clients: Get All").Produces<Response<List<Client>?>>();
        }

        private static async Task<IResult> HandleAsync(IClientHandler handler)
        {
            var request = new GetAllClientsRequest
            {
                UserId = ApiConfiguration.UserId,
            };

            var response = await handler.GetAllAsync(request);

            return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}