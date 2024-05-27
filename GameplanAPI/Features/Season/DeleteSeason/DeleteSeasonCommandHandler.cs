using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed class DeleteSeasonCommandHandler(ISeasonRepository seasonRepository, IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteSeasonCommand>
    {
        public async Task<Result> Handle(
            DeleteSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var season = await seasonRepository.Get(request.Id, cancellationToken);

            if (season == null)
            {
                return Result.Failure(SeasonErrors.NotFound(request.Id));
            }

            seasonRepository.Delete(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
