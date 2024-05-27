using FluentValidation;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public sealed class UpdateSeasonCommandValidator : AbstractValidator<UpdateSeasonCommand>
    {
        public UpdateSeasonCommandValidator()
        {
            RuleFor(season => season.Id)
                .NotEmpty()
                .WithMessage("Id is required!");

            RuleFor(season => season.Club)
                .NotEmpty()
                .WithMessage("Club is required!");

            RuleFor(season => season.CalendarYear)
                .NotEmpty()
                .WithMessage("Calendar year is required!");
        }
    }
}
