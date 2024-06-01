﻿using Carter;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed class GetSeasonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("season/{id}", async (
                ISender sender,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var query = new GetSeasonQuery(id);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
            }).WithTags(Tags.Season);
        }
    }
}
