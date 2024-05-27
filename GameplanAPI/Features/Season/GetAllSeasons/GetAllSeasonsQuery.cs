using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.GetAllSeasons
{
    public sealed record GetAllSeasonsQuery() : IQuery<IEnumerable<Season>>;
}
