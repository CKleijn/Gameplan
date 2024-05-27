using GameplanAPI.Shared.Abstractions.Interfaces;
using GameplanAPI.Shared.Database.Contexts;

namespace GameplanAPI.Shared.Abstractions
{
    public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
