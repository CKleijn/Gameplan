using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed class GetMatchesBySeasonEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("matches/season/{seasonId}", async (
                string? searchTerm,
                string? sortColumn,
                string? sortOrder,
                int page,
                int pageSize,
                ISender sender,
                Guid seasonId,
                CancellationToken cancellationToken) =>
            {
                var query = new GetMatchesBySeasonQuery(seasonId, searchTerm, sortColumn, sortOrder, page, pageSize);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .RequireAuthorization()
            .WithTags(Tags.Match);
        }
    }
}
