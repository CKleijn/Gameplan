using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public sealed class UpdateSeasonEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("season/{id}", async (
                ISender sender,
                Guid id,
                UpdateSeasonCommand command,
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
            }).WithTags(Tags.Season);
        }
    }
}
