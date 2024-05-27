using FluentValidation;
using GameplanAPI.Features.Competition._Helpers;
using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Interfaces;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public class UpdateCompetitionCommandHandler(
        ICompetitionRepository competitionRepository,
        IUnitOfWork unitOfWork,
        IValidator<UpdateCompetitionCommand> validator)
        : ICommandHandler<UpdateCompetitionCommand>
    {
        public async Task<Result> Handle(UpdateCompetitionCommand request, CancellationToken cancellationToken)
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

            competition.Update(request);

            competitionRepository.Update(competition);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
