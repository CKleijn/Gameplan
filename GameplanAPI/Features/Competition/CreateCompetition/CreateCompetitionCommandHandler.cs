using FluentValidation;
using GameplanAPI.Features.Competition._Helpers;
using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Interfaces;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public sealed class CreateCompetitionCommandHandler(
        ICompetitionRepository competitionRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateCompetitionCommand> validator,
        ICompetitionMapper mapper)
        : ICommandHandler<CreateCompetitionCommand>
    {
        public async Task<Result> Handle(
            CreateCompetitionCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            var competition = mapper.CreateCompetitionCommandToCompetition(request);

            competitionRepository.Add(competition);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
