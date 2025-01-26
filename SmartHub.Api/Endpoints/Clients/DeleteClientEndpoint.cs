using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Clients
{
    public class DeleteClientEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync).WithName("Clients: Delete").Produces<Response<Client?>>();
        }

        //O id dentro dos parametros precisa ter o mesmo nome do "id" determinado na rota, ent�o os dois minusculos
        private static async Task<IResult> HandleAsync(IClientHandler handler, int id)
        {
            var request = new DeleteClientRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var response = await handler.DeleteAsync(request);

            return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}