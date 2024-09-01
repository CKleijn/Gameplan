using FluentValidation;
using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Common.Services;
using GameplanAPI.Common.Services._Interfaces;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed class UpdateMatchCommandHandler(
        IMatchRepository matchRepository,
        IAuthService authService,
        IUnitOfWork unitOfWork,
        IValidator<UpdateMatchCommand> validator)
        : ICommandHandler<UpdateMatchCommand>
    {
        public async Task<Result> Handle(
            UpdateMatchCommand request, 
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

            var currentUserId = authService.GetCurrentUserId();

            if (currentUserId == null || match.Season.UserId != currentUserId)
            {
                return Result.Failure(Errors<Match>.NotAuthorized);
            }

            if (match.MatchStatus == MatchStatus.Finished)
            {
                return Result.Failure(new Error("Match.MatchAlreadyFinished", $"This match with GUID {match.Id} has already finished"));
            }

            match.HomeClub = request.HomeClub;
            match.AwayClub = request.AwayClub;
            match.DateTime = request.DateTime;
            match.CompetitionType = Enum.Parse<CompetitionType>(request.CompetitionType);
            match.UpdatedAt = DateTime.Now;

            matchRepository.Update(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
