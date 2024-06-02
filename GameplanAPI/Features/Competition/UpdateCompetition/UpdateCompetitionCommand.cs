using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public sealed record UpdateCompetitionCommand(
        Guid Id, 
        string Name, 
        CompetitionType Type, 
        string? Country,
        Guid SeasonId) 
        : ICommand;
}
