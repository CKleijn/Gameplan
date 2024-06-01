using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed record DeleteSeasonCommand(Guid Id) 
        : ICommand;
}
