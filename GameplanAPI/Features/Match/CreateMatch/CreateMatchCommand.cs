using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed record CreateMatchCommand(
        Guid HomeClubId,
        Guid AwayClubId,
        Guid CompetitionId)
        : ICommand;
}
