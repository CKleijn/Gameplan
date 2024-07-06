using FluentValidation;

namespace GameplanAPI.Features.Match.UpdateMatch
{
    public sealed class UpdateMatchCommandValidator
        : AbstractValidator<UpdateMatchCommand>
    {
        public UpdateMatchCommandValidator()
        {
            RuleFor(match => match.Id)
                .NotEmpty()
                .WithMessage("Id is required!");

            RuleFor(match => match.HomeClub)
                .NotEmpty()
                .WithMessage("HomeClub is required!");

            RuleFor(match => match.AwayClub)
                .NotEmpty()
                .WithMessage("AwayClub is required!");

            RuleFor(match => match.CompetitionType)
                .NotEmpty()
                .WithMessage("CompetitionType is required!");
        }
    }
}
