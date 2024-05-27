using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.CreateCompetition
{
    public sealed record CreateCompetitionCommand(string Name, CompetitionType Type, string? Country) : ICommand;
}
