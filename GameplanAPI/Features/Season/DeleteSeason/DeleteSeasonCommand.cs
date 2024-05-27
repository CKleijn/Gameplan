using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed record DeleteSeasonCommand(Guid Id) : ICommand;
}
