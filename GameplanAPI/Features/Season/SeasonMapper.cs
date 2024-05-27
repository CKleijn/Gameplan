using GameplanAPI.Features.Season.CreateSeason;

namespace GameplanAPI.Features.Season
{
    public static class SeasonMapper
    {
        public static Season CreateSeasonCommandToSeason(CreateSeasonCommand command)
        {
            return new Season
            {
                Club = command.Club,
                CalendarYear = command.CalendarYear
            };
        }
    }
}
