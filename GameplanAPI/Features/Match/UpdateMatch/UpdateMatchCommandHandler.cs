﻿using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match.GetMatch;
using MediatR;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed class UpdateMatchCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork,
        ISender sender,
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

            var matchQuery = new GetMatchQuery(request.Id);

            var matchQueryResult = await sender.Send(matchQuery, cancellationToken);

            if (matchQueryResult.IsFailure)
            {
                return Result.Failure(matchQueryResult.Error);
            }

            var match = matchQueryResult.Value!;

            match.HomeClub = request.HomeClub;
            match.AwayClub = request.AwayClub;
            match.CompetitionType = request.CompetitionType;
            match.UpdatedAt = DateTime.Now;

            matchRepository.Update(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
