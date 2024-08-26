namespace GameplanAPI.Features.User.GetUserByUID
{
    public sealed record GetUserByUIDResponse(
        Guid Id,
        string UID,
        string DisplayName,
        string Email,
        string Provider,
        string? UpdatedAt,
        string CreatedAt);
}
