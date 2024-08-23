using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Features.Match
{
    public sealed class MatchRepository(
        ApplicationDbContext context,
        ILogger<MatchRepository> logger)
        : Repository<Match>(context, logger),
        IMatchRepository
    {
        public async Task<IEnumerable<Match>> GetAllBySeason(
            Guid seasonId, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Repository<{typeof(Match).Name}>] Retrieving all records of type {typeof(Match).Name} by season {seasonId}");
            return await context
                .Set<Match>()
                .Where(m => m.SeasonId == seasonId)
                .ToListAsync(cancellationToken);
        }
    }
}
