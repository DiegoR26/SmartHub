using Microsoft.AspNetCore.Mvc;
using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Declarations
{
    public class GetDeclarationsByCompetenceEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/competence", HandleAsync).WithName("Declarations: Get All by Competence").Produces<Response<List<Declaration>?>>();
        }

        private static async Task<IResult> HandleAsync(IDeclarationHandler handler, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var request = new GetDeclarationsByCompetenceRequest
            {
                UserId = ApiConfiguration.UserId,
                StartDate = startDate,
                EndDate = endDate
            };

            var response = await handler.GetByCompetenceAsync(request);

            return response.IsSucess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}