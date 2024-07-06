using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Match.UpdateMatchResult
{
    public sealed class UpdateMatchResultEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("match/{id}/result", async (
                ISender sender,
                Guid id,
                UpdateMatchResultCommand command,
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
            })
            .MapToApiVersion(1)
            .WithTags(Tags.Match);
        }
    }
}
