using System.Linq.Expressions;
using LNDP_API.Models;

namespace LNDP_API.Repositories
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<IQueryable<Album>> GetAlbumsAsync(Expression<Func<Album, bool>> predicate);
    }
}