using FluentValidation;
using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Competition._Interfaces;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public sealed class UpdateCompetitionCommandHandler(
        ICompetitionRepository competitionRepository,
        IUnitOfWork unitOfWork,
        IValidator<UpdateCompetitionCommand> validator)
        : ICommandHandler<UpdateCompetitionCommand>
    {
        public async Task<Result> Handle(
            UpdateCompetitionCommand request, 
            CancellationToken cancellationToken)
        {
            var competition = await competitionRepository.Get(request.Id, cancellationToken);

            if (competition == null)
            {
                return Result.Failure(Errors<Competition>.NotFound(request.Id));
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            competition.Name = request.Name;
            competition.Type = request.Type;
            competition.Country = request.Country;
            competition.UpdatedAt = DateTime.Now;

            competitionRepository.Update(competition);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
