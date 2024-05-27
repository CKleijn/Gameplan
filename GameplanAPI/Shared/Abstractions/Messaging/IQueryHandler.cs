using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;

namespace GameplanAPI.Shared.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}
