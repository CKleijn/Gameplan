using GameplanAPI.Shared.Abstractions.Handling;

namespace GameplanAPI.Features.Season._Helpers
{
    public static class SeasonErrors
    {
        public static Error NotFound(Guid id) => new("Seasons.NotFound", $"The season with GUID '{id}' was not found");
        public static readonly Error AlreadyExists = new("Seasons.SeasonAlreadyExists", "Season already exists");
    }
}
