using FluentValidation;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public sealed class CreateSeasonCommandValidator 
        : AbstractValidator<CreateSeasonCommand>
    {
        public CreateSeasonCommandValidator()
        {
            RuleFor(season => season.Club)
                .NotEmpty()
                .WithMessage("Club is required!");

            RuleFor(season => season.CalendarYear)
                .NotEmpty()
                .WithMessage("Calendar year is required!");
        }
    }
}
