using GameplanAPI.Features.Match.CreateMatch;

namespace GameplanAPI.Features.Match._Interfaces
{
    public interface IMatchMapper
    {
        Match CreateMatchCommandToMatch(CreateMatchCommand command);
    }
}
