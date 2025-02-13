﻿using SmartHub.Api.Common.Api;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Associations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Endpoints.Associations
{
    public class GetAllAssociationsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandleAsync).WithName("Associations: Get All").Produces<Response<List<Association>?>>();
        }

        private static async Task<IResult> HandleAsync(IAssociationHandler handler)
        {
            var request = new GetAllAssociationsRequest
            {
                UserId = ApiConfiguration.UserId,
            };

            var response = await handler.GetAllAsync(request);

            return response.IsSuccess ? TypedResults.Ok(response) : TypedResults.BadRequest(response);
        }
    }
}
