using GameplanAPI.Features.Season.CreateSeason;
using GameplanAPI.Features.Season.GetSeason;

namespace GameplanAPI.Features.Season._Interfaces
{
    public interface ISeasonMapper
    {
        Season CreateSeasonCommandToSeason(CreateSeasonCommand command);
        GetSeasonResponse SeasonToGetSeasonResponse(Season season);
    }
}
