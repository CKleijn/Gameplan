using GameplanAPI.Common.Implementations;
using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed record GetMatchesBySeasonQuery(
        Guid SeasonId,
        string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page,
        int PageSize) 
        : IQuery<PagedList<MatchResponse>>;
}
