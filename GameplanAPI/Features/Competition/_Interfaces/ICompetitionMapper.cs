using GameplanAPI.Features.Competition.CreateCompetition;

namespace GameplanAPI.Features.Competition._Interfaces
{
    public interface ICompetitionMapper
    {
        Competition CreateCompetitionCommandToCompetition(CreateCompetitionCommand command);
    }
}
