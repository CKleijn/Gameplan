using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;

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
