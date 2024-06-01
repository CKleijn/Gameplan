using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;

namespace GameplanAPI.Features.Season
{
    public sealed class SeasonRepository(
        ApplicationDbContext context, 
        ILogger<SeasonRepository> logger) 
        : Repository<Season>(context, logger), 
        ISeasonRepository
    {
    }
}
