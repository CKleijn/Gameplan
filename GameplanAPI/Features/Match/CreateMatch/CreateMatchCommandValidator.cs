using FluentValidation;

namespace GameplanAPI.Features.Match.CreateMatch
{
    public sealed class CreateMatchCommandValidator
        : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
        {
            RuleFor(match => match.HomeClub)
                .NotEmpty()
                .WithMessage("HomeClub is required!");

            RuleFor(match => match.AwayClub)
                .NotEmpty()
                .WithMessage("AwayClub is required!");

            RuleFor(match => match.CompetitionType)
                .NotEmpty()
                .WithMessage("CompetitionType is required!");

            RuleFor(match => match.DateTime)
                .NotEmpty()
                .WithMessage("DateTime is required!");

            RuleFor(match => match.SeasonId)
                .NotEmpty()
                .WithMessage("SeasonId is required!");
        }
    }
}
