using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Competition._Interfaces;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public sealed class CreateCompetitionCommandHandler(
        ICompetitionRepository competitionRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateCompetitionCommand> validator,
        ICompetitionMapper mapper)
        : ICommandHandler<CreateCompetitionCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(
            CreateCompetitionCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<Guid>.Failure(validationResult.Errors);
            }

            var competition = mapper.CreateCompetitionCommandToCompetition(request);

            competitionRepository.Add(competition);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(competition.Id);
        }
    }
}
