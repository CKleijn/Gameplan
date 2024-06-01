using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
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
                CancellationToken cancellationToken) =>
            {
                var query = new GetAllSeasonsQuery();

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess 
                    ? Results.Ok(result.Value) 
                    : result.GetProblemDetails();
            }).WithTags(Tags.Season);
        }
    }
}
