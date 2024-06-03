using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.Competition.GetCompetition
{
    public sealed class GetCompetitionEndpoint 
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("competition/{id}", async (
                ISender sender,
                Guid id,
                CancellationToken cancellationToken) =>
            {
                var query = new GetCompetitionQuery(id);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess 
                    ? Results.Ok(result.Value) 
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.Competition);
        }
    }
}
