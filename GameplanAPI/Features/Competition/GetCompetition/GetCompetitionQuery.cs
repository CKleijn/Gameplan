using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Competition.GetCompetition
{
    public sealed record GetCompetitionQuery(Guid Id) 
        : IQuery<Competition>;
}
