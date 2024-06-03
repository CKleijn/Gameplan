using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.Match.GetMatch
{
    public sealed record GetMatchQuery(Guid Id)
        : IQuery<Match>;
}
