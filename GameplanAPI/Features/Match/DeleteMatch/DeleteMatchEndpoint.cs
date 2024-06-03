using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Match.DeleteMatch
{
    public sealed class DeleteMatchEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("match/{id}", async (
                ISender sender,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteMatchCommand(id);

                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess 
                    ? Results.NoContent() 
                    : result.GetProblemDetails();
            }).WithTags(Tags.Match);
        }
    }
}
