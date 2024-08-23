using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed record UpdateMatchCommand(
        Guid Id,
        string HomeClub,
        string AwayClub,
        string CompetitionType,
        DateTime DateTime)
        : ICommand;
}
