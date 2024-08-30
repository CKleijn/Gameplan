using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed class DeleteSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteSeasonCommand>
    {
        public async Task<Result> Handle(
            DeleteSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var season = await seasonRepository.GetSeason(request.Id, cancellationToken);

            if (season == null)
            {
                return Result.Failure(Errors<Season>.NotFound(request.Id));
            }

            seasonRepository.Delete(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
