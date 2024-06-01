using Carter;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Features.Competition.DeleteCompetition
{
    public class DeleteCompetitionEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("competition/{id}", async (
                ISender sender,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteCompetitionCommand(id);

                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
            }).WithTags(Tags.Competition);
        }
    }
}
