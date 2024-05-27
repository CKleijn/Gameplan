using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public sealed record CreateSeasonCommand(string Club, string CalendarYear) : ICommand;
}
