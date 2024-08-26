using GameplanAPI.Common.Implementations;
using GameplanAPI.Features.User._Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Features.User
{
    public sealed class UserRepository(
        ApplicationDbContext context,
        ILogger<UserRepository> logger)
        : Repository<User>(context, logger),
        IUserRepository
    {
        public async Task<User?> GetUserByUID(
            string uid,
            CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Repository<{typeof(User).Name}>] Retrieving all records of type {typeof(User).Name} by UID {uid}");
            return await context
                .Set<User>()
                .FirstOrDefaultAsync(u => u.UID == uid, cancellationToken);
        }
    }
}
