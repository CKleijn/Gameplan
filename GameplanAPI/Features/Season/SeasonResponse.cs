namespace GameplanAPI.Features.Season
{
    public sealed record SeasonResponse(
        Guid Id,
        string Club,
        string CalendarYear,
        IEnumerable<Match.Match> UpcomingMatches,
        string Creator,
        string? UpdatedAt,
        string CreatedAt);
}
