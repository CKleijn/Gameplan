using GameplanAPI.Features.Match.GetMatch;

namespace GameplanAPI.Features.Match.GetMatchesBySeason
{
    public sealed record GetMatchesBySeasonResponse(IEnumerable<GetMatchResponse> Matches);
}
