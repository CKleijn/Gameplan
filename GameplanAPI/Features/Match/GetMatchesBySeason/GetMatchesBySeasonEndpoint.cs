using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using GameplanAPI.Features.Match._Interfaces;
using MediatR;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed class GetMatchesBySeasonEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("matches/season/{seasonId}", async (
                ISender sender,
                IMatchMapper mapper,
                Guid seasonId,
                CancellationToken cancellationToken) =>
            {
                var query = new GetMatchesBySeasonQuery(seasonId);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value!.Select(match => mapper.MatchToGetMatchResponse(match)).ToList())
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .RequireAuthorization()
            .WithTags(Tags.Match);
        }
    }
}
