using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed record CreateMatchCommand(
        string HomeClub,
        string AwayClub,
        string CompetitionType,
        DateTime DateTime,
        Guid SeasonId)
        : ICommand<Guid>;
}
