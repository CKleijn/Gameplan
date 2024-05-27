using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.GetAllCompetitions
{
    public sealed record GetAllCompetitionsQuery() : IQuery<IEnumerable<Competition>>;
}
