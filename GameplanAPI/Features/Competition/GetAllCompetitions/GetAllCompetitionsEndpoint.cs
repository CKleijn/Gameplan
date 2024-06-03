using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Competition.GetAllCompetitions
{
    public sealed class GetAllCompetitionsEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("competitions", async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetAllCompetitionsQuery();

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess 
                    ? Results.Ok(result.Value) 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.Competition);
        }
    }
}
