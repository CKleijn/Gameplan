namespace GameplanAPI.Features.Match.GetMatch
{
    public sealed record GetMatchResponse(
        Guid Id,
        string HomeClub,
        int HomeScore,
        string AwayClub,
        int AwayScore,
        Guid SeasonId,
        string MatchStatus,
        string CompetitionType,
        string? UpdatedAt,
        string CreatedAt);
}
