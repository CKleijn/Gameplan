using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;

namespace GameplanAPI.Features.Competition
{
    public sealed class CompetitionRepository(
        ApplicationDbContext context, 
        ILogger<CompetitionRepository> logger)
        : Repository<Competition>(context, logger), 
        ICompetitionRepository
    {
    }
}
