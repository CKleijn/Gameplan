using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Shared.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
