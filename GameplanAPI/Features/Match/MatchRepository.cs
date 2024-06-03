using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;

namespace GameplanAPI.Features.Match
{
    public sealed class MatchRepository(
        ApplicationDbContext context,
        ILogger<MatchRepository> logger)
        : Repository<Match>(context, logger),
        IMatchRepository
    {
    }
}
