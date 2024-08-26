using GameplanAPI.Features.User._Interfaces;
using GameplanAPI.Features.User.GetUserByUID;
using GameplanAPI.Features.User.RegisterUser;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.User
{
    [Mapper]
    public partial class UserMapper
        : IUserMapper
    {
        public partial User RegisterUserCommandToUser(RegisterUserCommand command);

        [MapPropertyFromSource(nameof(GetUserByUIDResponse.UpdatedAt), Use = nameof(MapUpdatedAt))]
        [MapPropertyFromSource(nameof(GetUserByUIDResponse.CreatedAt), Use = nameof(MapCreatedAt))]
        public partial GetUserByUIDResponse UserToGetUserByUIDResponse(User user);

        private string? MapUpdatedAt(User user) => user.UpdatedAt?.ToString("dd-MM-yyyy HH:mm");
        private string MapCreatedAt(User user) => user.CreatedAt.ToString("dd-MM-yyyy HH:mm");
    }
}
