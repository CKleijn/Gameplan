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
        public async Task<Match?> GetMatch(
            Guid id,
            CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Repository<{typeof(Match).Name}>] Retrieving specific record by id of type {typeof(Match).Name}");
            return await context
                .Set<Match>()
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }
    }
}
