using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Common.Services._Interfaces;
using GameplanAPI.Features.Season._Interfaces;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed class DeleteSeasonCommandHandler(
        ISeasonRepository seasonRepository,
        IAuthService authService,
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

            var currentUserId = authService.GetCurrentUserId();

            if (currentUserId == null || season.UserId != currentUserId)
            {
                return Result.Failure(Errors<Season>.NotAuthorized);
            }

            seasonRepository.Delete(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
