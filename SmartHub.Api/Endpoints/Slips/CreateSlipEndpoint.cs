using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Slips
{
    public class CreateSlipEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/", HandleAsync).WithName("Slips: Create").Produces<Response<Slip?>>();
        }

        private static async Task<IResult> HandleAsync(ISlipHandler handler, CreateSlipRequest request)
        {
            request.UserId = ApiConfiguration.UserId;

            var response = await handler.CreateAsync(request);

            return response.IsSuccess ? TypedResults.Created($"v1/slips/{response.Data?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}