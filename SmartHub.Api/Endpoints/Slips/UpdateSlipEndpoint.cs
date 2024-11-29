using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Slips
{
    public class UpdateSlipEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync).WithName("Slips: Update").Produces<Response<Slip?>>();
        }

        private static async Task<IResult> HandleAsync(ISlipHandler handler, UpdateSlipRequest request, int id)
        {
            request.UserId = ApiConfiguration.UserId;
            request.Id = id;

            var response = await handler.UpdateAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}