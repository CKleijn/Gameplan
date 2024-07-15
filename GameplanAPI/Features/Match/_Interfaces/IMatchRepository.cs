using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match._Interfaces
{
    public interface IMatchRepository 
        : IRepository<Match>
    {
        Task<IEnumerable<Match>> GetAllBySeason(
            Guid seasonId,
            CancellationToken cancellationToken);
    }
}
