using FluentValidation;
using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public sealed class UpdateSeasonCommandHandler(
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
                return Result.Failure(Errors<Season>.NotFound(request.Id));
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            season.Club = request.Club;
            season.CalendarYear = request.CalendarYear;
            season.UpdatedAt = DateTime.Now;

            seasonRepository.Update(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
