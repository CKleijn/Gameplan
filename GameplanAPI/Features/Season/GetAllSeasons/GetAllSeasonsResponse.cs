using GameplanAPI.Features.Season.GetSeason;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed record GetAllSeasonsResponse(IEnumerable<GetSeasonResponse> Seasons);
}
