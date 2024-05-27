using GameplanAPI.Shared.Abstractions;

namespace GameplanAPI.Features.Competition
{
    public class Competition : Entity
    {
        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = value; } }

        private CompetitionType _type = CompetitionType.Other;
        public CompetitionType Type { get { return _type; } set { _type = value; } }

        private string? _country;
        public string? Country { get { return _country; } set { _country = value; } }
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
