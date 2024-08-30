using GameplanAPI.Common.Implementations;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;
using System.Linq.Expressions;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed class GetMatchesBySeasonQueryHandler(
        IMatchRepository matchRepository,
        IMatchMapper mapper)
        : IQueryHandler<GetMatchesBySeasonQuery, PagedList<MatchResponse>>
    {
        public async Task<Result<PagedList<MatchResponse>>> Handle(
            GetMatchesBySeasonQuery request,
            CancellationToken cancellationToken)
        {
            var matchesQuery = matchRepository.GetAsQueryable();
            matchesQuery = matchesQuery.Where(m => m.SeasonId == request.SeasonId);

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                matchesQuery = matchesQuery.Where(s =>
                    s.HomeClub.Contains(request.SearchTerm) ||
                    s.AwayClub.Contains(request.SearchTerm));
            }

            if (request.SortOrder?.ToLower() == "desc")
            {
                matchesQuery = matchesQuery.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                matchesQuery = matchesQuery.OrderBy(GetSortProperty(request));
            }

            var matchesResponsesQuery = matchesQuery
                .Select(m => mapper.MatchToMatchResponse(m));

            var matches = await PagedList<MatchResponse>.CreateAsync(matchesResponsesQuery, request.Page, request.PageSize, cancellationToken);

            return Result<PagedList<MatchResponse>>.Success(matches);
        }
        private static Expression<Func<Match, object>> GetSortProperty(GetMatchesBySeasonQuery request)
        {
            return request.SortColumn?.ToLower() switch
            {
                "competitionType" => match => match.CompetitionType,
                "matchStatus" => match => match.MatchStatus,
                "dateTime" => match => match.DateTime,
                _ => match => match.CreatedAt
            };
        }
    }
}
