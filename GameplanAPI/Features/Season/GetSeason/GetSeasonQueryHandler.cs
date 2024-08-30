using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed class GetSeasonQueryHandler(
        ISeasonRepository seasonRepository,
        ISeasonMapper mapper)
        : IQueryHandler<GetSeasonQuery, SeasonResponse>
    {
        public async Task<Result<SeasonResponse>> Handle(
            GetSeasonQuery request,
            CancellationToken cancellationToken)
        {
            var season = await seasonRepository.GetSeason(request.Id, cancellationToken);

            if (season == null)
            {
                return Result<SeasonResponse>.Failure(Errors<Season>.NotFound(request.Id));
            }

            return Result<SeasonResponse>.Success(mapper.SeasonToSeasonResponse(season));
        }
    }
}
