using GameplanAPI.Features.User._Interfaces;
using GameplanAPI.Features.User.RegisterUser;
using Riok.Mapperly.Abstractions;

namespace GameplanAPI.Features.User
{
    [Mapper]
    public partial class UserMapper
        : IUserMapper
    {
        public partial User RegisterUserCommandToUser(RegisterUserCommand command);

        [MapPropertyFromSource(nameof(UserResponse.UpdatedAt), Use = nameof(MapUpdatedAt))]
        [MapPropertyFromSource(nameof(UserResponse.CreatedAt), Use = nameof(MapCreatedAt))]
        public partial UserResponse UserToUserResponse(User user);

        private string? MapUpdatedAt(User user) => user.UpdatedAt?.ToString("dd-MM-yyyy HH:mm");
        private string MapCreatedAt(User user) => user.CreatedAt.ToString("dd-MM-yyyy HH:mm");
    }
}
