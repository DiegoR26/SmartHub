using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Clients
{
    public class CreateClientEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync).WithName("Clients: Create").Produces<Response<Client?>>();
        }

        private static async Task<IResult> HandleAsync(IClientHandler handler, CreateClientRequest request)
        {
            request.UserId = ApiConfiguration.UserId;

            var response = await handler.CreateAsync(request);

            return response.IsSucess ? TypedResults.Created($"v1/clients/{response.Data?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}