using GameplanAPI.Shared.Abstractions;

namespace GameplanAPI.Features.Season
{
    public class Season : Entity
    {
        private string _club = string.Empty;
        public string Club { get { return _club; } set { _club = value; } }

        private string _calendarYear = string.Empty;
        public string CalendarYear { get { return _calendarYear; } set { _calendarYear = value; } }
    }
}
