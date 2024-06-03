using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.DeleteMatch
{
    public sealed record DeleteMatchCommand(Guid Id)
        : ICommand;
}
