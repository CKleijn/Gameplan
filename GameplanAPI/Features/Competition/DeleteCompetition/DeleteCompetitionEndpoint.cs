using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Competition.DeleteCompetition
{
    public sealed class DeleteMatchEndpoint 
        : ICarterModule
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

                return result.IsSuccess 
                    ? Results.NoContent() 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.Competition);
        }
    }
}
