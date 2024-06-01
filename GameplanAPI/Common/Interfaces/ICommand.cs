using GameplanAPI.Common.Models;
using MediatR;

namespace GameplanAPI.Common.Interfaces
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
