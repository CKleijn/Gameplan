using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Competition.GetAllCompetitions
{
    public sealed record GetAllCompetitionsQuery() 
        : IQuery<IEnumerable<Competition>>;
}
