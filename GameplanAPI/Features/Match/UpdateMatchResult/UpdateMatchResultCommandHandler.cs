using FluentValidation;
using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatchResult
{
    public sealed class UpdateMatchResultCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork,
        IValidator<UpdateMatchResultCommand> validator)
        : ICommandHandler<UpdateMatchResultCommand>
    {
        public async Task<Result> Handle(
            UpdateMatchResultCommand request,
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                Result.Failure(validationResult.Errors);
            }

            var match = await matchRepository.GetMatch(request.Id, cancellationToken);

            if (match == null)
            {
                return Result.Failure(Errors<Match>.NotFound(request.Id));
            }

            if (match.MatchStatus == MatchStatus.Finished)
            {
                return Result.Failure(new Error("Match.MatchAlreadyFinished", $"This match with GUID {match.Id} has already finished"));
            }

            match.HomeScore = request.HomeScore;
            match.AwayScore = request.AwayScore;
            match.MatchStatus = Enum.Parse<MatchStatus>(request.MatchStatus);
            match.UpdatedAt = DateTime.Now;

            matchRepository.Update(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
