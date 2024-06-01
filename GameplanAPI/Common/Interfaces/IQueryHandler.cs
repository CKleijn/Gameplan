using GameplanAPI.Common.Models;
using MediatR;

namespace GameplanAPI.Common.Interfaces
{
    public interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
