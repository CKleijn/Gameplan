using GameplanAPI.Features.Season.UpdateSeason;

namespace GameplanAPI.Features.Season._Helpers
{
    public static class SeasonExtensions
    {
        public static Season Update(this Season season, UpdateSeasonCommand command)
        {
            season.Club = command.Club;
            season.CalendarYear = command.CalendarYear;
            season.UpdatedAt = DateTime.Now;

            return season;
        }
    }
}
