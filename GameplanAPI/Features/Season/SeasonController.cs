using GameplanAPI.Features.Season.CreateSeason;
using GameplanAPI.Features.Season.DeleteSeason;
using GameplanAPI.Features.Season.GetAllSeasons;
using GameplanAPI.Features.Season.GetSeason;
using GameplanAPI.Features.Season.UpdateSeason;
using GameplanAPI.Shared.Abstractions.Handling;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameplanAPI.Features.Season
{
    [ApiController]
    [Route("api/seasons")]
    public sealed class SeasonController(ISender sender) : Controller
    {
        [HttpGet]
        public async Task<IResult> GetAllSeasons(CancellationToken cancellationToken)
        {
            var query = new GetAllSeasonsQuery();

            var result = await sender.Send(query, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetSeason([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetSeasonQuery(id);

            var result = await sender.Send(query, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.GetProblemDetails();
        }

        [HttpPost]
        public async Task<IResult> CreateSeason(CreateSeasonCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateSeason([FromRoute] Guid id, UpdateSeasonCommand command, CancellationToken cancellationToken)
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
            var command = new DeleteSeasonCommand(id);

            var result = await sender.Send(command, cancellationToken);

            return result.IsSuccess ? Results.NoContent() : result.GetProblemDetails();
        }
    }
}
