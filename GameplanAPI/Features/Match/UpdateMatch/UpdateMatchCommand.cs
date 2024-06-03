using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed record UpdateMatchCommand(
        Guid Id,
        Guid HomeClubId,
        Guid AwayClubId,
        Guid CompetitionId)
        : ICommand;
}
