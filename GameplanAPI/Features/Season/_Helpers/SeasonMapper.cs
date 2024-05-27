using GameplanAPI.Features.Season.CreateSeason;

namespace GameplanAPI.Features.Season._Helpers
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
