using FluentValidation;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed class UpdateMatchCommandValidator
        : AbstractValidator<CreateMatchCommand>
    {
        public UpdateMatchCommandValidator()
        {
            RuleFor(match => match.HomeClub)
                .NotEmpty()
                .WithMessage("HomeClub is required!");

            RuleFor(match => match.AwayClub)
                .NotEmpty()
                .WithMessage("AwayClub is required!");

            RuleFor(match => match.CompetitionType)
                .NotNull()
                .WithMessage("CompetitionType is required!");

            RuleFor(match => match.SeasonId)
                .NotEmpty()
                .WithMessage("SeasonId is required!");
        }
    }
}
