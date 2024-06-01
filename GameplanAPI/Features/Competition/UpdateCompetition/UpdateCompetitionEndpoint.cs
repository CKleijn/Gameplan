using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public sealed class UpdateCompetitionEndpoint 
        : ICarterModule
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

                return result.IsSuccess 
                    ? Results.NoContent() 
                    : result.GetProblemDetails();
            }).WithTags(Tags.Competition);
        }
    }
}
