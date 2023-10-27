using System.Linq.Expressions;

namespace LNDP_API.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetWithIncludesAsync(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> includes = null);

        Task SaveChangesAsync();
    }
}
