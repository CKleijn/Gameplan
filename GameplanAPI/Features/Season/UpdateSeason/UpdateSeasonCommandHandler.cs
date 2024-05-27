using FluentValidation;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public class UpdateSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        IUnitOfWork unitOfWork,
        IValidator<UpdateSeasonCommand> validator)
        : ICommandHandler<UpdateSeasonCommand>
    {
        public async Task<Result> Handle(
            UpdateSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var season = await seasonRepository.Get(request.Id, cancellationToken);

            if (season == null)
            {
                return Result.Failure(SeasonErrors.NotFound(request.Id));
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            season.Update(request);

            seasonRepository.Update(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
