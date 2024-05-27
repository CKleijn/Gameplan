using FluentValidation;
using GameplanAPI.Features.Season._Helpers;
using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Interfaces;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public class CreateSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateSeasonCommand> validator,
        ISeasonMapper mapper) 
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

            var season = mapper.CreateSeasonCommandToSeason(request);

            seasonRepository.Add(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
