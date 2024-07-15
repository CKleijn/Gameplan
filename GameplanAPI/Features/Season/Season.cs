using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Features.Season
{
    public sealed class Season : Entity
    {
        public string Club { get; set; } = string.Empty;
        public string CalendarYear { get; set; } = string.Empty;
        // Creator
        // Participants
    }
}
