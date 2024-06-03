using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public sealed class CreateSeasonEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("season", async (
                ISender sender,
                CreateSeasonCommand command,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess 
                    ? Results.NoContent() 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.Season);
        }
    }
}
