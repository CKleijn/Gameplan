namespace GameplanAPI.Features.Match
{
    public sealed record MatchResponse(
        Guid Id,
        string HomeClub,
        int HomeScore,
        string AwayClub,
        int AwayScore,
        Guid SeasonId,
        string DateTime,
        string MatchStatus,
        string CompetitionType,
        string? UpdatedAt,
        string CreatedAt);
}
