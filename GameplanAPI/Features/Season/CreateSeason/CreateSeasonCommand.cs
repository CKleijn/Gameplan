using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Season.CreateSeason
{
    public sealed record CreateSeasonCommand(
        string Club, 
        string CalendarYear) 
        : ICommand<Guid>;
}
