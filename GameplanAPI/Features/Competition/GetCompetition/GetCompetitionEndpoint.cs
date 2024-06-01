using Carter;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Features.Competition.GetCompetition
{
    public class GetCompetitionEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("competition/{id}", async (
                ISender sender,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var query = new GetCompetitionQuery(id);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
            }).WithTags(Tags.Competition);
        }
    }
}
