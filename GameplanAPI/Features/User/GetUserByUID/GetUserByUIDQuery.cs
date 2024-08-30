using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.User.GetUserByUID
{
    public sealed record GetUserByUIDQuery(string UID)
        : IQuery<UserResponse>;
}
