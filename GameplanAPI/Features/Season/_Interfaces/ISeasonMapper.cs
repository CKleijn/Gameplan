using GameplanAPI.Features.Season.CreateSeason;

namespace GameplanAPI.Features.Season._Interfaces
{
    public interface ISeasonMapper
    {
        Season CreateSeasonCommandToSeason(CreateSeasonCommand command);
        SeasonResponse SeasonToSeasonResponse(Season season);
    }
}
