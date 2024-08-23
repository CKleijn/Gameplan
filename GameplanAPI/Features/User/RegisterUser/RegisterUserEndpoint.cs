using Carter;
using GameplanAPI.Common.Annotations;
using GameplanAPI.Common.Extensions;
using MediatR;

namespace GameplanAPI.Features.User.RegisterUser
{
    public sealed class RegisterUserEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("user/register", async (
                ISender sender,
                RegisterUserCommand command,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.NoContent()
                    : result.GetProblemDetails();
            })
            .MapToApiVersion(1)
            .WithTags(Tags.User);
        }
    }
}
