using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed record CreateMatchCommand(
        string HomeClub,
        string AwayClub,
        CompetitionType CompetitionType,
        Guid SeasonId)
        : ICommand<Guid>;
}
