using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatchResult
{
    public sealed record UpdateMatchResultCommand(
        Guid Id,
        int HomeScore,
        int AwayScore)
        : ICommand;
}
