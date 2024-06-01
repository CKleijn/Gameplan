using GameplanAPI.Common.Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;

namespace GameplanAPI.Common.Implementations
{
    public sealed class UnitOfWork(ApplicationDbContext context)
        : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
