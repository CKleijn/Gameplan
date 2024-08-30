using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match._Interfaces
{
    public interface IMatchRepository 
        : IRepository<Match>
    {
        Task<Match?> GetMatch(Guid id, CancellationToken cancellationToken);
    }
}
