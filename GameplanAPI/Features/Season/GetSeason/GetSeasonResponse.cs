namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed record GetSeasonResponse(
        Guid Id,
        string Club, 
        string CalendarYear,
        IEnumerable<Match.Match> UpcomingMatches,
        string Creator,
        string? UpdatedAt,
        string CreatedAt); 
}
