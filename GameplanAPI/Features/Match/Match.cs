using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Features.Match
{
    public sealed class Match : Entity
    {
        public string HomeClub { get; set; } = string.Empty;
        public int HomeScore { get; set; } = 0;
        public string AwayClub { get; set; } = string.Empty;
        public int AwayScore { get; set; } = 0;
        public MatchStatus MatchStatus { get; set; } = MatchStatus.Upcoming;
        public CompetitionType CompetitionType { get; set; } = CompetitionType.Other;
        public Guid SeasonId { get; set; } = Guid.Empty;
        // Participants
    }
}
