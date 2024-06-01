using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Competition.DeleteCompetition
{
    public sealed record DeleteCompetitionCommand(Guid Id) 
        : ICommand;
}
