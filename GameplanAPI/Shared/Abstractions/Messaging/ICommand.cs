using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Shared.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
