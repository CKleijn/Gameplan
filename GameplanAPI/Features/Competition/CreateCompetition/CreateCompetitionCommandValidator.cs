using FluentValidation;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public sealed class CreateCompetitionCommandValidator 
        : AbstractValidator<CreateCompetitionCommand>
    {
        public CreateCompetitionCommandValidator()
        {
            RuleFor(competition => competition.Name)
                .NotEmpty()
                .WithMessage("Name is required!");

            RuleFor(competition => competition.Type)
                .NotNull()
                .WithMessage("Type is required!")
                .IsInEnum()
                .WithMessage("Type needs to be an existing option!");
        }
    }
}
