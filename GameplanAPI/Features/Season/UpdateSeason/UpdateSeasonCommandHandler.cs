using FluentValidation;
using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Common.Services._Interfaces;
using GameplanAPI.Features.Season._Interfaces;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public sealed class UpdateSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        IAuthService authService,
        IUnitOfWork unitOfWork,
        IValidator<UpdateSeasonCommand> validator)
        : ICommandHandler<UpdateSeasonCommand>
    {
        public async Task<Result> Handle(
            UpdateSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

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

            season.Club = request.Club;
            season.CalendarYear = request.CalendarYear;
            season.UpdatedAt = DateTime.Now;

            seasonRepository.Update(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
