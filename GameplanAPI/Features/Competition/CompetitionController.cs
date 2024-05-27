using GameplanAPI.Features.Competition.CreateCompetition;
using GameplanAPI.Features.Competition.DeleteCompetition;
using GameplanAPI.Features.Competition.GetAllCompetitions;
using GameplanAPI.Features.Competition.GetCompetition;
using GameplanAPI.Features.Competition.UpdateCompetition;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameplanAPI.Features.Competition
{
    [ApiController]
    [Route("api/competitions")]
    public sealed class CompetitionController(ISender sender) : Controller
    {
        [HttpGet]
        public async Task<IResult> GetAllSeasons(CancellationToken cancellationToken)
        {
            var query = new GetAllCompetitionsQuery();

            var result = await sender.Send(query, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetSeason([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCompetitionQuery(id);

            var result = await sender.Send(query, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
        }

        [HttpPost]
        public async Task<IResult> CreateSeason(CreateCompetitionCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateSeason([FromRoute] Guid id, UpdateCompetitionCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return Results.BadRequest();
            }

            var result = await sender.Send(command, cancellationToken);

            return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSeason([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCompetitionCommand(id);

            var result = await sender.Send(command, cancellationToken);

            return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
        }
    }
}
