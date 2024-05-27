using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.GetCompetition
{
    public sealed record GetCompetitionQuery(Guid Id) : IQuery<Competition>;
}
