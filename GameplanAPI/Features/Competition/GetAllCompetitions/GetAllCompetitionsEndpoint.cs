using Carter;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Features.Competition.GetAllCompetitions
{
    public class GetAllCompetitionsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("competitions", async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetAllCompetitionsQuery();

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
            }).WithTags(Tags.Competition);
        }
    }
}
