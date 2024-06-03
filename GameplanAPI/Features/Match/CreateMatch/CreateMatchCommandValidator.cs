using FluentValidation;
using GameplanAPI.Features.Competition.GetCompetition;
using MediatR;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed class UpdateMatchCommandValidator
        : AbstractValidator<CreateMatchCommand>
    {
        public UpdateMatchCommandValidator(ISender sender)
        {
            // Check clubs

            RuleFor(match => match.CompetitionId)
                .NotEmpty()
                .WithMessage("CompetitionId is required!")
                .MustAsync(async (competitionId, cancellationToken) =>
                {
                    var query = new GetCompetitionQuery(competitionId);

                    var result = await sender.Send(query, cancellationToken);

                    return result.IsSuccess;
                })
                .WithMessage("CompetitionId must exist!");
        }
    }
}
