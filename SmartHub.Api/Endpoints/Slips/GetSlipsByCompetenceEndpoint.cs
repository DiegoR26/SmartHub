using Microsoft.AspNetCore.Mvc;
using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Slips
{
    public class GetSlipsByCompetenceEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/competence", HandleAsync).WithName("Slips: Get All by Competence").Produces<Response<List<Slip>?>>();
        }

        private static async Task<IResult> HandleAsync(ISlipHandler handler, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var request = new GetSlipsByCompetenceRequest
            {
                UserId = ApiConfiguration.UserId,
                StartDate = startDate,
                EndDate = endDate
            };

            var response = await handler.GetByCompetenceAsync(request);

            return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}