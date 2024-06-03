using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Features.Match
{
    public class Match : Entity
    {
        private string _homeClub = string.Empty;
        public string HomeClub { get { return _homeClub; } set { _homeClub = value; } }

        private int _homeScore = 0;
        public int HomeScore { get { return _homeScore; } set { _homeScore = value; } }

        private string _awayClub = string.Empty;
        public string AwayClub { get { return _awayClub; } set { _awayClub = value; } }

        private int _awayScore = 0;
        public int AwayScore { get { return _awayScore; } set { _awayScore = value; } }

        private MatchStatus _matchStatus = MatchStatus.Upcoming;
        public MatchStatus MatchStatus { get { return _matchStatus; } set { _matchStatus = value; } }

        private Guid _competitionId;
        public Guid CompetitionId { get { return _competitionId; } set { _competitionId = value; } }
    }

    public enum MatchStatus
    {
        Upcoming = 0,
        Playing = 1,
        Finished = 2,
        Postponed = 3
    }
}
