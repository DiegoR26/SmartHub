using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Slips
{
    public class GetSlipByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandleAsync).WithName("Slips: Get by Id").Produces<Response<Slip?>>();
        }

        private static async Task<IResult> HandleAsync(ISlipHandler handler, int id)
        {
            var request = new GetSlipByIdRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };

            var response = await handler.GetByIdAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}