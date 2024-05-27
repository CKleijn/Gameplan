using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed class GetAllSeasonsQueryHandler(ISeasonRepository seasonRepository) 
        : IQueryHandler<GetAllSeasonsQuery, IEnumerable<Season>>
    {
        public async Task<Result<IEnumerable<Season>>> Handle(
            GetAllSeasonsQuery request, 
            CancellationToken cancellationToken)
        {
            var seasons = await seasonRepository.GetAll(cancellationToken);

            return Result<IEnumerable<Season>>.Success(seasons);
        }
    }
}
