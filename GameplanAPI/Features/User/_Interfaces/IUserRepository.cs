using GameplanAPI.Common.Interfaces;

namespace GameplanAPI.Features.User._Interfaces
{
    public interface IUserRepository 
        : IRepository<User>
    {
        Task<User?> GetUserByUID(string uid, CancellationToken cancellationToken);
    }
}
