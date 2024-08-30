using GameplanAPI.Common.Implementations;
using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed record GetAllSeasonsQuery(
        string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page,
        int PageSize) 
        : IQuery<PagedList<SeasonResponse>>;
}
