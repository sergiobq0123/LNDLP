using System.Linq.Expressions;
using LNDP_API.Dtos;

namespace LNDP_API.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<KeysIntranetDto>> GetKeys();
        Task<TEntity> Exists(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}