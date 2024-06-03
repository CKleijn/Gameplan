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
        public Guid CompetitionId { get; set; } = Guid.Empty;
    }

    public enum MatchStatus
    {
        Upcoming = 0,
        Playing = 1,
        Finished = 2,
        Postponed = 3
    }
}
