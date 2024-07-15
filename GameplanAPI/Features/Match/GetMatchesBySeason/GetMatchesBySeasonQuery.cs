using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed record GetMatchesBySeasonQuery(Guid SeasonId) 
        : IQuery<IEnumerable<Match>>;
}
