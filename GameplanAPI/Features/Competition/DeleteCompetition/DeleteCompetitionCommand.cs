using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.DeleteCompetition
{
    public sealed record DeleteCompetitionCommand(Guid Id) : ICommand;
}
