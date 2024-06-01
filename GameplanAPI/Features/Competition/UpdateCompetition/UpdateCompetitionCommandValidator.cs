using FluentValidation;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public sealed class UpdateCompetitionCommandValidator 
        : AbstractValidator<UpdateCompetitionCommand>
    {
        public UpdateCompetitionCommandValidator()
        {
            RuleFor(competition => competition.Id)
                .NotEmpty()
                .WithMessage("Id is required!");

            RuleFor(competition => competition.Name)
                .NotEmpty()
                .WithMessage("Name is required!");

            RuleFor(competition => competition.Type)
                .NotEmpty()
                .WithMessage("Type is required!");
        }
    }
}
