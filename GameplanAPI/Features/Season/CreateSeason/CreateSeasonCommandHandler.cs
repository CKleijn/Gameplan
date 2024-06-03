using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public sealed class CreateSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateSeasonCommand> validator,
        ISeasonMapper mapper) 
        : ICommandHandler<CreateSeasonCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(
            CreateSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<Guid>.Failure(validationResult.Errors);
            }

            var season = mapper.CreateSeasonCommandToSeason(request);

            seasonRepository.Add(season);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(season.Id);
        }
    }
}
