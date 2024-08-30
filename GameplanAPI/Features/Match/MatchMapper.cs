using GameplanAPI.Common.Enums;
using GameplanAPI.Common.Extensions;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match.CreateMatch;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Match
{
    [Mapper]
    public partial class MatchMapper
        : IMatchMapper
    {
        [MapPropertyFromSource(nameof(Match.CompetitionType), Use = nameof(MapCompetitionTypeString))]
        public partial Match CreateMatchCommandToMatch(CreateMatchCommand command);

        private CompetitionType MapCompetitionTypeString(CreateMatchCommand command) => Enum.Parse<CompetitionType>(command.CompetitionType);

        [MapPropertyFromSource(nameof(MatchResponse.DateTime), Use = nameof(MapDateTime))]
        [MapPropertyFromSource(nameof(MatchResponse.CompetitionType), Use = nameof(MapCompetitionType))]
        [MapPropertyFromSource(nameof(MatchResponse.MatchStatus), Use = nameof(MapMatchStatus))]
        [MapPropertyFromSource(nameof(MatchResponse.UpdatedAt), Use = nameof(MapUpdatedAt))]
        [MapPropertyFromSource(nameof(MatchResponse.CreatedAt), Use = nameof(MapCreatedAt))]
        public partial MatchResponse MatchToMatchResponse(Match match);

        private string? MapDateTime(Match match) => match.DateTime.ToString("yyyy-MM-ddTHH:mm");
        private string MapCompetitionType(Match match) => match.CompetitionType.GetDisplayName();
        private string MapMatchStatus(Match match) => match.MatchStatus.GetDisplayName();
        private string? MapUpdatedAt(Match match) => match.UpdatedAt?.ToString("dd-MM-yyyy HH:mm");
        private string MapCreatedAt(Match match) => match.CreatedAt.ToString("dd-MM-yyyy HH:mm");
    }
}
