using System.Linq.Expressions;
using LNDP_API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LNDP_API.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<PagedResponse<List<TEntity>>> Get([FromQuery] PaginationFilter paginationFilter, string route);
        Task<PagedResponse<List<TEntity>>> GetPagination([FromQuery] PaginationFilter paginationFilter, IQueryable<TEntity> query, string route);
        Task<IEnumerable<KeysIntranetDto>> GetKeys();
        Task<TEntity> Exists(TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}