using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Features.Competition.CreateCompetition;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.Competition._Helpers
{
    [Mapper]
    public partial class CompetitionMapper : ICompetitionMapper
    {
        public partial Competition CreateCompetitionCommandToCompetition(CreateCompetitionCommand command);
    }
}
