using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public sealed record CreateCompetitionCommand(
        string Name, 
        CompetitionType Type, 
        string? Country,
        Guid SeasonId) 
        : ICommand;
}
