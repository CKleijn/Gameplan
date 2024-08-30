using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.GetMatch
{
    public sealed class GetMatchQueryHandler(
        IMatchRepository matchRepository,
        IMatchMapper matchMapper)
        : IQueryHandler<GetMatchQuery, MatchResponse>
    {
        public async Task<Result<MatchResponse>> Handle(
            GetMatchQuery request, 
            CancellationToken cancellationToken)
        {
            var match = await matchRepository.GetMatch(request.Id, cancellationToken);

            if (match == null)
            {
                return Result<MatchResponse>.Failure(Errors<Match>.NotFound(request.Id));
            }

            return Result<MatchResponse>.Success(matchMapper.MatchToMatchResponse(match));
        }
    }
}
