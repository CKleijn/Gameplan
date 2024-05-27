using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed class GetSeasonQueryHandler(ISeasonRepository seasonRepository)
        : IQueryHandler<GetSeasonQuery, Season>
    {
        public async Task<Result<Season>> Handle(
            GetSeasonQuery request,
            CancellationToken cancellationToken)
        {
            var season = await seasonRepository.Get(request.Id, cancellationToken);

            if (season == null)
            {
                return Result<Season>.Failure(SeasonErrors.NotFound(request.Id));
            }

            return Result<Season>.Success(season);
        }
    }
}
