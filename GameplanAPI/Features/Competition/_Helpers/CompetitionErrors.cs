using GameplanAPI.Shared.Abstractions.Handling;

namespace GameplanAPI.Features.Competition._Helpers
{
    public static class CompetitionErrors
    {
        public static Error NotFound(Guid id) => new("Competitions.NotFound", $"The competition with GUID '{id}' was not found");
        public static readonly Error AlreadyExists = new("Competitions.CompetitionAlreadyExists", "Competition already exists");
    }
}
