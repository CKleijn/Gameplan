using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Database.Contexts;

namespace GameplanAPI.Features.Season
{
    public sealed class SeasonRepository(ApplicationDbContext context) 
        : Repository<Season>(context), ISeasonRepository
    {
    }
}
