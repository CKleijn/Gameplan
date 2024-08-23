using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.User._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;

namespace GameplanAPI.Features.User
{
    public sealed class UserRepository(
        ApplicationDbContext context,
        ILogger<UserRepository> logger)
        : Repository<User>(context, logger),
        IUserRepository
    {
    }
}
