﻿using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;
using System.Linq.Expressions;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed class GetAllSeasonsQueryHandler(ISeasonRepository seasonRepository) 
        : IQueryHandler<GetAllSeasonsQuery, IEnumerable<Season>>
    {
        public async Task<Result<IEnumerable<Season>>> Handle(
            GetAllSeasonsQuery request, 
            CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Season, object>>>
            {
                s => s.Matches
            };

            var seasons = await seasonRepository.GetAll(cancellationToken, includes);

            return Result<IEnumerable<Season>>.Success(seasons);
        }
    }
}
