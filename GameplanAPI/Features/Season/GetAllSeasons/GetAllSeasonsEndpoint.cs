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
                string? searchTerm,
                string? sortColumn,
                string? sortOrder,
                int page,
                int pageSize,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetAllSeasonsQuery(searchTerm, sortColumn, sortOrder, page, pageSize);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess 
                    ? Results.Ok(result.Value) 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .RequireAuthorization()
            .WithTags(Tags.Season);
        }
    }
}
