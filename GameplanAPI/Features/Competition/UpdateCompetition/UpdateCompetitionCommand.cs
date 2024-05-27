using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.UpdateCompetition
{
    public sealed record UpdateCompetitionCommand(Guid Id, string Name, CompetitionType Type, string? Country) : ICommand;
}
