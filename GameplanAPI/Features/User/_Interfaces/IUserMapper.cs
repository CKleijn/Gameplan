using GameplanAPI.Features.User.GetUserByUID;
using GameplanAPI.Features.User.RegisterUser;

namespace GameplanAPI.Features.User._Interfaces
{
    public interface IUserMapper
    {
        User RegisterUserCommandToUser(RegisterUserCommand command);
        GetUserByUIDResponse UserToGetUserByUIDResponse(User user);
    }
}
