using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Season._Interfaces
{
    public interface ISeasonRepository 
        : IRepository<Season>
    {
        Task<Season?> GetSeason(Guid id, CancellationToken cancellationToken);
    }
}
