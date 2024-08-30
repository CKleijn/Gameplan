using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Features.Season
{
    public sealed class SeasonRepository(
        ApplicationDbContext context,
        ILogger<SeasonRepository> logger)
        : Repository<Season>(context, logger),
        ISeasonRepository
    {
        public async Task<Season?> GetSeason(
            Guid id, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Repository<{typeof(Season).Name}>] Retrieving specific record by id of type {typeof(Season).Name}");
            return await context
                .Set<Season>()
                .Include(s => s.Matches)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
    }
}
