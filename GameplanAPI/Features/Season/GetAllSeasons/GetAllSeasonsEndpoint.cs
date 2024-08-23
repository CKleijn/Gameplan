using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using GameplanAPI.Features.Season._Interfaces;
using MediatR;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed class GetAllSeasonsEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("seasons", async (
                ISender sender,
                ISeasonMapper mapper,
                CancellationToken cancellationToken) =>
            {
                var query = new GetAllSeasonsQuery();

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess 
                    ? Results.Ok(result.Value!.Select(season => mapper.SeasonToGetSeasonResponse(season)).ToList()) 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .RequireAuthorization()
            .WithTags(Tags.Season);
        }
    }
}
