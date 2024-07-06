﻿using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;
using System.Linq.Expressions;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed class GetSeasonQueryHandler(ISeasonRepository seasonRepository)
        : IQueryHandler<GetSeasonQuery, Season>
    {
        public async Task<Result<Season>> Handle(
            GetSeasonQuery request,
            CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Season, object>>>
            {
                season => season.Matches
            };

            var season = await seasonRepository.Get(request.Id, cancellationToken, includes);

            if (season == null)
            {
                return Result<Season>.Failure(Errors<Season>.NotFound(request.Id));
            }

            return Result<Season>.Success(season);
        }
    }
}
