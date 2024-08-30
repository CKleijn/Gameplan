using GameplanAPI.Common.Extensions;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameplanAPI.Common.Implementations
{
    public abstract class Repository<TEntity>(
        ApplicationDbContext context,
        ILogger<Repository<TEntity>> logger)
        : IRepository<TEntity>
        where TEntity : Entity
    {
        public IQueryable<TEntity> GetAsQueryable()
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Retrieving all records of type {typeof(TEntity).Name} as queryable");
            return context
                .Set<TEntity>()
                .AsQueryable();
        }

        public void Add(TEntity entity)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Add record of type {typeof(TEntity).Name}");
            context
                .Set<TEntity>()
                .AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Update record [{entity.Id}] of type {typeof(TEntity).Name}");
            context
                .Set<TEntity>()
                .Update(entity);
        }

        public void Delete(TEntity entity)
        {
            logger.LogInformation($"[Repository<{typeof(TEntity).Name}>] Delete record [{entity.Id}] of type {typeof(TEntity).Name}");
            context
                .Set<TEntity>()
                .Remove(entity);
        }
    }
}
