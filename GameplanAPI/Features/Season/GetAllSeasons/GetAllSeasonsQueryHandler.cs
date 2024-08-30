using GameplanAPI.Common.Implementations;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed class GetAllSeasonsQueryHandler(
        ISeasonRepository seasonRepository,
        ISeasonMapper mapper) 
        : IQueryHandler<GetAllSeasonsQuery, PagedList<SeasonResponse>>
    {
        public async Task<Result<PagedList<SeasonResponse>>> Handle(
            GetAllSeasonsQuery request, 
            CancellationToken cancellationToken)
        {
            var seasonsQuery = seasonRepository.GetAsQueryable();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                seasonsQuery = seasonsQuery.Where(s => s.Club.Contains(request.SearchTerm));
            }

            if (request.SortOrder?.ToLower() == "desc")
            {
                seasonsQuery = seasonsQuery.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                seasonsQuery = seasonsQuery.OrderBy(GetSortProperty(request));
            }

            var seasonResponsesQuery = seasonsQuery
                .Include(s => s.Matches)
                .Select(s => mapper.SeasonToSeasonResponse(s));

            var seasons = await PagedList<SeasonResponse>.CreateAsync(seasonResponsesQuery, request.Page, request.PageSize, cancellationToken);

            return Result<PagedList<SeasonResponse>>.Success(seasons);
        }

        private static Expression<Func<Season, object>> GetSortProperty(GetAllSeasonsQuery request)
        {
            return request.SortColumn?.ToLower() switch
            {
                "club" => season => season.Club,
                "calendarYear" => season => season.CalendarYear,
                _ => season => season.CreatedAt
            };
        }
    }
}
