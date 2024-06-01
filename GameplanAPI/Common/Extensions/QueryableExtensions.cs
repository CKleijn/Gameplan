using GameplanAPI.Common.Extensions;
using GameplanAPI.Common.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameplanAPI.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Include<TEntity>(
            this IQueryable<TEntity> query,
            IEnumerable<Expression<Func<TEntity, object>>> includes)
            where TEntity : Entity
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
