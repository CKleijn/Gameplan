using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Features.Season.CreateSeason;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Season._Helpers
{
    [Mapper]
    public partial class SeasonMapper : ISeasonMapper
    {
        public partial Season CreateSeasonCommandToSeason(CreateSeasonCommand command);
    }
}
