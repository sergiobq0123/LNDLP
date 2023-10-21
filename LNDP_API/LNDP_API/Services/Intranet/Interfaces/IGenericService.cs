using System.Linq.Expressions;

namespace LNDP_API.Services{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
        Expression<Func<TEntity, object>> includes = null);
        Task<TEntity> Exists(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}