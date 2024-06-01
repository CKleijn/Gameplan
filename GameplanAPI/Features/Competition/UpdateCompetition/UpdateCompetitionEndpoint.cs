using Carter;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public class UpdateCompetitionEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("competition/{id}", async (
                ISender sender,
                Guid id,
                UpdateCompetitionCommand command,
                CancellationToken cancellationToken) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest();
                }

                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
            }).WithTags(Tags.Competition);
        }
    }
}
