using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match.CreateMatch;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Match
{
    [Mapper]
    public partial class MatchMapper
        : IMatchMapper
    {
        public partial Match CreateMatchCommandToMatch(CreateMatchCommand command);
    }
}
