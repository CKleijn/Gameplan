using GameplanAPI.Shared.Abstractions.Interfaces;
using GameplanAPI.Shared.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Shared.Abstractions
{
    public abstract class Repository<TEntity>(ApplicationDbContext context, ILogger<Repository<TEntity>> logger) 
        : IRepository<TEntity> where TEntity : Entity
    {
        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Retrieving all records of type {typeof(TEntity).Name}");
            return await context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> Get(Guid id, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Retrieving specific record by id of type {typeof(TEntity).Name}");
            return await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(TEntity entity)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Add record of type {typeof(TEntity).Name}");
            context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Update record [{entity.Id}] of type {typeof(TEntity).Name}");
            context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Delete record [{entity.Id}] of type {typeof(TEntity).Name}");
            context.Set<TEntity>().Remove(entity);
        }
    }
}
