using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed record GetSeasonQuery(Guid Id) : IQuery<Season>;
}
