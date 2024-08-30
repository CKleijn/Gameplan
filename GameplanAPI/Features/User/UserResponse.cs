namespace GameplanAPI.Features.User
{
    public sealed record UserResponse(
        Guid Id,
        string UID,
        string DisplayName,
        string Email,
        string Provider,
        string? UpdatedAt,
        string CreatedAt);
}
