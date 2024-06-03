using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed record GetAllMatchesQuery() 
        : IQuery<IEnumerable<Match>>;
}
