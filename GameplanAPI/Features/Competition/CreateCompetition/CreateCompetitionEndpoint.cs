using Carter;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public class CreateCompetitionEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("competition", async (
                ISender sender,
                CreateCompetitionCommand command,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
            }).WithTags(Tags.Competition);
        }
    }
}
