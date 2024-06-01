using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed record GetAllSeasonsQuery() 
        : IQuery<IEnumerable<Season>>;
}
