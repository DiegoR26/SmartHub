using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Declarations
{
    public class DeleteDeclarationEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync).WithName("Declarations: Delete").Produces<Response<Declaration?>>();
        }

        //O id dentro dos parametros precisa ter o mesmo nome do "id" determinado na rota, então os dois minusculos
        private static async Task<IResult> HandleAsync(IDeclarationHandler handler, int id)
        {
            var request = new DeleteDeclarationRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var response = await handler.DeleteAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}