using FluentValidation;
using GameplanAPI.Features.Season.GetSeason;
using MediatR;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public sealed class CreateCompetitionCommandValidator 
        : AbstractValidator<CreateCompetitionCommand>
    {
        public CreateCompetitionCommandValidator(ISender sender)
        {
            RuleFor(competition => competition.Name)
                .NotEmpty()
                .WithMessage("Name is required!");

            RuleFor(competition => competition.Type)
                .NotNull()
                .WithMessage("Type is required!")
                .IsInEnum()
                .WithMessage("Type needs to be an existing option!");

            RuleFor(competition => competition.SeasonId)
                .NotEmpty()
                .WithMessage("SeasonId is required!")
                .MustAsync(async (seasonId, cancellationToken) =>
                {
                    var query = new GetSeasonQuery(seasonId);

                    var result = await sender.Send(query, cancellationToken);

                    return result.IsSuccess;
                })
                .WithMessage("SeasonId must exist!");
        }
    }
}
