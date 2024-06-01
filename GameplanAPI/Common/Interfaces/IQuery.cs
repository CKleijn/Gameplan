using GameplanAPI.Common.Models;
using MediatR;

namespace GameplanAPI.Common.Interfaces
{
    public interface IQuery<TResponse>
        : IRequest<Result<TResponse>>
    {
    }
}
