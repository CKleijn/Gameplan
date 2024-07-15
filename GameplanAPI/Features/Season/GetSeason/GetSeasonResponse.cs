namespace GameplanAPI.Features.Season.GetSeason
{
    public sealed record GetSeasonResponse(
        Guid Id,
        string Club, 
        string CalendarYear,
        string? UpdatedAt,
        string CreatedAt); 
}
