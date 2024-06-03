using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Features.Competition
{
    public sealed class Competition : Entity
    {
        public string Name { get; set; } = string.Empty;
        public CompetitionType Type { get; set; } = CompetitionType.Other;
        public string? Country { get; set; }
        public Guid SeasonId { get; set; } = Guid.Empty;
    }

    public enum CompetitionType
    {
        NationalCompetition = 0,
        NationalCup = 1,
        NationalSuperCup = 2,
        ChampionsLeague = 3,
        EuropaLeague = 4,
        ConferenceLeague = 5,
        SuperCup = 6,
        Other = 7
    }
}
