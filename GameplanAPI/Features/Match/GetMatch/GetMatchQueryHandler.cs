using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.GetMatch
{
    public sealed class GetMatchQueryHandler(IMatchRepository matchRepository)
        : IQueryHandler<GetMatchQuery, Match>
    {
        public async Task<Result<Match>> Handle(
            GetMatchQuery request, 
            CancellationToken cancellationToken)
        {
            var match = await matchRepository.Get(request.Id, cancellationToken);

            if (match == null)
            {
                return Result<Match>.Failure(Errors<Match>.NotFound(request.Id));
            }

            return Result<Match>.Success(match);
        }
    }
}
