using FluentValidation;
using GameplanAPI.Shared.Abstractions;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public class CreateSeasonCommandHandler(ISeasonRepository seasonRepository, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateSeasonCommand> validator) 
        : ICommandHandler<CreateSeasonCommand>
    {
        public async Task<Result> Handle(
            CreateSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            var season = new Season
            {
                Club = request.Club,
                CalendarYear = request.CalendarYear
            };

            seasonRepository.Add(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
