using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.User.GetUserByUID
{
    public sealed class GetUserByUIDEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("user/{uid}", async (
                ISender sender,
                string uid,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUserByUIDQuery(uid);

                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.User);
        }
    }
}
