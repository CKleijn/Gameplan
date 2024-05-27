using GameplanAPI.Shared.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Shared.Abstractions
{
    public abstract class Repository<TEntity>(ApplicationDbContext context) 
        : IRepository<TEntity> where TEntity : Entity
    {
        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
