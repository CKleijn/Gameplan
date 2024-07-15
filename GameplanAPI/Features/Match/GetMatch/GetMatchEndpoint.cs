using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using GameplanAPI.Features.Match._Interfaces;
using MediatR;

namespace GameplanAPI.Features.Match.GetMatch
{
    public sealed class GetMatchEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("match/{id}", async (
                ISender sender,
                IMatchMapper mapper,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var query = new GetMatchQuery(id);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(mapper.MatchToGetMatchResponse(result.Value!))
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.Match);
        }
    }
}
