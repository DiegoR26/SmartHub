using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Slips
{
    public class DeleteSlipEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandleAsync).WithName("Slips: Delete").Produces<Response<Slip?>>();
        }

        //O id dentro dos parametros precisa ter o mesmo nome do "id" determinado na rota, então os dois minusculos
        private static async Task<IResult> HandleAsync(ISlipHandler handler, int id)
        {
            var request = new DeleteSlipRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var response = await handler.DeleteAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}