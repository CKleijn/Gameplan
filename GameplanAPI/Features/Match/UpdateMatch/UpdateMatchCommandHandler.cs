using FluentValidation;
using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed class UpdateMatchCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork,
        IValidator<UpdateMatchCommand> validator)
        : ICommandHandler<UpdateMatchCommand>
    {
        public async Task<Result> Handle(
            UpdateMatchCommand request, 
            CancellationToken cancellationToken)
        {
            var match = await matchRepository.Get(request.Id, cancellationToken);

            if (match == null)
            {
                return Result.Failure(Errors<Match>.NotFound(request.Id));
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                Result.Failure(validationResult.Errors);
            }

            // Update match
            match.UpdatedAt = DateTime.Now;

            matchRepository.Update(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
