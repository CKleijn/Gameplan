using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Season.GetSeason;
using MediatR;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed class GetMatchesBySeasonQueryHandler(
        IMatchRepository matchRepository,
        ISender sender)
        : IQueryHandler<GetMatchesBySeasonQuery, IEnumerable<Match>>
    {
        public async Task<Result<IEnumerable<Match>>> Handle(
            GetMatchesBySeasonQuery request, 
            CancellationToken cancellationToken)
        {
            var seasonQuery = new GetSeasonQuery(request.SeasonId);

            var seasonQueryResult = await sender.Send(seasonQuery, cancellationToken);

            if (seasonQueryResult.IsFailure)
            {
                return Result<IEnumerable<Match>>.Failure(seasonQueryResult.Error);
            }

            var matches = await matchRepository.GetAllBySeason(request.SeasonId, cancellationToken);

            return Result<IEnumerable<Match>>.Success(matches);
        }
    }
}
