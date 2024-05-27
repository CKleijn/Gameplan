using GameplanAPI.Features.Competition.CreateCompetition;

namespace GameplanAPI.Features.Competition._Helpers
{
    public static class CompetitionMapper
    {
        public static Competition CreateCompetitionCommandToCompetition(CreateCompetitionCommand command)
        {
            return new Competition
            {
                Name = command.Name,
                Type = command.Type,
                Country = command.Country
            };
        }
    }
}
