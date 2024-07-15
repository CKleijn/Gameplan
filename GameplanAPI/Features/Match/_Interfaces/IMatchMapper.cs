using GameplanAPI.Features.Match.CreateMatch;
using GameplanAPI.Features.Match.GetMatch;

namespace GameplanAPI.Features.Match._Interfaces
{
    public interface IMatchMapper
    {
        Match CreateMatchCommandToMatch(CreateMatchCommand command);
        GetMatchResponse MatchToGetMatchResponse(Match match);
    }
}
