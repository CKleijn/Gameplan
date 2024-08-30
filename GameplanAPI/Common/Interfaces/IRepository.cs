using GameplanAPI.Common.Implementations;

namespace GameplanAPI.Common.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IQueryable<TEntity> GetAsQueryable();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
