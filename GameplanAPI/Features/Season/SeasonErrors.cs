using GameplanAPI.Shared.Abstractions.Handling;

namespace GameplanAPI.Features.Season
{
    public static class SeasonErrors
    {
        public static Error NotFound(Guid id) => new("Seasons.NotFound", $"The season with GUID '{id}' was not found");
        public static readonly Error SeasonAlreadyExists = new("Seasons.SeasonAlreadyExists", "Season already exists");
    }
}
