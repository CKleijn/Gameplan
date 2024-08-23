using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed class DeleteSeasonEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("season/{id}", async (
                ISender sender,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteSeasonCommand(id);

                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.NoContent()
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .RequireAuthorization()
            .WithTags(Tags.Season);
        }
    }
}
