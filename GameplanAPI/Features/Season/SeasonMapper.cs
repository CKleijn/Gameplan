using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Features.Season.CreateSeason;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Season._Helpers
{
    [Mapper]
    public partial class SeasonMapper 
        : ISeasonMapper
    {
        public partial Season CreateSeasonCommandToSeason(CreateSeasonCommand command);

        [MapPropertyFromSource(nameof(SeasonResponse.Creator), Use = nameof(MapCreator))]
        [MapPropertyFromSource(nameof(SeasonResponse.UpcomingMatches), Use = nameof(MapUpcomingMatches))]
        [MapPropertyFromSource(nameof(SeasonResponse.UpdatedAt), Use = nameof(MapUpdatedAt))]
        [MapPropertyFromSource(nameof(SeasonResponse.CreatedAt), Use = nameof(MapCreatedAt))]
        public partial SeasonResponse SeasonToSeasonResponse(Season season);

        private string MapCreator(Season season) => season.UserId;
        private IEnumerable<Match.Match> MapUpcomingMatches(Season season)
        {
            return season.Matches
                .Where(m => m.MatchStatus == Common.Enums.MatchStatus.Upcoming && m.DateTime > DateTime.Now)
                .OrderBy(m => m.DateTime)
                .Take(3);
        }
        private string? MapUpdatedAt(Season season) => season.UpdatedAt?.ToString("dd-MM-yyyy HH:mm");
        private string MapCreatedAt(Season season) => season.CreatedAt.ToString("dd-MM-yyyy HH:mm");
    }
}