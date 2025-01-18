using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private TestDbContext ctx;

        public Repository(TestDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IQueryable<TEntity>> GetQueryable()
        {
            return ctx.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            ctx.Add(entity).State = EntityState.Added;
            ctx.SaveChanges();
        }
        public async Task Update(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public async Task Delete(TEntity entity)
        {
            ctx.Remove(entity);
            ctx.SaveChanges();
        }
        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await ctx.Set<TEntity>().AnyAsync(predicate);
        }
        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await ctx.Set<TEntity>().CountAsync(predicate);
        }
    }
}