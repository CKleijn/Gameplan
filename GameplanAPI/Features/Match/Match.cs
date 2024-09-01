using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Implementations;
using System.Text.Json.Serialization;

namespace GameplanAPI.Features.Match
{
    public sealed class Match : Entity
    {
        public string HomeClub { get; set; } = string.Empty;
        public int HomeScore { get; set; } = 0;
        public string AwayClub { get; set; } = string.Empty;
        public int AwayScore { get; set; } = 0;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public MatchStatus MatchStatus { get; set; } = MatchStatus.Upcoming;
        public CompetitionType CompetitionType { get; set; } = CompetitionType.Other;
        public Guid SeasonId { get; set; } = Guid.Empty;
        [JsonIgnore]
        public Season.Season Season { get; set; } = null!;
    }
}
