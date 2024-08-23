using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.User.RegisterUser
{
    public sealed record RegisterUserCommand(
        string UID,
        string DisplayName,
        string Email,
        string Provider)
        : ICommand;
}
