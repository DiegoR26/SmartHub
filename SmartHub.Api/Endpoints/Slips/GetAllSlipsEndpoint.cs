using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Slips
{
    public class GetAllSlipsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync).WithName("Slips: Get All").Produces<Response<List<Slip>?>>();
        }

        private static async Task<IResult> HandleAsync(ISlipHandler handler)
        {
            var request = new GetAllSlipsRequest
            {
                UserId = ApiConfiguration.UserId,
            };

            var response = await handler.GetAllAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}