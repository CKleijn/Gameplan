using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match.GetMatch;
using MediatR;

namespace GameplanAPI.Features.Match.UpdateMatchResult
{
    public sealed class UpdateMatchResultCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork,
        ISender sender,
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

            var matchQuery = new GetMatchQuery(request.Id);

            var matchQueryResult = await sender.Send(matchQuery, cancellationToken);

            if (matchQueryResult.IsFailure)
            {
                return Result.Failure(matchQueryResult.Error);
            }

            var match = matchQueryResult.Value!;

            match.HomeScore = request.HomeScore;
            match.AwayScore = request.AwayScore;
            match.MatchStatus = Common.Enums.MatchStatus.Finished;
            match.UpdatedAt = DateTime.Now;

            matchRepository.Update(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
