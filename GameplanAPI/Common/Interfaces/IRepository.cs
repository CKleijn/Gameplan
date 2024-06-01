﻿using System.Linq.Expressions;
using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Common.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll(
            CancellationToken cancellationToken,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null!);
        Task<TEntity?> Get(
            Guid id,
            CancellationToken cancellationToken,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null!);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
