using FluentValidation;

namespace GameplanAPI.Features.Match.UpdateMatchResult
{
    public sealed class UpdateMatchResultCommandValidator
        : AbstractValidator<UpdateMatchResultCommand>
    {
        public UpdateMatchResultCommandValidator()
        {
            RuleFor(match => match.Id)
                .NotEmpty()
                .WithMessage("Id is required!");

            RuleFor(match => match.HomeScore)
                .NotEmpty()
                .WithMessage("HomeScore is required!");

            RuleFor(match => match.AwayScore)
                .NotEmpty()
                .WithMessage("AwayScore is required!");

            RuleFor(match => match.MatchStatus)
                .NotEmpty()
                .WithMessage("MatchStatus is required!");
        }
    }
}
