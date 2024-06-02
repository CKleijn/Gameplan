using FluentValidation;
using GameplanAPI.Features.Season.GetSeason;
using MediatR;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public sealed class UpdateCompetitionCommandValidator 
        : AbstractValidator<UpdateCompetitionCommand>
    {
        public UpdateCompetitionCommandValidator(ISender sender)
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
