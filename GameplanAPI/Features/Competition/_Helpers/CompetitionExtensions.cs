using GameplanAPI.Features.Competition.UpdateCompetition;

namespace GameplanAPI.Features.Competition._Helpers
{
    public static class CompetitionExtensions
    {
        public static Competition Update(this Competition competition, UpdateCompetitionCommand command)
        {
            competition.Name = command.Name;
            competition.Type = command.Type;
            competition.Country = command.Country;
            competition.UpdatedAt = DateTime.Now;

            return competition;
        }
    }
}
