using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed class UpdateMatchCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork,
        IValidator<CreateMatchCommand> validator,
        IMatchMapper mapper)
        : ICommandHandler<CreateMatchCommand>
    {
        public async Task<Result> Handle(
            CreateMatchCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            var match = mapper.CreateMatchCommandToMatch(request);

            matchRepository.Add(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
