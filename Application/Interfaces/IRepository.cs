using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetQueryable();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
    }
}

