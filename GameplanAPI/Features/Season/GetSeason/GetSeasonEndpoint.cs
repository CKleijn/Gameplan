using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using GameplanAPI.Features.Season._Interfaces;
using MediatR;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed class GetSeasonEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("season/{id}", async (
                ISender sender,
                ISeasonMapper mapper,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var query = new GetSeasonQuery(id);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess 
                    ? Results.Ok(mapper.SeasonToGetSeasonResponse(result.Value!)) 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .RequireAuthorization()
            .WithTags(Tags.Season);
        }
    }
}
