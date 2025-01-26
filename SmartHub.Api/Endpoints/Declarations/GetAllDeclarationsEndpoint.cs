using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Declarations
{
    public class GetAllDeclarationsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync).WithName("Declarations: Get All").Produces<Response<List<Declaration>?>>();
        }

        private static async Task<IResult> HandleAsync(IDeclarationHandler handler)
        {
            var request = new GetAllDeclarationsRequest
            {
                UserId = ApiConfiguration.UserId,
            };

            var response = await handler.GetAllAsync(request);

            return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}