using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Features.Season.GetSeason;
using MediatR;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public sealed class UpdateSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        ISender sender,
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

            var seasonQuery = new GetSeasonQuery(request.Id);

            var seasonQueryResult = await sender.Send(seasonQuery, cancellationToken);

            if (seasonQueryResult.IsFailure)
            {
                return Result.Failure(seasonQueryResult.Error);
            }

            var season = seasonQueryResult.Value!;

            season.Club = request.Club;
            season.CalendarYear = request.CalendarYear;
            season.UpdatedAt = DateTime.Now;

            seasonRepository.Update(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
