using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed record UpdateMatchCommand(
        Guid Id,
        string HomeClub,
        string AwayClub,
        CompetitionType CompetitionType)
        : ICommand;
}
