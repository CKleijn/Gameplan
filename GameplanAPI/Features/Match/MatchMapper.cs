using GameplanAPI.Common.Extensions;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match.CreateMatch;
using GameplanAPI.Features.Match.GetMatch;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Match
{
    [Mapper]
    public partial class MatchMapper
        : IMatchMapper
    {
        public partial Match CreateMatchCommandToMatch(CreateMatchCommand command);

        [MapPropertyFromSource(nameof(GetMatchResponse.CompetitionType), Use = nameof(MapCompetitionType))]
        [MapPropertyFromSource(nameof(GetMatchResponse.UpdatedAt), Use = nameof(MapUpdatedAt))]
        [MapPropertyFromSource(nameof(GetMatchResponse.CreatedAt), Use = nameof(MapCreatedAt))]
        public partial GetMatchResponse MatchToGetMatchResponse(Match match);

        private string MapCompetitionType(Match match) => match.CompetitionType.GetDisplayName();
        private string? MapUpdatedAt(Match match) => match.UpdatedAt?.ToString("dd-MM-yyyy HH:mm");
        private string MapCreatedAt(Match match) => match.CreatedAt.ToString("dd-MM-yyyy HH:mm");
    }
}
