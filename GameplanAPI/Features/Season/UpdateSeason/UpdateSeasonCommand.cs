using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.UpdateSeason
{
    public sealed record UpdateSeasonCommand(Guid Id, string Club, string CalendarYear) : ICommand;
}
