using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Database.Contexts;

namespace GameplanAPI.Features.Competition
{
    public sealed class CompetitionRepository(ApplicationDbContext context, ILogger<CompetitionRepository> logger)
        : Repository<Competition>(context, logger), ICompetitionRepository
    {
    }
}
