using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed class CreateMatchCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateMatchCommand> validator,
        IMatchMapper mapper)
        : ICommandHandler<CreateMatchCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(
            CreateMatchCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<Guid>.Failure(validationResult.Errors);
            }

            var match = mapper.CreateMatchCommandToMatch(request);

            matchRepository.Add(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(match.Id);
        }
    }
}
