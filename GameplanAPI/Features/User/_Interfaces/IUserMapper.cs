using GameplanAPI.Features.User.RegisterUser;

namespace GameplanAPI.Features.User._Interfaces
{
    public interface IUserMapper
    {
        User RegisterUserCommandToUser(RegisterUserCommand command);
    }
}
