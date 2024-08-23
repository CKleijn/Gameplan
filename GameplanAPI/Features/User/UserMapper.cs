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
    }
}
