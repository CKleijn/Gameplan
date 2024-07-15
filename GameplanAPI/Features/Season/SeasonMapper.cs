using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Features.Season.CreateSeason;
using GameplanAPI.Features.Season.GetSeason;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Season._Helpers
{
    [Mapper]
    public partial class SeasonMapper 
        : ISeasonMapper
    {
        public partial Season CreateSeasonCommandToSeason(CreateSeasonCommand command);

        [MapPropertyFromSource(nameof(GetSeasonResponse.UpdatedAt), Use = nameof(MapUpdatedAt))]
        [MapPropertyFromSource(nameof(GetSeasonResponse.CreatedAt), Use = nameof(MapCreatedAt))]
        public partial GetSeasonResponse SeasonToGetSeasonResponse(Season season);

        private string? MapUpdatedAt(Season season) => season.UpdatedAt?.ToString("dd-MM-yyyy HH:mm");
        private string MapCreatedAt(Season season) => season.CreatedAt.ToString("dd-MM-yyyy HH:mm");
    }
}