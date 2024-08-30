using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed record GetSeasonQuery(Guid Id) 
        : IQuery<SeasonResponse>;
}
