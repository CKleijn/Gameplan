using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Database.Contexts;

namespace GameplanAPI.Features.Season
{
    public sealed class SeasonRepository(ApplicationDbContext context, ILogger<SeasonRepository> logger) 
        : Repository<Season>(context, logger), ISeasonRepository
    {
    }
}
