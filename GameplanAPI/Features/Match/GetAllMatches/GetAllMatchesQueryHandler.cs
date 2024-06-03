using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.GetAllMatches
{
    public sealed class GetAllMatchesQueryHandler(IMatchRepository matchRepository)
        : IQueryHandler<GetAllMatchesQuery, IEnumerable<Match>>
    {
        public async Task<Result<IEnumerable<Match>>> Handle(
            GetAllMatchesQuery request, 
            CancellationToken cancellationToken)
        {
            var matches = await matchRepository.GetAll(cancellationToken);

            return Result<IEnumerable<Match>>.Success(matches);
        }
    }
}
